using System.Linq;
using System.Data.Entity;

namespace DAL
{
	public class ContractRepository : object, IContractRepository
	{
		public ContractRepository() : base()
		{
		}

		// **********
		public bool IsContractNumberExist(string contractNumber, System.Guid? excludeContractId = null)
		{
			Models.DatabaseContext databaseContext = null;
			try
			{
				databaseContext = new Models.DatabaseContext();

				var query = databaseContext.Contracts.Where(current => current.ContractNumber == contractNumber);

				if (excludeContractId.HasValue)
				{
					query = query.Where(current => current.Id != excludeContractId.Value);
				}

				return query.Any();
			}
			catch (System.Exception)
			{
				throw;
			}
			finally
			{
				if (databaseContext != null)
				{
					databaseContext.Dispose();
					databaseContext = null;
				}
			}
		}

		// **********
		public System.Collections.Generic.List<Models.Contract> GetPagedContracts(string filterText, int pageIndex, int pageSize, out int totalRecords)
		{
			Models.DatabaseContext databaseContext = null;
			try
			{
				databaseContext = new Models.DatabaseContext();

				// واکشی به همراه مشتری و فاکتور برای نمایش در لیست
				var query = databaseContext.Contracts
					.Include(current => current.Customer)
					.Include(current => current.Invoice)
					.AsQueryable();

				if (string.IsNullOrWhiteSpace(filterText) == false)
				{
					string filter = filterText.Trim();
					query = query.Where(current =>
						current.ContractNumber.Contains(filter) ||
						current.Customer.FullName.Contains(filter));
				}

				totalRecords = query.Count();

				return query
					.OrderByDescending(current => current.EndDate) // پیش‌فرض بر اساس نزدیک‌ترین انقضا
					.Skip((pageIndex - 1) * pageSize)
					.Take(pageSize)
					.ToList();
			}
			catch (System.Exception)
			{
				throw;
			}
			finally
			{
				if (databaseContext != null)
				{
					databaseContext.Dispose();
					databaseContext = null;
				}
			}
		}

		// **********
		// متد گزارش‌گیری برای قراردادهای رو به انقضا (این متد در داشبورد یا آلارم‌ها غوغا می‌کند!)
		public System.Collections.Generic.List<Models.Contract> GetExpiringContracts(int daysToWarn)
		{
			Models.DatabaseContext databaseContext = null;
			try
			{
				databaseContext = new Models.DatabaseContext();

				System.DateTime today = System.DateTime.Now.Date;
				System.DateTime warningDate = today.AddDays(daysToWarn);

				// قراردادهایی را بیاور که تاریخ پایانشان بین امروز تا روزِ هشدار باشد
				var query = databaseContext.Contracts
					.Include(current => current.Customer)
					.Where(current => current.EndDate >= today && current.EndDate <= warningDate)
					.OrderBy(current => current.EndDate) // مرتب‌سازی صعودی تا آن‌هایی که زودتر منقضی می‌شوند بالا بیایند
					.ToList();

				return query;
			}
			catch (System.Exception)
			{
				throw;
			}
			finally
			{
				if (databaseContext != null)
				{
					databaseContext.Dispose();
					databaseContext = null;
				}
			}
		}

		// **********
		public Models.Contract GetContractById(System.Guid contractId)
		{
			Models.DatabaseContext databaseContext = null;
			try
			{
				databaseContext = new Models.DatabaseContext();

				// بارگذاری گراف کامل قرارداد
				// 💥 تغییر مهم: به جای Product، حالا CustomerAsset را Include می‌کنیم 
				// و حتی به EF می‌گوییم Productِ داخلِ CustomerAsset را هم با خودش بیاورد!
				Models.Contract contract = databaseContext.Contracts
					.Include(current => current.Customer)
					.Include(current => current.Invoice)
					.Include(current => current.ContractItems.Select(item => item.CustomerAsset.Product)) // 👈 این خط اصلاح شد
					.Where(current => current.Id == contractId)
					.FirstOrDefault();

				return contract;
			}
			catch (System.Exception)
			{
				throw;
			}
			finally
			{
				if (databaseContext != null)
				{
					databaseContext.Dispose();
					databaseContext = null;
				}
			}
		}

		// **********
		public void CreateContract(Models.Contract contract)
		{
			Models.DatabaseContext databaseContext = null;
			try
			{
				databaseContext = new Models.DatabaseContext();
				databaseContext.Contracts.Add(contract);
				databaseContext.SaveChanges();
			}
			catch (System.Data.Entity.Validation.DbEntityValidationException ex)
			{
				throw new System.Exception(GetValidationErrorMessage(ex));
			}
			catch (System.Exception)
			{
				throw;
			}
			finally
			{
				if (databaseContext != null)
				{
					databaseContext.Dispose();
					databaseContext = null;
				}
			}
		}

		// **********
		public void UpdateContract(Models.Contract contract)
		{
			Models.DatabaseContext databaseContext = null;
			try
			{
				databaseContext = new Models.DatabaseContext();

				var existingContract = databaseContext.Contracts
					.Include(c => c.ContractItems)
					.FirstOrDefault(c => c.Id == contract.Id);

				if (existingContract == null)
					throw new System.Exception("قرارداد مورد نظر یافت نشد.");

				databaseContext.Entry(existingContract).CurrentValues.SetValues(contract);

				// 1. حذف اقلام
				foreach (var existingItem in existingContract.ContractItems.ToList())
				{
					if (!contract.ContractItems.Any(c => c.Id == existingItem.Id))
						databaseContext.ContractItems.Remove(existingItem);
				}

				// 2. آپدیت و اضافه کردن اقلام
				foreach (var newItem in contract.ContractItems)
				{
					var existingItem = existingContract.ContractItems.FirstOrDefault(i => i.Id == newItem.Id);

					if (existingItem != null)
					{
						databaseContext.Entry(existingItem).CurrentValues.SetValues(newItem);
					}
					else
					{
						existingContract.ContractItems.Add(newItem);
					}
				}

				databaseContext.SaveChanges();
			}
			catch (System.Data.Entity.Validation.DbEntityValidationException ex)
			{
				throw new System.Exception(GetValidationErrorMessage(ex));
			}
			catch (System.Exception)
			{
				throw;
			}
			finally
			{
				if (databaseContext != null)
				{
					databaseContext.Dispose();
					databaseContext = null;
				}
			}
		}

		// **********
		public void DeleteContract(System.Guid contractId)
		{
			Models.DatabaseContext databaseContext = null;
			try
			{
				databaseContext = new Models.DatabaseContext();

				Models.Contract contract = databaseContext.Contracts.FirstOrDefault(i => i.Id == contractId);

				if (contract != null)
				{
					databaseContext.Contracts.Remove(contract);
					databaseContext.SaveChanges();
				}
			}
			catch (System.Data.Entity.Validation.DbEntityValidationException ex)
			{
				throw new System.Exception(GetValidationErrorMessage(ex));
			}
			catch (System.Exception)
			{
				throw;
			}
			finally
			{
				if (databaseContext != null)
				{
					databaseContext.Dispose();
					databaseContext = null;
				}
			}
		}

		// **********
		private string GetValidationErrorMessage(System.Data.Entity.Validation.DbEntityValidationException ex)
		{
			string errorMessage = string.Empty;
			foreach (var entityValidationErrors in ex.EntityValidationErrors)
			{
				foreach (var validationError in entityValidationErrors.ValidationErrors)
				{
					errorMessage += $"Entity: {entityValidationErrors.Entry.Entity.GetType().Name}, Property: {validationError.PropertyName}, Errors: {validationError.ErrorMessage}" + System.Environment.NewLine;
				}
			}
			return errorMessage;
		}
	}
}
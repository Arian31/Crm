using System.Linq;
using System.Data.Entity;

namespace DAL
{
	public class CustomerRepository : object, ICustomerRepository
	{
		public CustomerRepository() : base()
		{
		}

		// **********
		public bool HasPerson(System.Guid personId)
		{
			Models.DatabaseContext databaseContext = null;
			try
			{
				databaseContext = new Models.DatabaseContext();
				bool hasAny = databaseContext.Customers.Any(current => current.PersonId == personId);
				return hasAny;
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
		public System.Collections.Generic.List<Models.Customer> GetPagedCustomers(string filterText, int pageIndex, int pageSize, out int totalRecords)
		{
			Models.DatabaseContext databaseContext = null;
			try
			{
				databaseContext = new Models.DatabaseContext();
				var query = databaseContext.Customers.Include(current => current.Person).AsQueryable();

				if (string.IsNullOrWhiteSpace(filterText) == false)
				{
					string filter = filterText.Trim();
					query = query.Where(current => current.FullName.Contains(filter));
				}

				totalRecords = query.Count();

				var customers =
					query
					.OrderByDescending(current => current.Code)
					.Skip((pageIndex - 1) * pageSize)
					.Take(pageSize)
					.ToList();

				return customers;
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
		public Models.Customer GetCustomerById(System.Guid customerId)
		{
			Models.DatabaseContext databaseContext = null;
			try
			{
				databaseContext = new Models.DatabaseContext();
				Models.Customer customer =
					databaseContext.Customers
					.Where(current => current.Id == customerId)
					.Include(current => current.Person)
					.FirstOrDefault();

				return customer;
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
		public void CreateCustomer(System.Guid? personId, string fullName, string nationalCode, string email, string economicCode, string phone, string address)
		{
			Models.DatabaseContext databaseContext = null;
			try
			{
				databaseContext = new Models.DatabaseContext();
				Models.Customer customer = new Models.Customer()
				{
					PersonId = personId,
					FullName = fullName,
					NationalCode = nationalCode,
					Email = email,
					EconomicCode = economicCode,
					Phone = phone,
					Address = address
				};

				databaseContext.Entry(customer).State = System.Data.Entity.EntityState.Added;
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
		public void ModifyCustomer(System.Guid id, string fullName, string nationalCode, string email, string economicCode, string phone, string address, System.Guid? personId)
		{
			Models.DatabaseContext databaseContext = null;
			try
			{
				databaseContext = new Models.DatabaseContext();
				Models.Customer theCustomer = new Models.Customer
				{
					Id = id,
					FullName = fullName,
					NationalCode = nationalCode,
					Email = email,
					EconomicCode = economicCode,
					Phone = phone,
					Address = address,
					PersonId = personId
				};

				databaseContext.Entry(theCustomer).State = System.Data.Entity.EntityState.Modified;
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
		public void DeleteCustomer(System.Guid id)
		{
			Models.DatabaseContext databaseContext = null;
			try
			{
				databaseContext = new Models.DatabaseContext();
				Models.Customer theCustomer = new Models.Customer();
				theCustomer.Id = id;

				databaseContext.Entry(theCustomer).State = System.Data.Entity.EntityState.Deleted;
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

		// **********

		/// <summary>
		/// دریافت لیست مشتریان مرتبط با یک شخص خاص بر اساس شناسه شخص.
		/// </summary>
		/// <param name="personId">شناسه شخص</param>
		/// <returns>لیستی از مشتریان مرتبط با شخص</returns>
		public System.Collections.Generic.List<Models.Customer> GetCustomersByPersonId(System.Guid personId)
		{
			Models.DatabaseContext databaseContext = null;
			try
			{
				databaseContext = new Models.DatabaseContext();

				var customers =
					databaseContext.Customers
					.Where(current => current.PersonId == personId)
					.ToList()
					;

				return customers;
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

		// **********
		public System.Collections.Generic.List<Models.CustomerAsset> GetCustomerAssets(System.Guid customerId)
		{
			Models.DatabaseContext databaseContext = null;
			try
			{
				databaseContext = new Models.DatabaseContext();

				// واکشی لایسنس‌های فعالِ این مشتری همراه با نام نرم‌افزار
				//var assets = databaseContext.CustomerAssets
				//	.Include(a => a.Product) // برای نمایش نام نرم‌افزار در فرم
				//	.Where(a => a.CustomerId == customerId && a.IsActive == true)
				//	.ToList();

				var assets = databaseContext.CustomerAssets
			.Include(a => a.Product)      // برای نام نرم‌افزار
			.Include(a => a.Customer)     // اگر جایی نام مشتری لازم شد
			.Include(a => a.Invoice)      // برای جلوگیری از Lazy Loading بعد از Dispose
			.Where(a => a.CustomerId == customerId && a.IsActive)
			.ToList();

				return assets;
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

	}
}
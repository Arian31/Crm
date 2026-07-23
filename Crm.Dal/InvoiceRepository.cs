using System.Linq;
using System.Data.Entity;
using System;

namespace DAL
{
	public class InvoiceRepository : object, IInvoiceRepository
	{
		public InvoiceRepository() : base()
		{
		}

		// **********
		public bool IsSerialNumberExist(int serialNumber, System.Guid? excludeInvoiceId = null)
		{
			Models.DatabaseContext databaseContext = null;
			try
			{
				databaseContext = new Models.DatabaseContext();

				var query = databaseContext.Invoices.Where(current => current.SerialNumber == serialNumber);

				// اگر در حالت ویرایش هستیم، شماره سریال فعلی خودش را به عنوان تکراری در نظر نمی‌گیرد
				if (excludeInvoiceId.HasValue)
				{
					query = query.Where(current => current.Id != excludeInvoiceId.Value);
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
		//public System.Collections.Generic.List<Models.Invoice> GetPagedInvoices(string filterText, int pageIndex, int pageSize, out int totalRecords)
		//{
		//	Models.DatabaseContext databaseContext = null;
		//	try
		//	{
		//		databaseContext = new Models.DatabaseContext();

		//		// واکشی فاکتورها به همراه مشتری (برای نمایش نام مشتری در لیست)
		//		// و همچنین واکشی اقلام (InvoiceItems) برای محاسبه جمع کل در گریدویو
		//		var query = databaseContext.Invoices
		//			.Include(current => current.Customer)
		//			.Include(current => current.InvoiceItems) // اضافه شده تا مبالغ در لیست درست حساب شود
		//			.AsQueryable();

		//		if (string.IsNullOrWhiteSpace(filterText) == false)
		//		{
		//			string filter = filterText.Trim();
		//			query = query.Where(current => current.Customer.FullName.Contains(filter) || current.Description.Contains(filter));
		//		}

		//		totalRecords = query.Count();

		//		return query
		//			.OrderByDescending(current => current.SerialNumber)
		//			.Skip((pageIndex - 1) * pageSize)
		//			.Take(pageSize)
		//			.ToList();
		//	}
		//	catch (System.Exception)
		//	{
		//		throw;
		//	}
		//	finally
		//	{
		//		if (databaseContext != null)
		//		{
		//			databaseContext.Dispose();
		//			databaseContext = null;
		//		}
		//	}
		//}

		// **********
		public Models.Invoice GetInvoiceById(System.Guid invoiceId)
		{
			Models.DatabaseContext databaseContext = null;
			try
			{
				databaseContext = new Models.DatabaseContext();

				// بارگذاری کامل گراف فاکتور (Eager Loading)
				Models.Invoice invoice = databaseContext.Invoices
					.Include(current => current.Customer)
					.Include(current => current.InvoiceItems.Select(item => item.Product))
					.Where(current => current.Id == invoiceId)
					.FirstOrDefault();

				return invoice;
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
		public void CreateInvoice(Models.Invoice invoice)
		{
			Models.DatabaseContext databaseContext = null;
			try
			{
				databaseContext = new Models.DatabaseContext();

				// 💥 جادوی معماری: تولید اتوماتیک دارایی‌ها (Assets) 💥
				// به ازای هر کالایی که در فاکتور فروخته شده، یک لایسنس برای مشتری می‌سازیم
				invoice.CustomerAssets = new System.Collections.Generic.List<Models.CustomerAsset>();

				foreach (var item in invoice.InvoiceItems)
				{
					// اگر کاربر در یک سطر تعداد 2 عدد زده باشد، ما 2 تا لایسنس مجزا می‌سازیم!
					for (int i = 0; i < item.Quantity; i++)
					{
						invoice.CustomerAssets.Add(new Models.CustomerAsset
						{
							Id = Guid.NewGuid(),
							CustomerId = invoice.CustomerId,
							ProductId = item.ProductId,
							IsActive = true,
							// سریال و نام سیستم بعداً توسط نصاب/پشتیبان پر می‌شود
							SoftwareSerial = string.Empty,
							ComputerName = string.Empty
						});
					}
				}

				databaseContext.Invoices.Add(invoice);
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
		public void UpdateInvoice(Models.Invoice invoice)
		{
			Models.DatabaseContext databaseContext = null;
			try
			{
				databaseContext = new Models.DatabaseContext();

				// واکشی فاکتور قدیمی و سطرهای آن از دیتابیس
				var existingInvoice = databaseContext.Invoices
					.Include(i => i.InvoiceItems)
					.FirstOrDefault(i => i.Id == invoice.Id);

				if (existingInvoice == null)
					throw new System.Exception("فاکتور مورد نظر یافت نشد.");

				// آپدیت فیلدهای هدر (شامل فیلد جدید TotalDiscount)
				databaseContext.Entry(existingInvoice).CurrentValues.SetValues(invoice);

				// مدیریت سطرها (حذف، آپدیت، اضافه)

				// 1. سطرهایی که در فرم حذف شده‌اند را از دیتابیس پاک می‌کنیم
				foreach (var existingItem in existingInvoice.InvoiceItems.ToList())
				{
					if (!invoice.InvoiceItems.Any(c => c.Id == existingItem.Id))
						databaseContext.InvoiceItems.Remove(existingItem);
				}

				// 2. سطرهای آپدیت شده و سطرهای جدید را اعمال می‌کنیم
				foreach (var newItem in invoice.InvoiceItems)
				{
					var existingItem = existingInvoice.InvoiceItems.FirstOrDefault(i => i.Id == newItem.Id);

					if (existingItem != null)
					{
						// آپدیت سطر موجود (شامل فیلدهای جدید مثل DiscountAmount و TaxAmount)
						databaseContext.Entry(existingItem).CurrentValues.SetValues(newItem);
					}
					else
					{
						// ثبت سطر جدیدی که کاربر به فاکتور قبلی اضافه کرده است
						existingInvoice.InvoiceItems.Add(newItem);
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
		public void DeleteInvoice(System.Guid invoiceId)
		{
			Models.DatabaseContext databaseContext = null;
			try
			{
				databaseContext = new Models.DatabaseContext();

				Models.Invoice invoice = databaseContext.Invoices.FirstOrDefault(i => i.Id == invoiceId);

				if (invoice != null)
				{
					// حذف کامل هدر فاکتور (Cascade Delete باعث حذف InvoiceItems می‌شود)
					databaseContext.Invoices.Remove(invoice);
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

		// **********

		// **********
		public System.Collections.Generic.List<Models.Invoice> SearchInvoices(string serialFilter, string customerFilter, string sortBy)
		{
			Models.DatabaseContext databaseContext = null;
			try
			{
				databaseContext = new Models.DatabaseContext();

				// واکشی فاکتورها همراه با مشتری و اقلام (برای محاسبه جمع کل)
				var query = databaseContext.Invoices
					.Include(current => current.Customer)
					.Include(current => current.InvoiceItems)
					.AsQueryable();

				// فیلتر مشتری
				if (string.IsNullOrWhiteSpace(customerFilter) == false)
				{
					string cFilter = customerFilter.Trim();
					query = query.Where(current => current.Customer.FullName.Contains(cFilter));
				}

				// فیلتر سریال
				if (string.IsNullOrWhiteSpace(serialFilter) == false)
				{
					// چون سریال int است و کاربر string وارد کرده، سعی می‌کنیم تبدیل کنیم
					if (int.TryParse(serialFilter.Trim(), out int serialNumber))
					{
						query = query.Where(current => current.SerialNumber == serialNumber);
					}
				}

				// مرتب‌سازی بر اساس انتخاب کاربر
				if (sortBy == "Serial")
				{
					query = query.OrderByDescending(current => current.SerialNumber);
				}
				else // پیش‌فرض Date است
				{
					query = query.OrderByDescending(current => current.Date)
								 .ThenByDescending(current => current.SerialNumber);
				}

				// اجرای کوئری و برگرداندن لیست خام (تبدیل به ViewModel در فرم انجام می‌شود)
				return query.ToList();
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
		public int GetNextSerialNumber()
		{
			Models.DatabaseContext databaseContext = null;
			try
			{
				databaseContext = new Models.DatabaseContext();

				// اگر فاکتوری وجود داشت، بزرگترین سریال را بگیر و یکی اضافه کن
				if (databaseContext.Invoices.Any())
				{
					return databaseContext.Invoices.Max(current => current.SerialNumber) + 1;
				}

				// اگر دیتابیس خالی بود، از شماره 1 شروع کن
				return 1;
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
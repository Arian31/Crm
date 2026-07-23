using System.Linq;
using System.Reflection;

namespace DAL
{
	/// <summary>
	/// کلاس ارتباط با دیتابیس برای موجودیت کالا
	/// تمام عملیات CRUD (ثبت، خواندن، ویرایش و حذف) مربوط به کالا در این کلاس انجام می‌شود
	/// </summary>
	public class CommodityRepository : object, ICommodityRepository
	{
		// **********
		/// <summary>
		/// متد سازنده کلاس
		/// </summary>
		public CommodityRepository() : base()
		{
		}
		// **********

		// **********
		/// <summary>
		/// دریافت لیست کالاها همراه با قابلیت جستجو
		/// </summary>
		/// <param name="filterText">متنی که کاربر برای جستجو وارد می‌کند (نام یا کد کالا)</param>
		/// <returns>لیستی از کالاها</returns>
		public System.Collections.Generic.List<Models.Commodity> GetCommodities(string filterText = null)
		{
			Models.DatabaseContext databaseContext = null;
			try
			{
				// وهله‌سازی از کانتکست دیتابیس
				databaseContext =
					new Models.DatabaseContext();

				// ایجاد یک کوئری پایه روی جدول کالاها
				var query =
					databaseContext.Commodities
					.AsQueryable()
					;

				// اگر کاربر متنی برای جستجو وارد کرده بود، فیلتر را اعمال می‌کنیم
				if (string.IsNullOrWhiteSpace(filterText) == false)
				{
					string filter = filterText.Trim();
					query =
						query
						.Where(current => current.Name.Contains(filter)
									   || current.Code.Contains(filter))
						;
				}

				// مرتب‌سازی و دریافت اطلاعات از دیتابیس (تبدیل به لیست)
				// نکته: مرتب‌سازی را بر اساس کد به صورت نزولی و سپس نام قرار دادیم
				var commodities =
					query
					.OrderByDescending(current => current.Code)
					.ThenBy(current => current.Name)
					.ToList()
					;

				return commodities;
			}
			catch (System.Exception)
			{
				// ارسال خطا به لایه بالاتر (فرم)
				throw;
			}
			finally
			{
				// آزادسازی منابع دیتابیس در هر صورت (چه موفق چه خطا)
				if (databaseContext != null)
				{
					databaseContext.Dispose();
					databaseContext = null;
				}
			}
		}
		// **********

		// **********
		/// <summary>
		/// دریافت اطلاعات فقط یک کالا بر اساس شناسه (Id)
		/// </summary>
		public Models.Commodity GetCommodityById(System.Guid commodityId)
		{
			Models.DatabaseContext databaseContext = null;
			try
			{
				databaseContext =
					new Models.DatabaseContext();

				// واکشی اولین کالایی که شناسه آن با شناسه ورودی برابر است
				Models.Commodity commodity =
					databaseContext.Commodities
					.Where(current => current.Id == commodityId)
					.FirstOrDefault()
					;

				return commodity;
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
		/// <summary>
		/// ثبت کالای جدید در دیتابیس
		/// </summary>
		public void CreateCommodity(string code, string name, decimal defaultPrice, bool isTaxable, decimal taxPercentage)
		{
			Models.DatabaseContext databaseContext = null;
			try
			{
				databaseContext =
					new Models.DatabaseContext();

				// ایجاد یک شیء جدید از مدل کالا و مقداردهی آن
				Models.Commodity commodity = new Models.Commodity()
				{
					Code = code,
					Name = name,
					DefaultPrice = defaultPrice,
					IsTaxable = isTaxable,
					TaxPercentage = taxPercentage,
				};

				// استفاده از روش بهینه EntityState برای ثبت رکورد
				databaseContext.Entry(commodity).State =
					System.Data.Entity.EntityState.Added;

				// ذخیره تغییرات در دیتابیس
				databaseContext.SaveChanges();
			}
			catch (System.Data.Entity.Validation.DbEntityValidationException ex)
			{
				// تبدیل خطای دیتابیس به یک خطای خوانا برای کاربر
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

		// **********
		/// <summary>
		/// ویرایش اطلاعات کالای موجود
		/// </summary>
		public void EditCommodity(System.Guid commodityId, string code, string name, decimal defaultPrice, bool isTaxable, decimal taxPercentage)
		{
			Models.DatabaseContext databaseContext = null;
			try
			{
				databaseContext =
					new Models.DatabaseContext();

				// استفاده از روش Stub Entity (بدون نیاز به Select زدن اضافی) برای افزایش سرعت ویرایش
				Models.Commodity commodity = new Models.Commodity()
				{
					Id = commodityId,
					Code = code,
					Name = name,
					DefaultPrice = defaultPrice,
					IsTaxable = isTaxable,
					TaxPercentage = taxPercentage,
				};

				// به EF می‌گوییم که این رکورد از قبل وجود دارد و الان تغییر کرده است
				databaseContext.Entry(commodity).State =
					System.Data.Entity.EntityState.Modified;

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

		// **********
		/// <summary>
		/// حذف کالا از دیتابیس
		/// </summary>
		public void DeleteCommodity(System.Guid commodityId)
		{
			Models.DatabaseContext databaseContext = null;
			try
			{
				databaseContext =
					new Models.DatabaseContext();

				// ایجاد یک نمونه خالی فقط با ID برای حذف سریع (بدون نیاز به واکشی رکورد)
				Models.Commodity commodity = new Models.Commodity();
				commodity.Id = commodityId;

				// تغییر وضعیت به Deleted برای حذف رکورد در زمان SaveChanges
				databaseContext.Entry(commodity).State =
					System.Data.Entity.EntityState.Deleted;

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

		// **********
		/// <summary>
		/// متد کمکی (Private) برای استخراج متن خطاهای ولیدیشن Entity Framework
		/// </summary>
		private string GetValidationErrorMessage(System.Data.Entity.Validation.DbEntityValidationException ex)
		{
			string errorMessage = string.Empty;
			foreach (var entityValidationErrors in ex.EntityValidationErrors)
			{
				foreach (var validationError in entityValidationErrors.ValidationErrors)
				{
					errorMessage += $"Entity: {entityValidationErrors.Entry.Entity.GetType().Name}, " +
									$"Property: {validationError.PropertyName}, " +
									$"Errors: {validationError.ErrorMessage}" + System.Environment.NewLine;
				}
			}
			return errorMessage;
		}
		// **********
	}
}
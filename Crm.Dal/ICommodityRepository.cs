namespace DAL
{
	/// <summary>
	/// قرارداد (Interface) برای ریپوزیتوری کالاها
	/// </summary>
	public interface ICommodityRepository
	{
		// **********
		/// <summary>
		/// دریافت لیست کالاها همراه با قابلیت جستجو
		/// </summary>
		System.Collections.Generic.List<Models.Commodity> GetCommodities(string filterText = null);
		// **********

		// **********
		/// <summary>
		/// دریافت اطلاعات فقط یک کالا بر اساس شناسه (Id)
		/// </summary>
		Models.Commodity GetCommodityById(System.Guid commodityId);
		// **********

		// **********
		/// <summary>
		/// ثبت کالای جدید در دیتابیس
		/// </summary>
		void CreateCommodity(string code, string name, decimal defaultPrice, bool isTaxable, decimal taxPercentage);
		// **********

		// **********
		/// <summary>
		/// ویرایش اطلاعات کالای موجود
		/// </summary>
		void EditCommodity(System.Guid commodityId, string code, string name, decimal defaultPrice, bool isTaxable, decimal taxPercentage);
		// **********

		// **********
		/// <summary>
		/// حذف کالا از دیتابیس
		/// </summary>
		void DeleteCommodity(System.Guid commodityId);
		// **********
	}
}
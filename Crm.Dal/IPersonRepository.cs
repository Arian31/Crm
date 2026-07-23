namespace DAL
{
	/// <summary>
	/// قرارداد (Interface) برای ریپوزیتوری اشخاص
	/// لایه رابط کاربری فقط با این قرارداد کار می‌کند و از کدهای Entity Framework بی‌خبر است
	/// </summary>
	public interface IPersonRepository
	{
		// **********
		/// <summary>
		/// دریافت لیست اشخاص همراه با قابلیت جستجو بر اساس نام و نام خانوادگی
		/// </summary>
		System.Collections.Generic.List<Models.Person> GetPeople(string filterText = null);
		// **********

		// **********
		/// <summary>
		/// دریافت اطلاعات فقط یک شخص بر اساس شناسه (Id)
		/// </summary>
		Models.Person GetPersonById(System.Guid personId);
		// **********

		// **********
		/// <summary>
		/// ثبت شخص جدید در دیتابیس
		/// </summary>
		void CreatePerson(string firstName, string lastName, string phone, string email, System.DateTime birthDate, Models.Person.GenderType gender);
		// **********

		// **********
		/// <summary>
		/// ویرایش اطلاعات شخص موجود
		/// </summary>
		void EditPerson(System.Guid personId, string firstName, string lastName, string phone, string email, System.DateTime birthDate, Models.Person.GenderType gender);
		// **********

		// **********
		/// <summary>
		/// حذف شخص از دیتابیس
		/// </summary>
		void DeletePerson(System.Guid personId);
		// **********

		// **********
		/// <summary>
		/// جستجوی پیشرفته اشخاص بر اساس چندین فیلتر مختلف
		/// </summary>
		System.Collections.Generic.List<Models.Person> SearchPeople(string firstName, string lastName, string email, Models.Person.GenderType? gender);
		// **********
	}
}
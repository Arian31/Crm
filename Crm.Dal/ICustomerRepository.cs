namespace DAL
{
	/// <summary>
	/// قرارداد (Interface) برای ریپوزیتوری مشتری
	/// لایه رابط کاربری فقط با این قرارداد کار می‌کند و از کدهای داخل آن بی‌خبر است
	/// </summary>
	public interface ICustomerRepository
	{
		bool HasPerson(System.Guid personId);

		// نکته: خروجی این متد از نوع Models است، چون DAL نباید چیزی از ViewModel بداند
		System.Collections.Generic.List<Models.Customer> GetPagedCustomers(string filterText, int pageIndex, int pageSize, out int totalRecords);

		Models.Customer GetCustomerById(System.Guid customerId);

		void CreateCustomer(System.Guid? personId, string fullName, string nationalCode, string email, string economicCode, string phone, string address);

		void ModifyCustomer(System.Guid id, string fullName, string nationalCode, string email, string economicCode, string phone, string address, System.Guid? personId);

		void DeleteCustomer(System.Guid id);

		/// <summary>
		/// دریافت لیست مشتریان مرتبط با یک شخص خاص بر اساس شناسه شخص.
		/// </summary>
		/// <param name="personId">شناسه شخص</param>
		/// <returns>لیستی از مشتریان مرتبط با شخص</returns>
		System.Collections.Generic.List<Models.Customer> GetCustomersByPersonId(System.Guid personId);
		// **********

	}
}
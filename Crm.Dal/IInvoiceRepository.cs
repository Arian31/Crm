namespace DAL
{
	public interface IInvoiceRepository
	{
		// **********
		/// <summary>
		/// بررسی تکراری بودن شماره سریال فاکتور
		/// </summary>
		/// <param name="excludeInvoiceId">در حالت ویرایش، شناسه فاکتور جاری را مستثنی می‌کند</param>
		bool IsSerialNumberExist(int serialNumber, System.Guid? excludeInvoiceId = null);
		// **********

		// **********
		/// <summary>
		/// دریافت لیست فاکتورها (معمولاً برای فرم لیست فاکتورها استفاده می‌شود)
		/// </summary>
		//System.Collections.Generic.List<Models.Invoice> GetPagedInvoices(string filterText, int pageIndex, int pageSize, out int totalRecords);
		System.Collections.Generic.List<Models.Invoice> SearchInvoices(string serialFilter, string customerFilter, string sortBy);
		// **********

		// **********
		/// <summary>
		/// واکشی یک فاکتور با تمام جزئیاتش (هدر، اقلام، نام مشتری و نام کالاها)
		/// </summary>
		Models.Invoice GetInvoiceById(System.Guid invoiceId);
		// **********

		// **********
		/// <summary>
		/// ثبت فاکتور جدید همراه با تمام اقلام آن
		/// </summary>
		void CreateInvoice(Models.Invoice invoice);
		// **********

		// **********
		/// <summary>
		/// ویرایش فاکتور و اقلام آن
		/// </summary>
		void UpdateInvoice(Models.Invoice invoice);
		// **********

		// **********
		/// <summary>
		/// حذف کامل یک فاکتور و اقلام آن
		/// </summary>
		void DeleteInvoice(System.Guid invoiceId);
		// **********

		// **********
		/// <summary>
		/// دریافت شماره سریال بعدی (بزرگترین سریال موجود + 1)
		/// </summary>
		int GetNextSerialNumber();
		// **********

	}
}
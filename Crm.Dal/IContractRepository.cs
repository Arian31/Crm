namespace DAL
{
	public interface IContractRepository
	{
		// **********
		/// <summary>
		/// بررسی تکراری بودن شماره قرارداد
		/// </summary>
		bool IsContractNumberExist(string contractNumber, System.Guid? excludeContractId = null);
		// **********

		// **********
		/// <summary>
		/// دریافت لیست قراردادها (برای نمایش در گریدویو لیست قراردادها)
		/// </summary>
		System.Collections.Generic.List<Models.Contract> GetPagedContracts(string filterText, int pageIndex, int pageSize, out int totalRecords);
		// **********

		// **********
		/// <summary>
		/// گزارش مهم: دریافت قراردادهایی که در حال انقضا هستند (مثلا در 30 روز آینده)
		/// </summary>
		System.Collections.Generic.List<Models.Contract> GetExpiringContracts(int daysToWarn);
		// **********

		// **********
		/// <summary>
		/// واکشی یک قرارداد با تمام جزئیاتش (هدر، مشتری، فاکتور، و اقلام)
		/// </summary>
		Models.Contract GetContractById(System.Guid contractId);
		// **********

		// **********
		/// <summary>
		/// ثبت قرارداد جدید همراه با اقلام آن
		/// </summary>
		void CreateContract(Models.Contract contract);
		// **********

		// **********
		/// <summary>
		/// ویرایش قرارداد و اقلام آن
		/// </summary>
		void UpdateContract(Models.Contract contract);
		// **********

		// **********
		/// <summary>
		/// حذف قرارداد
		/// </summary>
		void DeleteContract(System.Guid contractId);
		// **********
	}
}
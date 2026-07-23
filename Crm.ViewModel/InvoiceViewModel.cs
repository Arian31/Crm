namespace ViewModels
{
	public class InvoiceViewModel : object
	{
		public InvoiceViewModel() : base()
		{
		}

		[System.ComponentModel.Browsable(false)] // آیدی مخفی است
		public System.Guid Id { get; set; }

		[System.ComponentModel.DisplayName("سریال فاکتور")]
		public int SerialNumber { get; set; }

		[System.ComponentModel.DisplayName("تاریخ فاکتور")]
		public string DateJalali { get; set; } // از نوع String برای نمایش شمسی

		[System.ComponentModel.DisplayName("مشتری")]
		public string CustomerName { get; set; }

		[System.ComponentModel.DisplayName("مبلغ نهایی (تومان)")]
		public string FinalAmount { get; set; } // از نوع String برای فرمت ۳ رقم ۳ رقم

		[System.ComponentModel.DisplayName("توضیحات")]
		public string Description { get; set; }
	}
}
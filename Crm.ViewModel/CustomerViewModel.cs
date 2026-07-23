using System.ComponentModel;


namespace ViewModel
{
	public class CustomerViewModel
	{
		[DisplayName("شناسه")]
		public System.Guid Id { get; set; }

		[DisplayName("کد مشتری")]
		public int Code { get; set; }

		[DisplayName("نام کامل شخص")]
		public string FullName { get; set; }

		[DisplayName("نام مشتری")]
		public string CustomerName { get; set; }

		[DisplayName("تلفن")]
		public string Phone { get; set; }

		[DisplayName("ایمیل")]
		public string Email { get; set; }
	}
}

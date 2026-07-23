namespace Models
{
	[System.ComponentModel.DataAnnotations.Schema.Table(name: "Products", Schema = "Inv")]
	public class Commodity : BaseEntity
	{
		#region Configuration
		internal class Configuration :
			System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Commodity>
		{
			internal Configuration() : base()
			{
				Property(current => current.Code)
					.HasColumnName("Code")
					.IsUnicode(true)
					.HasMaxLength(20)
					.IsFixedLength()
					.IsRequired()
					;

				Property(current => current.Name)
					.HasColumnName("Name")
					.IsUnicode(true)
					.HasMaxLength(100) // نام محصول معمولاً طولانی‌تر است
					.IsVariableLength()
					.IsRequired()
					;

				// ********** تنظیمات جدید مالی **********
				Property(current => current.DefaultPrice)
					.HasColumnName("DefaultPrice")
					.HasPrecision(18, 4) // استاندارد مالی
					.IsRequired()
					;

				Property(current => current.IsTaxable)
					.HasColumnName("IsTaxable")
					.IsRequired()
					;

				Property(current => current.TaxPercentage)
					.HasColumnName("TaxPercentage")
					.HasPrecision(5, 2) // برای درصد مالیات (مثلا 9.00)
					.IsRequired()
					;
				// ***************************************
			}
		}
		#endregion

		public Commodity() : base()
		{
			InvoiceItems = new System.Collections.Generic.List<InvoiceItem>();

			// مقادیر پیش‌فرض برای زمان ثبت محصول جدید
			DefaultPrice = 0;
			IsTaxable = true; // معمولاً اکثر کالاها مشمول مالیات هستند
			TaxPercentage = 10; // مالیات پیش‌فرض ایران
		}

		[System.ComponentModel.DisplayName(displayName: "کد محصول")]
		public string Code { get; set; }

		[System.ComponentModel.DisplayName(displayName: "نام محصول")]
		public string Name { get; set; }

		// ********** فیلدهای جدید **********
		[System.ComponentModel.DisplayName(displayName: "مبلغ پیش‌فرض")]
		public decimal DefaultPrice { get; set; }

		[System.ComponentModel.DisplayName(displayName: "مشمول مالیات؟")]
		public bool IsTaxable { get; set; }


		[System.ComponentModel.DisplayName(displayName: "درصد مالیات")]
		//[System.ComponentModel.DataAnnotations.StringLength
		//	(maximumLength: 100,MinimumLength = 0)]
		public decimal TaxPercentage { get; set; }
		// **********************************

		public virtual System.Collections.Generic.List<InvoiceItem> InvoiceItems { get; set; }
	}
}
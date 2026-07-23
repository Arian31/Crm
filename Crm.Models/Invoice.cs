using System.Linq;

namespace Models
{
	[System.ComponentModel.DataAnnotations.Schema.Table(name: "Invoices", Schema = "Crm")]
	public class Invoice : BaseEntity
	{
		#region Configuration
		internal class Configuration :
			System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Invoice>
		{
			internal Configuration() : base()
			{
				Property(current => current.SerialNumber)
					.HasColumnName("SerialNumber")
					.IsRequired()
					.HasColumnAnnotation("Index", new System.Data.Entity.Infrastructure.Annotations.IndexAnnotation(
						new System.ComponentModel.DataAnnotations.Schema.IndexAttribute("IX_SerialNumber") { IsUnique = true }));

				Property(current => current.Date).HasColumnName("Date").HasColumnType("datetime2").IsRequired();

				// فیلد جدید برای تخفیف نهایی روی فاکتور
				Property(current => current.TotalDiscount).HasColumnName("TotalDiscount").HasPrecision(18, 4).IsRequired();

				Property(current => current.Description).HasColumnName("Description").IsUnicode(true).HasMaxLength(500).IsOptional();

				HasRequired(current => current.Customer)
					.WithMany(customer => customer.Invoices)
					.HasForeignKey(current => current.CustomerId)
					.WillCascadeOnDelete(false);
			}
		}
		#endregion

		public Invoice() : base()
		{

			InvoiceItems = new System.Collections.Generic.List<InvoiceItem>();

			CustomerAssets = new System.Collections.Generic.List<CustomerAsset>();

			TotalDiscount = 0; // پیش‌فرض بدون تخفیف کلی
		}

		public virtual System.Collections.Generic.List<CustomerAsset> CustomerAssets { get; set; }

		public int SerialNumber { get; set; }
		public System.DateTime Date { get; set; }

		// ********** فیلد جدید **********
		[System.ComponentModel.DisplayName(displayName: "تخفیف کل فاکتور")]
		public decimal TotalDiscount { get; set; }
		// *******************************

		public string Description { get; set; }

		public System.Guid CustomerId { get; set; }
		public virtual Customer Customer { get; set; }

		public virtual System.Collections.Generic.List<InvoiceItem> InvoiceItems { get; set; }

		// ********** پراپرتی‌های محاسباتی برای پایین فرم فاکتور **********

		[System.ComponentModel.DataAnnotations.Schema.NotMapped]
		[System.ComponentModel.DisplayName(displayName: "جمع مبالغ خام")]
		public decimal SubTotal // جمع قبل از کسر و اضافات
		{
			get { return InvoiceItems?.Sum(i => (i.Quantity * i.UnitPrice)) ?? 0; }
		}

		[System.ComponentModel.DataAnnotations.Schema.NotMapped]
		[System.ComponentModel.DisplayName(displayName: "جمع مالیات")]
		public decimal TotalTax
		{
			get { return InvoiceItems?.Sum(i => i.TaxAmount) ?? 0; }
		}

		[System.ComponentModel.DataAnnotations.Schema.NotMapped]
		[System.ComponentModel.DisplayName(displayName: "جمع کل تخفیفات")]
		public decimal SumOfAllDiscounts // جمع تخفیفات سطری + تخفیف کلی
		{
			get { return (InvoiceItems?.Sum(i => i.DiscountAmount) ?? 0) + TotalDiscount; }
		}

		[System.ComponentModel.DataAnnotations.Schema.NotMapped]
		[System.ComponentModel.DisplayName(displayName: "مبلغ نهایی فاکتور")]
		public decimal FinalAmount // مبلغ قابل پرداخت
		{
			get
			{
				// جمع مبالغ نهایی سطرها منهای تخفیف کلی روی فاکتور
				decimal itemsTotal = InvoiceItems?.Sum(i => i.RowTotalAmount) ?? 0;
				return itemsTotal - TotalDiscount;
			}
		}
		// *****************************************************************
	}
}
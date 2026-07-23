namespace Models
{
	[System.ComponentModel.DataAnnotations.Schema.Table(name: "InvoiceItems", Schema = "Crm")]
	public class InvoiceItem : BaseEntity
	{
		#region Configuration
		internal class Configuration :
			System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<InvoiceItem>
		{
			internal Configuration() : base()
			{
				Property(current => current.Quantity).HasColumnName("Quantity").IsRequired();
				Property(current => current.UnitPrice).HasColumnName("UnitPrice").HasPrecision(18, 4).IsRequired();

				// فیلد جدید تخفیف
				Property(current => current.DiscountAmount).HasColumnName("DiscountAmount").HasPrecision(18, 4).IsRequired();

				Property(current => current.TaxAmount).HasColumnName("TaxAmount").HasPrecision(18, 4).IsRequired();

				Property(current => current.Description).HasColumnName("Description").IsUnicode(true).HasMaxLength(250).IsOptional();

				HasRequired(current => current.Invoice)
					.WithMany(invoice => invoice.InvoiceItems)
					.HasForeignKey(current => current.InvoiceId)
					.WillCascadeOnDelete(true);

				HasRequired(current => current.Product)
					.WithMany(product => product.InvoiceItems)
					.HasForeignKey(current => current.ProductId)
					.WillCascadeOnDelete(false);
			}
		}
		#endregion

		public InvoiceItem() : base()
		{
			Quantity = 1;
			DiscountAmount = 0;
			TaxAmount = 0;
		}

		public decimal Quantity { get; set; }
		public decimal UnitPrice { get; set; }

		// ********** فیلد جدید **********
		[System.ComponentModel.DisplayName(displayName: "مبلغ تخفیف")]
		public decimal DiscountAmount { get; set; }
		// *******************************

		public decimal TaxAmount { get; set; }
		public string Description { get; set; }

		public System.Guid InvoiceId { get; set; }
		public virtual Invoice Invoice { get; set; }

		public System.Guid ProductId { get; set; }
		public virtual Commodity Product { get; set; }

		// ********** این دو پراپرتی را برای گول زدن گریدویو اضافه کنید **********
		[System.ComponentModel.DataAnnotations.Schema.NotMapped]
		public string ProductCode
		{
			get { return Product != null ? Product.Code : string.Empty; }
		}

		[System.ComponentModel.DataAnnotations.Schema.NotMapped]
		public string ProductName
		{
			get { return Product != null ? Product.Name : string.Empty; }
		}
		// *************************************************************************


		// ********** آپدیت فرمول محاسباتی **********
		[System.ComponentModel.DataAnnotations.Schema.NotMapped]
		[System.ComponentModel.DisplayName(displayName: "جمع کل سطر")]
		public decimal RowTotalAmount
		{
			get
			{
				// فرمول حسابداری: (مبلغ کل - تخفیف) + مالیات
				return ((Quantity * UnitPrice) - DiscountAmount) + TaxAmount;
			}
		}
		// ******************************************
	}
}
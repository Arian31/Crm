namespace Models
{
	[System.ComponentModel.DataAnnotations.Schema.Table(name: "CustomerAssets", Schema = "Crm")]
	public class CustomerAsset : BaseEntity
	{
		#region Configuration
		internal class Configuration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<CustomerAsset>
		{
			internal Configuration() : base()
			{
				Property(current => current.SoftwareSerial).HasColumnName("SoftwareSerial").IsUnicode(false).HasMaxLength(100).IsOptional();
				Property(current => current.ComputerName).HasColumnName("ComputerName").IsUnicode(true).HasMaxLength(150).IsOptional();
				Property(current => current.IsActive).HasColumnName("IsActive").IsRequired();

				// ارتباط با مشتری (صاحب لایسنس)
				HasRequired(current => current.Customer)
					.WithMany(c => c.CustomerAssets)
					.HasForeignKey(current => current.CustomerId)
					.WillCascadeOnDelete(false);

				// ارتباط با کالا (کدام نرم‌افزار است)
				HasRequired(current => current.Product)
					.WithMany()
					.HasForeignKey(current => current.ProductId)
					.WillCascadeOnDelete(false);

				// ارتباط با فاکتور (از کدام فاکتور تولید شده) - حذف آبشاری روشن است تا اگر فاکتور پاک شد، لایسنس هم پاک شود
				HasRequired(current => current.Invoice)
					.WithMany(i => i.CustomerAssets)
					.HasForeignKey(current => current.InvoiceId)
					.WillCascadeOnDelete(true);
			}
		}
		#endregion

		public CustomerAsset() : base()
		{
			IsActive = true;
		}

		public System.Guid CustomerId { get; set; }
		public virtual Customer Customer { get; set; }

		public System.Guid ProductId { get; set; }
		public virtual Commodity Product { get; set; }

		public System.Guid InvoiceId { get; set; }
		public virtual Invoice Invoice { get; set; }

		// سریال و نام کامپیوتر را از ContractItem به اینجا منتقل کردیم
		// چون سریال متعلق به خود لایسنس است، نه قراردادِ تمدیدِ آن!
		[System.ComponentModel.DisplayName("سریال نرم‌افزار / دانگل")]
		public string SoftwareSerial { get; set; }

		[System.ComponentModel.DisplayName("نام سیستم / سرور")]
		public string ComputerName { get; set; }

		[System.ComponentModel.DisplayName("فعال می‌باشد؟")]
		public bool IsActive { get; set; }
	}
}
namespace Models
{
	[System.ComponentModel.DataAnnotations.Schema.Table(name: "Contracts", Schema = "Crm")]
	public class Contract : BaseEntity
	{
		#region Configuration
		internal class Configuration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Contract>
		{
			internal Configuration() : base()
			{
				Property(current => current.ContractNumber)
					.HasColumnName("ContractNumber")
					.IsUnicode(true)
					.HasMaxLength(50)
					.IsRequired()
					.HasColumnAnnotation("Index", new System.Data.Entity.Infrastructure.Annotations.IndexAnnotation(
						new System.ComponentModel.DataAnnotations.Schema.IndexAttribute("IX_ContractNumber") { IsUnique = true }));

				Property(current => current.StartDate).HasColumnName("StartDate").HasColumnType("datetime2").IsRequired();
				Property(current => current.EndDate).HasColumnName("EndDate").HasColumnType("datetime2").IsRequired();

				// مبلغ توافق شده برای این قرارداد (در زمان گارانتی معمولاً 0 است)
				Property(current => current.ContractAmount).HasColumnName("ContractAmount").HasPrecision(18, 4).IsRequired();

				Property(current => current.Description).HasColumnName("Description").IsUnicode(true).HasMaxLength(500).IsOptional();

				// ارتباط یک به چند با مشتری
				HasRequired(current => current.Customer)
					.WithMany() // یک مشتری می‌تواند ده‌ها قرارداد داشته باشد
					.HasForeignKey(current => current.CustomerId)
					.WillCascadeOnDelete(false);

				// ارتباط یک به چند با فاکتور فروش مرجع
				//HasRequired(current => current.Invoice)
				HasOptional(current => current.Invoice) // <--- کلمه HasRequired به HasOptional تغییر کرد
					.WithMany() // یک فاکتور می‌تواند در سال‌های مختلف قراردادهای تمدید متعددی داشته باشد
					.HasForeignKey(current => current.InvoiceId)
					.WillCascadeOnDelete(false);
			}
		}
		#endregion

		public Contract() : base()
		{
			ContractItems = new System.Collections.Generic.List<ContractItem>();
			ContractAmount = 0;
			IsFreeWarranty = false;
		}

		// **********
		[System.ComponentModel.DisplayName("شماره قرارداد")]
		[System.ComponentModel.DataAnnotations.Required(ErrorMessage = "وارد کردن {0} الزامی است.")]
		[System.ComponentModel.DataAnnotations.StringLength(50, ErrorMessage = "طول {0} نمی‌تواند بیشتر از {1} کاراکتر باشد.")]
		public string ContractNumber { get; set; }
		// **********

		// **********
		[System.ComponentModel.DisplayName("تاریخ شروع")]
		[System.ComponentModel.DataAnnotations.Required(ErrorMessage = "وارد کردن {0} الزامی است.")]
		public System.DateTime StartDate { get; set; }
		// **********

		// **********
		[System.ComponentModel.DisplayName("تاریخ انقضا")]
		[System.ComponentModel.DataAnnotations.Required(ErrorMessage = "وارد کردن {0} الزامی است.")]
		public System.DateTime EndDate { get; set; }
		// **********

		// **********
		[System.ComponentModel.DisplayName("مبلغ قرارداد")]
		[System.ComponentModel.DataAnnotations.Required(ErrorMessage = "وارد کردن {0} الزامی است.")]
		public decimal ContractAmount { get; set; }
		// **********

		// **********
		[System.ComponentModel.DisplayName("گارانتی رایگان؟")]
		public bool IsFreeWarranty { get; set; } // اگر True باشد یعنی قرارداد سال اول است و رایگان
												 // **********

		// **********
		[System.ComponentModel.DisplayName("توضیحات")]
		[System.ComponentModel.DataAnnotations.StringLength(500, ErrorMessage = "طول {0} نباید بیشتر از {1} کاراکتر باشد.")]
		public string Description { get; set; }
		// **********

		// ********** روابط (Relations) **********
		[System.ComponentModel.DisplayName("مشتری")]
		[System.ComponentModel.DataAnnotations.Required(ErrorMessage = "انتخاب مشتری برای قرارداد الزامی است.")]
		public System.Guid CustomerId { get; set; }
		public virtual Customer Customer { get; set; }

		[System.ComponentModel.DisplayName("فاکتور مرجع")]
		//[System.ComponentModel.DataAnnotations.Required(ErrorMessage = "قرارداد باید به یک فاکتور فروش متصل باشد.")]
		public System.Guid? InvoiceId { get; set; }

		public virtual Invoice Invoice { get; set; }

		public virtual System.Collections.Generic.List<ContractItem> ContractItems { get; set; }
		// ***************************************

		// ********** پراپرتی محاسباتی برای داشبورد و آلارم **********
		[System.ComponentModel.DataAnnotations.Schema.NotMapped]
		[System.ComponentModel.DisplayName("روزهای مانده تا انقضا")]
		public int RemainingDays
		{
			get
			{
				var span = EndDate.Date - System.DateTime.Now.Date;
				return span.Days > 0 ? span.Days : 0; // اگر منقضی شده بود صفر برمی‌گرداند
			}
		}

		[System.ComponentModel.DataAnnotations.Schema.NotMapped]
		[System.ComponentModel.DisplayName("وضعیت قرارداد")]
		public string ContractStatus
		{
			get { return RemainingDays > 0 ? "فعال" : "منقضی شده"; }
		}
		// **********************************************************
	}
}
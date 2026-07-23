namespace Models
{

	public class Customer : BaseEntity
	{

		#region Configuration
		internal class Configuration :
			System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Customer>
		{
			/// <summary>
			/// Fluent Api
			/// </summary>
			internal Configuration() : base()
			{
				// Note: Attribute is better!
				ToTable(tableName: "Customers", schemaName: "Crm");

				// Note: Attribute is better!
				HasKey(current => current.Id);

				Property(current => current.Id)
				// Note: Attribute is better!
				.HasColumnName("Id")
				// Note: Attribute is better!
				.HasColumnOrder(0)
				// Note: Attribute is better!
				.IsRequired()
				;

				// Note: Attribute is better!
				Property(current => current.Code)
					.HasDatabaseGeneratedOption
					(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

				Property(current => current.PersonId)
					// Note: Attribute is better!
					.HasColumnName("Person_Id")
					// Note: Attribute is better!
					.HasColumnOrder(1)
					// Note: Attribute is better!
					.IsRequired()
					;
				// Note: Fluent Api is better!
				//NVarChar(x)
				Property(current => current.FullName)
					.HasColumnName("FullName")
					.IsUnicode(true)
					.HasMaxLength(75)
					.IsVariableLength()
					;

				Property(current => current.NationalCode)
					.HasColumnName("NationalCode")
					.IsUnicode(false)
					.HasMaxLength(10)
					.IsFixedLength()
					;

				Property(current => current.EconomicCode)
					.HasColumnName("EconomicCode")
					.IsUnicode(false)
					.HasMaxLength(10)
					.IsFixedLength()
					;

				Property(current => current.Email)
					.HasColumnName("Email")
					.IsUnicode(true)
					.HasMaxLength(50)
					.IsVariableLength()
					;

				Property(current => current.Phone)
					.HasColumnName("Phone")
					.IsUnicode(false)
					.HasMaxLength(20)
					.IsVariableLength()
					;


				// Note: Fluent Api is better!
				HasRequired(current => current.Person)
					.WithMany(customer => customer.Customers)
					.HasForeignKey(current => current.PersonId)
					.WillCascadeOnDelete(false);

			}
		}
		#endregion
		public Customer()
			: base()
		{
			// باعث می‌شود به محض ایجاد یک مشتری، لیست فاکتورهایش یک سبدِ خالی (اما آماده استفاده) باشد، نه یک سبدِ Null.
			Invoices = new System.Collections.Generic.List<Invoice>();
			CustomerAssets = new System.Collections.Generic.List<CustomerAsset>();

		}
		public virtual System.Collections.Generic.List<CustomerAsset> CustomerAssets { get; set; }

		// **********
		// صرفا با نگاه طراحی بانک اطلاعاتی
		public System.Guid? PersonId { get; set; }
		// **********

		// **********
		// با نگاه شیء گرايی
		public virtual Person Person { get; set; }
		// **********

		// **********
		//[System.ComponentModel.DataAnnotations.StringLength
		//	(maximumLength: 50)]
		[System.ComponentModel.DisplayName
			(displayName: "نام مشتری")]
		public string FullName { get; set; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated
			(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
		[System.ComponentModel.DisplayName
			(displayName: "کد مشتری")]
		public int Code { get; set; }
		// **********

		// **********
		//[System.ComponentModel.DataAnnotations.StringLength
		//	(maximumLength: 10)]
		[System.ComponentModel.DisplayName
			(displayName: "کد ملی")]
		public string NationalCode { get; set; }
		// **********

		// **********
		//[System.ComponentModel.DataAnnotations.StringLength
		//	(maximumLength: 14)]
		[System.ComponentModel.DisplayName
			(displayName: "کد اقتصادی")]
		public string EconomicCode { get; set; }
		// **********

		// **********
		//[System.ComponentModel.DataAnnotations.StringLength
		//	(maximumLength: 50)]
		[System.ComponentModel.DisplayName
			(displayName: "ایمیل")]
		public string Email { get; set; }
		// **********
		//[System.ComponentModel.DataAnnotations.StringLength
		//	(maximumLength: 25)]
		[System.ComponentModel.DisplayName
			(displayName: "تلفن")]
		public string Phone { get; set; }
		// **********

		// **********
		[System.ComponentModel.DisplayName
			(displayName: "آدرس")]
		public string Address { get; set; }
		// **********
		//public virtual System.Collections.Generic.List<Invoice> Invoices { get; set; }
		// **********
		public virtual System.Collections.Generic.List<Invoice> Invoices { get; set; }
		// **********
	}
}

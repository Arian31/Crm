namespace Models
{

	[System.ComponentModel.DataAnnotations.Schema.Table(name: "Persons", Schema = "Base")]
	public class Person:BaseEntity
	{
		#region Configuration
		internal class Configuration:
			System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Person>
		{
			internal Configuration():base()
			{
				////Char(x)
				//Property(current => current.Phone)
				//	.HasColumnName("Phone")
				//	.IsUnicode(false)
				//	.HasMaxLength(20)
				//	.IsFixedLength()
				//	;


				//nChar(x)
				//Property(current => current.Phone)
				//	.HasColumnName("Phone")
				//	.IsUnicode(true)
				//	.HasMaxLength(20)
				//	.IsFixedLength()
				//	;

				//VarChar(x)
				Property(current => current.Phone)
					.HasColumnName("Phone")
					.IsUnicode(false)
					.HasMaxLength(20)
					.IsVariableLength()
					;

				//VarChar(Max)
				//Property(current => current.Phone)
				//	.HasColumnName("Phone")
				//	.IsUnicode(false)
				//	.IsMaxLength()
				//	.IsVariableLength()
				//	;

				//NVarChar(x)
				Property(current => current.Email)
					.HasColumnName("Email")
					.IsUnicode(true)
					.HasMaxLength(50)
					.IsVariableLength()
					;
			}
		}
		#endregion
		public enum GenderType
		{
			[System.ComponentModel.Description(description: "خانم")]
			Female,
			[System.ComponentModel.Description(description: "آقا")]
			Male
		}
		public Person()
			:base()
		{
			_birthDate = System.DateTime.Parse("1988-09-22 19:42:11.863");
			Customers = new System.Collections.Generic.List<Customer>();
			FullName = new ComplexTypes.FullName();
		}
		//// **********
		//[System.ComponentModel.DataAnnotations.Required
		//	(AllowEmptyStrings = false)]
		//[System.ComponentModel.DataAnnotations.StringLength
		//	(maximumLength: 50, MinimumLength = 2)]
		//[System.ComponentModel.DataAnnotations.Schema.Column(name: "First_Name_Person")]
		//[System.ComponentModel.DataAnnotations.Schema.Index
		//	(name:"IDX_First_Last_Name", IsUnique =true, Order =0)]
		//public string FirstName { get; set; }
		//// **********

		//// **********
		//[System.ComponentModel.DataAnnotations.Required
		//	(AllowEmptyStrings = false)]
		//[System.ComponentModel.DataAnnotations.StringLength
		//	(maximumLength: 50, MinimumLength = 2)]
		//[System.ComponentModel.DataAnnotations.Schema.Column(name: "Last_Name_Person")]
		//[System.ComponentModel.DataAnnotations.Schema.Index
		//	(name: "IDX_First_Last_Name", IsUnique = true, Order = 1)]
		//public string LastName { get; set; }
		//// **********

		// **********
		[System.ComponentModel.Browsable(false)]
		public Models.ComplexTypes.FullName FullName { get; set; }
		// **********

		// **********
		[System.ComponentModel.DisplayName
			(displayName: "نام شخص")]
		public string DisplayFullName 
		{
			get
			{
				string result =
					//$"{FirstName} _ {LastName}";
					FullName.ToString();
				if (result == string.Empty)
				{
					result = "Undifined";
				}
				return result;
			}
		}
		// **********
		//[System.ComponentModel.DataAnnotations.StringLength
		//	(maximumLength: 15)]
		//[System.ComponentModel.DataAnnotations.Schema.Column
		//	(Order = 8, TypeName = "Char")]
		//TypeName ="Char" بهتره از floent api استفاده بشه
		[System.ComponentModel.DisplayName
			(displayName: "تلفن")]
		public string Phone { get; set; }
		// **********

		// **********
		//[System.ComponentModel.DataAnnotations.StringLength
		//	(maximumLength: 50)]
		[System.ComponentModel.DisplayName
			(displayName: "ایمیل")]
		public string Email { get; set; }
		// **********



		// **********
		private System.DateTime _birthDate;
		[System.ComponentModel.Browsable(false)]
		public System.DateTime BirthDate
		{
			get { return _birthDate; }
			set { _birthDate = value; }
		}

		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Schema.NotMapped]
		[System.ComponentModel.DisplayName
			(displayName:"سن")]
		public int Age
		{
			get { return System.DateTime.Now.Year - _birthDate.Year; }
		}

		// **********

		// **********
		//[System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated
		//	(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Computed)]
		[System.ComponentModel.Browsable(false)]
		public System.DateTime CreateDatePerson { get; set; }
		// **********

		// **********
		[System.ComponentModel.DisplayName
			(displayName: "جنسیت")]
		public GenderType Gender { get; set; }
		// **********

		// **********
		public virtual System.Collections.Generic.List<Customer> Customers { get; set; }
		// **********
	}
}

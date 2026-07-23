namespace Models.ComplexTypes
{
	[System.ComponentModel.DataAnnotations.Schema.ComplexType]
	public class FullName:object
	{

		#region Configuration
		//internal class Configuration :
		//	System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<FullName>
		//{
		//	internal Configuration()
		//	{
		//		//VarChar(x)
		//		Property(current => current.FirstName)
		//			.HasColumnName("First_Name_Person")
		//			.IsUnicode(true)
		//			.HasMaxLength(50)
		//			.IsVariableLength()
		//			;

		//		Property(current => current.LastName)
		//			.HasColumnName("Last_Name_Person")
		//			.IsUnicode(true)
		//			.HasMaxLength(50)
		//			.IsVariableLength()
		//			;

		//	}
		//}
		#endregion


		public FullName():base()
		{		
		}

		// **********
		[System.ComponentModel.DataAnnotations.Required
		(AllowEmptyStrings = false)]
		[System.ComponentModel.DataAnnotations.StringLength
			(maximumLength: 50, MinimumLength = 2)]
		[System.ComponentModel.DataAnnotations.Schema.Column(name: "First_Name_Person")]
		[System.ComponentModel.DataAnnotations.Schema.Index
			(name: "IDX_First_Last_Name", IsUnique = true, Order = 0)]
		public string FirstName { get; set; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Required
			(AllowEmptyStrings = false)]
		[System.ComponentModel.DataAnnotations.StringLength
			(maximumLength: 50, MinimumLength = 2)]
		[System.ComponentModel.DataAnnotations.Schema.Column(name: "Last_Name_Person")]
		[System.ComponentModel.DataAnnotations.Schema.Index
			(name: "IDX_First_Last_Name", IsUnique = true, Order = 1)]
		public string LastName { get; set; }
		// **********

		public override string ToString()
		{
			string result = string.Empty;
			if (string.IsNullOrWhiteSpace(FirstName)==false)
			{
				result = FirstName.Trim();
			}
			if (string.IsNullOrWhiteSpace(LastName)==false)
			{
				result =
					$"{result} {LastName.Trim()}".Trim();
			}
			return result;
		}
	}
}

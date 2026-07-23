using System.ComponentModel.DataAnnotations;

namespace Models
{
	public class User : BaseEntity
	{
		public User()
			: base()
		{

		}

		//[System.ComponentModel.DataAnnotations.Key]
		//[System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated
		//	(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Computed)]
		//public int Code { get; set; }

        // **********
        [System.ComponentModel.DataAnnotations.Required
			(AllowEmptyStrings = false)]
		[System.ComponentModel.DataAnnotations.StringLength
			(maximumLength:30)]
		[System.ComponentModel.DataAnnotations.Schema.Index
			(IsUnique = true)]
		public string Username { get; set; }
        // **********

        // **********
        public bool IsActive { get; set; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Required
			(AllowEmptyStrings = false)]
		[System.ComponentModel.DataAnnotations.StringLength
			(maximumLength: 30)]
		public string Password { get; set; }
        // **********
    }
}

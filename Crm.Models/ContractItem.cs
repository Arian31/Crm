namespace Models
{
	[System.ComponentModel.DataAnnotations.Schema.Table(name: "ContractItems", Schema = "Crm")]
	public class ContractItem : BaseEntity
	{
		#region Configuration
		internal class Configuration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<ContractItem>
		{
			internal Configuration() : base()
			{
				HasRequired(current => current.Contract)
					.WithMany(contract => contract.ContractItems)
					.HasForeignKey(current => current.ContractId)
					.WillCascadeOnDelete(true);

				// 💥 تغییر بزرگ: قرارداد دیگر به کالا وصل نیست، بلکه به لایسنسِ مشتری (Asset) وصل می‌شود!
				HasRequired(current => current.CustomerAsset)
					.WithMany()
					.HasForeignKey(current => current.CustomerAssetId)
					.WillCascadeOnDelete(false);
			}
		}
		#endregion

		public ContractItem() : base() { }

		public System.Guid ContractId { get; set; }
		public virtual Contract Contract { get; set; }

		
		[System.ComponentModel.DataAnnotations.Schema.NotMapped]
		public string ProductName
		{
			get { return CustomerAsset != null && CustomerAsset.Product != null ? CustomerAsset.Product.Name : string.Empty; }
		}

		//  تغییر بزرگ
		[System.ComponentModel.DisplayName("لایسنس / دارایی مشتری")]
		public System.Guid CustomerAssetId { get; set; }
		public virtual CustomerAsset CustomerAsset { get; set; }
	}
}
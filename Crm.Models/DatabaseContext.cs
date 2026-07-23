using Models.ComplexTypes;

namespace Models
{
	public class DatabaseContext : System.Data.Entity.DbContext
	{
		static DatabaseContext()
		{
			System.Data.Entity.Database
				.SetInitializer(new DatabaseContextInitializer());
			//System.Data.Entity.Database.SetInitializer
			//	(new System.Data.Entity.DropCreateDatabaseIfModelChanges<DatabaseContext>());
		}

		public DatabaseContext() : base()
		{
		}

		public System.Data.Entity.DbSet<Commodity> Commodities { get; set; }
		public System.Data.Entity.DbSet<Customer> Customers { get; set; }
		public System.Data.Entity.DbSet<Person> People { get; set; }
		public System.Data.Entity.DbSet<User> Users { get; set; }

		public System.Data.Entity.DbSet<Invoice> Invoices { get; set; }
		public System.Data.Entity.DbSet<InvoiceItem> InvoiceItems { get; set; }

		public System.Data.Entity.DbSet<Contract> Contracts { get; set; }
		public System.Data.Entity.DbSet<ContractItem> ContractItems { get; set; }

		public System.Data.Entity.DbSet<CustomerAsset> CustomerAssets { get; set; }


		protected override void OnModelCreating
			(System.Data.Entity.DbModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Configurations.Add(new Person.Configuration());
			modelBuilder.Configurations.Add(new Customer.Configuration());
			modelBuilder.Configurations.Add(new Commodity.Configuration());


			modelBuilder.Configurations.Add(new Invoice.Configuration());
			modelBuilder.Configurations.Add(new InvoiceItem.Configuration());

			modelBuilder.Configurations.Add(new Contract.Configuration());
			modelBuilder.Configurations.Add(new ContractItem.Configuration());

			modelBuilder.Configurations.Add(new CustomerAsset.Configuration());
		}
	}
}

namespace Models
{
	internal class DatabaseContextInitializer
		: System.Data.Entity.DropCreateDatabaseIfModelChanges<DatabaseContext>
	{
		public DatabaseContextInitializer() : base()
		{
		}

		//protected override void Seed(DatabaseContext context)
		//{
		//	base.Seed(context);
		//}

		protected override void Seed(DatabaseContext databaseContext)
		{
			// اطلاعات تستی
			Person person = null;
			Customer customer = null;

			for (int personIndex = 0; personIndex < 10; personIndex++)
			{
				person = new Models.Person
				{
					//FirstName = $"fName{index}",
					//LastName = $"lName{index + 100}",
					Phone = $"09***{personIndex}",
					Email = $"Email{personIndex}@gmail.com",
					CreateDatePerson = System.DateTime.Now,
					Gender = Models.Person.GenderType.Female,
				};
				person.FullName.FirstName = $"fName{personIndex}";
				person.FullName.LastName = $"lName{personIndex + 100}";

				person.Customers =
					new System.Collections.Generic.List<Customer>();
				for (int customerIndex = 0; customerIndex <= 3; customerIndex++)
				{
					customer =
						new Customer()
						{
							FullName = $"Person {personIndex} - Customer {customerIndex}",

						};
					person.Customers.Add(customer);
				}

				databaseContext.People.Add(person);
				databaseContext.SaveChanges();
			}
			//Optional
			databaseContext.SaveChanges();
			// ********************************
			//Customer customer = null;
			//for (int index = 0; index < 10000; index++)
			//{
			//	customer = new Models.Customer
			//	{
			//		FullName = $"Customer_{index}",
			//		NationalCode = $"00{index + 10}",
			//		Email = $"Customer_{index}@gmail.com",
			//		EconomicCode = index + index.ToString(),
			//		Phone = $"00{index}",
			//		Address = $"None  {index}   123        dsgd",
			//	};

			//	databaseContext.Customers.Add(customer);
			//}

			//databaseContext.SaveChanges();
			Commodity commodity = null;
			for (int index = 0; index < 20; index++)
			{
				commodity = new Commodity()
				{
					//Code = index < 10 ? "0000" + index : "000" + index,
					Code = index.ToString(),
					Name = $"P-{index}"
				};
				databaseContext.Commodities.Add(commodity);
			}

			databaseContext.SaveChanges();


		}
	}
}

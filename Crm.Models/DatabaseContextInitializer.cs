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
			try
			{
				// اطلاعات تستی
				Person person = null;
				Customer customer = null;

				for (int personIndex = 0; personIndex < 10; personIndex++)
				{
					person = new Models.Person
					{
						Phone = $"09000{personIndex}",
						Email = $"Email{personIndex}@gmail.com",
						CreateDatePerson = System.DateTime.Now,
						Gender = Models.Person.GenderType.Female,
					};

					person.FullName.FirstName = $"fName{personIndex}";
					person.FullName.LastName = $"lName{personIndex + 100}";

					person.Customers = new System.Collections.Generic.List<Customer>();

					for (int customerIndex = 0; customerIndex <= 3; customerIndex++)
					{
						customer = new Customer()
						{
							FullName = $"Person {personIndex} - Customer {customerIndex}",
							NationalCode = "0123456789",
							PersonId = person.Id   //  مقداردهی مستقیم FK
						};

						person.Customers.Add(customer);
					}

					databaseContext.People.Add(person);
					databaseContext.SaveChanges();
				}

				Commodity commodity = null;

				for (int index = 0; index < 20; index++)
				{
					commodity = new Commodity()
					{
						Code = index.ToString(),
						Name = $"P-{index}"
					};

					databaseContext.Commodities.Add(commodity);
				}

				databaseContext.SaveChanges();
			}
			catch (System.Data.Entity.Validation.DbEntityValidationException ex)
			{
				foreach (var entityError in ex.EntityValidationErrors)
				{
					System.Diagnostics.Debug.WriteLine(
						$"Entity: {entityError.Entry.Entity.GetType().Name}");

					foreach (var validationError in entityError.ValidationErrors)
					{
						System.Diagnostics.Debug.WriteLine(
							$"Property: {validationError.PropertyName} - Error: {validationError.ErrorMessage}");
					}
				}

				throw; // دوباره خطا رو پرتاب می‌کنیم که ببینیش
			}
		}
	}
}

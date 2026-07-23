using System.Linq;

namespace DAL
{
	public class PersonRepository : object,IPersonRepository
	{
		public PersonRepository() : base()
		{
		}

		// **********
		public System.Collections.Generic.List<Models.Person> GetPeople(string filterText = null)
		{
			Models.DatabaseContext databaseContext = null;
			try
			{
				databaseContext =
					new Models.DatabaseContext();

				System.Collections.Generic.List<Models.Person> people = null;

				if (string.IsNullOrWhiteSpace(filterText))
				{
					people =
						databaseContext.People
						.OrderByDescending(current => current.CreateDatePerson)
						.ThenBy(current => current.FullName.LastName)
						.ThenBy(current => current.FullName.FirstName)
						.ToList()
						;
				}
				else
				{
					people =
						databaseContext.People
						.Where(current => current.FullName.FirstName.Contains(filterText)
									   || current.FullName.LastName.Contains(filterText))
						.OrderByDescending(current => current.CreateDatePerson)
						.ThenBy(current => current.FullName.LastName)
						.ThenBy(current => current.FullName.FirstName)
						.ToList()
						;
				}

				return people;
			}
			catch (System.Exception)
			{
				throw;
			}
			finally
			{
				if (databaseContext != null)
				{
					databaseContext.Dispose();
					databaseContext = null;
				}
			}
		}

		// **********
		public Models.Person GetPersonById(System.Guid personId)
		{
			Models.DatabaseContext databaseContext = null;
			try
			{
				databaseContext =
					new Models.DatabaseContext();

				Models.Person person =
					databaseContext.People
					.Where(current => current.Id == personId)
					.FirstOrDefault()
					;

				return person;
			}
			catch (System.Exception)
			{
				throw;
			}
			finally
			{
				if (databaseContext != null)
				{
					databaseContext.Dispose();
					databaseContext = null;
				}
			}
		}

		// **********
		//public bool IsPersonInCustomer(System.Guid id)
		//{
		//	Models.DatabaseContext databaseContext = null;
		//	try
		//	{
		//		databaseContext =
		//			new Models.DatabaseContext();

		//		bool hasAny =
		//			databaseContext.Customers
		//			.Any(current => current.PersonId == id)
		//			;

		//		return hasAny;
		//	}
		//	catch (System.Exception)
		//	{
		//		throw;
		//	}
		//	finally
		//	{
		//		if (databaseContext != null)
		//		{
		//			databaseContext.Dispose();
		//			databaseContext = null;
		//		}
		//	}
		//}

		// **********
		public void CreatePerson(string firstName, string lastName, string phone, string email, System.DateTime birthDate, Models.Person.GenderType gender)
		{
			Models.DatabaseContext databaseContext = null;
			try
			{
				databaseContext =
					new Models.DatabaseContext();

				Models.Person person = new Models.Person
				{
					Phone = phone,
					Email = email,
					CreateDatePerson = System.DateTime.Now,
					BirthDate = birthDate,
					Gender = gender
				};

				person.FullName.FirstName = firstName;
				person.FullName.LastName = lastName;

				databaseContext.People.Add(person);
				databaseContext.SaveChanges();
			}
			catch (System.Data.Entity.Validation.DbEntityValidationException ex)
			{
				throw new System.Exception(GetValidationErrorMessage(ex));
			}
			catch (System.Exception)
			{
				throw;
			}
			finally
			{
				if (databaseContext != null)
				{
					databaseContext.Dispose();
					databaseContext = null;
				}
			}
		}

		// **********
		public void EditPerson(System.Guid personId, string firstName, string lastName, string phone, string email, System.DateTime birthDate, Models.Person.GenderType gender)
		{
			Models.DatabaseContext databaseContext = null;
			try
			{
				databaseContext =
					new Models.DatabaseContext();

				Models.Person person =
					databaseContext.People
					.Where(current => current.Id == personId)
					.FirstOrDefault()
					;

				if (person == null)
				{
					throw new System.Exception("شخص مورد نظر یافت نشد!");
				}

				person.FullName.FirstName = firstName;
				person.FullName.LastName = lastName;
				person.Phone = phone;
				person.Email = email;
				person.BirthDate = birthDate;
				person.Gender = gender;

				databaseContext.SaveChanges();
			}
			catch (System.Data.Entity.Validation.DbEntityValidationException ex)
			{
				throw new System.Exception(GetValidationErrorMessage(ex));
			}
			catch (System.Exception)
			{
				throw;
			}
			finally
			{
				if (databaseContext != null)
				{
					databaseContext.Dispose();
					databaseContext = null;
				}
			}
		}

		// **********
		public void DeletePerson(System.Guid personId)
		{
			Models.DatabaseContext databaseContext = null;
			try
			{
				databaseContext =
					new Models.DatabaseContext();

				Models.Person person =
					databaseContext.People
					.Where(current => current.Id == personId)
					.FirstOrDefault()
					;

				if (person == null)
				{
					throw new System.Exception("شخص مورد نظر یافت نشد!");
				}

				databaseContext.People.Remove(person);
				databaseContext.SaveChanges();
			}
			catch (System.Data.Entity.Validation.DbEntityValidationException ex)
			{
				throw new System.Exception(GetValidationErrorMessage(ex));
			}
			catch (System.Exception)
			{
				throw;
			}
			finally
			{
				if (databaseContext != null)
				{
					databaseContext.Dispose();
					databaseContext = null;
				}
			}
		}

		// **********
		public System.Collections.Generic.List<Models.Person> SearchPeople(string firstName, string lastName, string email, Models.Person.GenderType? gender)
		{
			Models.DatabaseContext databaseContext = null;
			try
			{
				databaseContext =
					new Models.DatabaseContext();

				var data =
					databaseContext.People
					.AsQueryable()
					;

				if (string.IsNullOrWhiteSpace(firstName) == false)
				{
					data =
						data
						.Where(current => current.FullName.FirstName.Contains(firstName))
						;
				}

				if (string.IsNullOrWhiteSpace(lastName) == false)
				{
					data =
						data
						.Where(current => current.FullName.LastName.Contains(lastName))
						;
				}

				if (gender.HasValue)
				{
					data =
						data
						.Where(current => current.Gender == gender.Value)
						;
				}

				if (string.IsNullOrWhiteSpace(email) == false)
				{
					data =
						data
						.Where(current => current.Email.Contains(email))
						;
				}

				var result =
					data
					.OrderByDescending(current => current.CreateDatePerson)
					.ThenBy(current => current.FullName.LastName)
					.ThenBy(current => current.FullName.FirstName)
					.ToList()
					;

				return result;
			}
			catch (System.Exception)
			{
				throw;
			}
			finally
			{
				if (databaseContext != null)
				{
					databaseContext.Dispose();
					databaseContext = null;
				}
			}
		}

		// **********
		// متد کمکی برای استخراج متن خطاهای ولیدیشن EF تا فرم درگیر ساختار EF نشود
		private string GetValidationErrorMessage(System.Data.Entity.Validation.DbEntityValidationException ex)
		{
			string errorMessage = string.Empty;
			foreach (var entityValidationErrors in ex.EntityValidationErrors)
			{
				foreach (var validationError in entityValidationErrors.ValidationErrors)
				{
					errorMessage += $"Entity: {entityValidationErrors.Entry.Entity.GetType().Name}, " +
									$"Property: {validationError.PropertyName}, " +
									$"Errors: {validationError.ErrorMessage}" + System.Environment.NewLine;
				}
			}
			return errorMessage;
		}
	}
}
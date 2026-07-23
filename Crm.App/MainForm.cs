using Crm.App.Customer;
using System;
using System.Data.Entity.Validation;
using System.Linq;
using System.Windows.Forms;

namespace Crm.App
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		private void MainForm_Load(object sender, System.EventArgs e)
		{

		}



		//private void ButtonCustomer_Click(object sender, System.EventArgs e)
		//{
		//	FormCustomers formCustomers =
		//		new FormCustomers();
		//	formCustomers.ShowDialog();
		//}



		private void MainForm_Shown(object sender, EventArgs e)
		{
			Models.DatabaseContext databaseContext = null;
			try
			{
				databaseContext =
					new Models.DatabaseContext();
				//int customerCount =
				//	databaseContext.Customers
				//	.Count()
				//	;
				//if (customerCount != 0)
				//{
				//	buttonGenerateCustomers.Enabled = false;
				//}
				bool hasAnyPerson =
					databaseContext.People
					.Any()
					;

				bool hasAnyCustomer =
					databaseContext.Customers
					.Any()
			;
				if (hasAnyPerson || hasAnyCustomer)
				{
					buttonGenerateInitializer.Enabled = false;
				}



			}
			catch (DbEntityValidationException ex)
			{
				//System.Windows.Forms.MessageBox.Show(ex.Message);
				foreach (var entityValidationErrors in ex.EntityValidationErrors)
				{
					foreach (var validationError in entityValidationErrors.ValidationErrors)
					{
						MessageBox.Show($"Entity: {entityValidationErrors.Entry.Entity.GetType().Name}," +
							$"Property: {validationError.PropertyName}," +
							$"Errors: {validationError.ErrorMessage}");
					}
				}
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


		private void PersonalButton_Click(object sender, EventArgs e)
		{
			PeopleForm peopleForm = new PeopleForm();
			peopleForm.ShowDialog();
		}

		private void CustomerButton_Click(object sender, EventArgs e)
		{
			CustomersForm formCustomers = new CustomersForm();
			formCustomers.Show();
		}

		private void ButtonGenerateInitializer_Click(object sender, EventArgs e)
		{
			//Models.DatabaseContext databaseContext = null;
			//try
			//{
			//	databaseContext =
			//		new Models.DatabaseContext();
			//	for (int index = 0; index < 1000; index++)
			//	{
			//		Models.Person newPerson = new Models.Person
			//		{
			//			//FirstName = $"fName{index}",
			//			//LastName = $"lName{index + 100}",
			//			Phone = $"09***{index}",
			//			Email = $"Email{index}@gmail.com",
			//			CreateDatePerson = DateTime.Now,
			//			Gender = Models.Person.Sexology.Female,
			//		};
			//		newPerson.FullName.FirstName = $"fName{index}";
			//		newPerson.FullName.LastName = $"lName{index + 100}";
			//		databaseContext.People.Add(newPerson);

			//	}
			//	databaseContext.SaveChanges();
			//	// ********************************
			//	databaseContext =
			//		new Models.DatabaseContext();
			//	for (int index = 0; index < 1000; index++)
			//	{
			//		Models.Customer newCustomer = new Models.Customer
			//		{
			//			FullName = $"Customer_{index}",
			//			NationalCode = $"00{index + 10}",
			//			Email = $"Customer_{index}@gmail.com",
			//			EconomicCode = index + index.ToString(),
			//			Phone = $"00{index}",
			//			Address = $"None  {index}   123        dsgd",
			//		};

			//		databaseContext.Customers.Add(newCustomer);
			//	}

			//	databaseContext.SaveChanges();
			//	buttonGenerateInitializer.Enabled = false;
			//	MessageBox.Show("Success");
			//}
			//catch (DbEntityValidationException ex)
			//{
			//	//System.Windows.Forms.MessageBox.Show(ex.Message);
			//	foreach (var entityValidationErrors in ex.EntityValidationErrors)
			//	{
			//		foreach (var validationError in entityValidationErrors.ValidationErrors)
			//		{
			//			MessageBox.Show($"Entity: {entityValidationErrors.Entry.Entity.GetType().Name}," +
			//				$"Property: {validationError.PropertyName}," +
			//				$"Errors: {validationError.ErrorMessage}");
			//		}
			//	}
			//}
			//finally
			//{
			//	if (databaseContext != null)
			//	{
			//		databaseContext.Dispose();
			//		databaseContext = null;
			//	}
			//}

		}

		private void CustomerReportToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ReportPersonCustomerForm report = new ReportPersonCustomerForm();
			report.Show();
		}

		private void commodityButton_Click(object sender, EventArgs e)
		{
			CommoditiesForm commoditiesForm = new CommoditiesForm();
			commoditiesForm.Show();
		}

		private void InvoiceToolStripMenuItem_Click(object sender, EventArgs e)
		{
			InvoiceForm invoiceForm = new InvoiceForm();
			invoiceForm.Show();
		}
	}
}

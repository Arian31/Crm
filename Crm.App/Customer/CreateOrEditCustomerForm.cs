using System.Linq;

namespace Crm.App.Customer
{
	public partial class CreateOrEditCustomerForm : System.Windows.Forms.Form
	{
		// **********
		// استفاده از اینترفیس برای ریپوزیتوری شخص (جهت واکشی نام شخص در زمان ویرایش)
		private DAL.IPersonRepository _personRepository;
		// **********

		public CreateOrEditCustomerForm()
		{
			InitializeComponent();

			// نیو کردن کلاس اصلی
			_personRepository = new DAL.PersonRepository();
		}

		public enum FormOperation
		{
			Insert,
			Update
		}

		#region Properties
		public FormOperation State { get; set; }
		public System.Guid CustomerId { get; set; }

		public string FullName { get { return fullNameTextBox.Text; } set { fullNameTextBox.Text = value; } }
		public string NationalCode { get { return nationalCodeTextBox.Text; } set { nationalCodeTextBox.Text = value; } }
		public string Email { get { return emailTextBox.Text; } set { emailTextBox.Text = value; } }
		public string EconomicCode { get { return economicCodeTextBox.Text; } set { economicCodeTextBox.Text = value; } }
		public string Phone { get { return phoneTextBox.Text; } set { phoneTextBox.Text = value; } }
		public string Address { get { return addressTextBox.Text; } set { addressTextBox.Text = value; } }
		public System.Guid? PersonId { get; set; }
		public string FullNamePerson { get { return personNameTextBox.Text; } set { personNameTextBox.Text = value; } }
		#endregion

		private void FormCreateOrEditCustomer_Load(object sender, System.EventArgs e)
		{
			if (State == FormOperation.Update)
			{
				try
				{
					if (PersonId.HasValue)
					{
						Models.Person person = _personRepository.GetPersonById(personId: PersonId.Value);

						if (person != null)
						{
							FullNamePerson = person.DisplayFullName.ToString();
						}
					}
				}
				catch (System.Exception ex)
				{
					System.Windows.Forms.MessageBox.Show(ex.Message, "خطا در بارگذاری اطلاعات شخص", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
				}
			}
		}

		private void SubmitButton_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = System.Windows.Forms.DialogResult.OK;
		}

		private void ExitButton_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void PersonButton_Click(object sender, System.EventArgs e)
		{
			PeopleForm peopleForm = new PeopleForm();
			peopleForm.IsCustomer = true;

			if (peopleForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				PersonId = peopleForm.PersonId;
				FullNamePerson = peopleForm.FullName;
			}
		}
	}
}
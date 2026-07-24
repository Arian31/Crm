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

			// نیو کردن ارور پرووایدر
			formErrorProvider = new System.Windows.Forms.ErrorProvider();
			// تنظیم جهت نمایش آیکون خطا (راست به چپ برای فارسی)
			formErrorProvider.RightToLeft = true;
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

		//private void SubmitButton_Click(object sender, System.EventArgs e)
		//{
		//	bool isValid = true;
		//	if (FullName == "")
		//		System.Windows.Forms.MessageBox.Show("FullName Test");
		//	isValid = false;
		//	if (FullNamePerson == "")
		//	{
		//		System.Windows.Forms.MessageBox.Show("FullNamePerson Test");
		//		isValid = false;
		//	}
		//	if (nationalCodeTextBox.Text.Trim().ToString()=="" )
		//	{
		//		if (NationalCode.Length != 10)
		//		{
		//			System.Windows.Forms.MessageBox.Show($"NationalCode Test");
		//			isValid = false;
		//		}
		//	}
		//	// اگر به اینجا رسید، یعنی هیچ خطایی وجود ندارد
		//	if (isValid == true)
		//	{
		//		this.DialogResult = System.Windows.Forms.DialogResult.OK;
		//	}

		//}

		private void SubmitButton_Click(object sender, System.EventArgs e)
		{
			// پاک کردن خطاهای قبلی
			formErrorProvider.Clear();

			// ساختن شیء مدل و مقداردهی از فرم
			Models.Customer customer = new Models.Customer
			{
				FullName = this.FullName,
				NationalCode = this.NationalCode,
				EconomicCode = this.EconomicCode,
				Email = this.Email,
				Phone = this.Phone,
				Address = this.Address,
				PersonId = this.PersonId
			};

			// لیست نتایج اعتبارسنجی
			var validationResults = new System.Collections.Generic.List<System.ComponentModel.DataAnnotations.ValidationResult>();

			var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(customer, null, null);

			bool isValid = System.ComponentModel.DataAnnotations.Validator
				.TryValidateObject(customer, validationContext, validationResults, true);

			if (!isValid)
			{
				foreach (var validationResult in validationResults)
				{
					foreach (var memberName in validationResult.MemberNames)
					{
						switch (memberName)
						{
							case nameof(customer.FullName):
							formErrorProvider.SetError(fullNameTextBox, validationResult.ErrorMessage);
							break;

							case nameof(customer.NationalCode):
							formErrorProvider.SetError(nationalCodeTextBox, validationResult.ErrorMessage);
							break;

							//case nameof(customer.EconomicCode):
							//formErrorProvider.SetError(economicCodeTextBox, validationResult.ErrorMessage);
							//break;

							//case nameof(customer.Email):
							//formErrorProvider.SetError(emailTextBox, validationResult.ErrorMessage);
							//break;

							//case nameof(customer.Phone):
							//formErrorProvider.SetError(phoneTextBox, validationResult.ErrorMessage);
							//break;

							//case nameof(customer.Address):
							//formErrorProvider.SetError(addressTextBox, validationResult.ErrorMessage);
							//break;

							case nameof(customer.PersonId):
							formErrorProvider.SetError(personNameTextBox, validationResult.ErrorMessage);
							break;
						}
					}
				}

				return;
			}

			// اگر معتبر بود
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
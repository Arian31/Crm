using Common;

namespace Crm.App.Customer
{
	public partial class CreateOrEditPersonForm : System.Windows.Forms.Form
	{
		// **********
		private DAL.PersonRepository _personRepository;
		// **********

		public CreateOrEditPersonForm()
		{
			InitializeComponent();

			// وهله‌سازی از لایه ارتباط با داده
			_personRepository = new DAL.PersonRepository();
		}

		public enum FormOperation
		{
			Insert,
			Update
		}

		public bool StateAdd { get; set; }

		private FormOperation _state;

		public FormOperation State
		{
			get { return _state; }
			set { _state = value; }
		}

		public System.Guid PersonId { get; set; }

		public string FirstName
		{
			get { return firstNameTextBox.Text; }
			set { firstNameTextBox.Text = value; }
		}

		public string LastName
		{
			get { return lastNameTextBox.Text; }
			set { lastNameTextBox.Text = value; }
		}

		public string Email
		{
			get { return emailTextBox.Text; }
			set { emailTextBox.Text = value; }
		}

		public string Phone
		{
			get { return mobileTextBox.Text; }
			set { mobileTextBox.Text = value; }
		}

		//public System.DateTime BirthDate
		//{
		//	get { return timePickerBirthDateDate.Value; }
		//	set { timePickerBirthDateDate.Value = value; }
		//}
		// در فایل CreateOrEditPersonForm.cs

		public System.DateTime BirthDate
		{
			get
			{
				// تبدیل شمسی به میلادی هنگام پاس دادن به فرم اصلی
				System.DateTime? date = BirthDateMaskedTextBox.Text.ToGregorian();
				return date.HasValue ? date.Value : System.DateTime.Now;
			}
			set
			{
				// تبدیل میلادی به شمسی برای نمایش در حالت ویرایش
				BirthDateMaskedTextBox.Text = value.ToJalali();
			}
		}

		public Models.Person.GenderType Gender
		{
			get { return (Models.Person.GenderType)genderComboBox.SelectedIndex; }
			set { genderComboBox.SelectedIndex = (int)value; }
		}

		private void CreateOrEditPersonForm_Load(object sender, System.EventArgs e)
		{
			if (_state == FormOperation.Insert)
			{
				this.Text = "افزودن شخص جدید";
			}
			else
			{
				this.Text = "ویرایش شخص ";
				submitButton.Enabled = false;
			}
		}

		private void ExitButton_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void SubmitAndExitButton_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = System.Windows.Forms.DialogResult.OK;
		}

		private void SubmitButton_Click(object sender, System.EventArgs e)
		{
			CreatePerson();
		}

		private void CreatePerson()
		{
			try
			{
				// ارسال اطلاعات به لایه DAL برای ثبت در دیتابیس
				_personRepository.CreatePerson
					(
						firstName: this.FirstName,
						lastName: this.LastName,
						phone: this.Phone,
						email: this.Email,
						birthDate: this.BirthDate,
						gender: this.Gender
					);

				// اگر کد به این خط برسد، یعنی ثبت در EF بدون خطا انجام شده است
				// پس نیازی به بررسی EntityState.Added نیست
				StateAdd = true;

				// خالی کردن تکست‌باکس‌ها برای ثبت رکورد بعدی
				FirstName = null;
				LastName = null;
				Phone = null;
				Email = null;

				// System.Windows.Forms.MessageBox.Show("Success");
			}
			catch (System.Exception ex)
			{
				// پیام خطایی که از DAL می‌آید (شامل خطاهای ولیدیشن EF) در اینجا نمایش داده می‌شود
				System.Windows.Forms.MessageBox.Show
					(
						text: ex.Message,
						caption: "خطا در ثبت اطلاعات",
						buttons: System.Windows.Forms.MessageBoxButtons.OK,
						icon: System.Windows.Forms.MessageBoxIcon.Error
					);
			}
		}
	}
}
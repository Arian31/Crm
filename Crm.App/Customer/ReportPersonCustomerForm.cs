using System.Windows.Forms;

namespace Crm.App.Customer
{
	public partial class ReportPersonCustomerForm : System.Windows.Forms.Form
	{
		// تزریق ریپوزیتوری‌ها
		private DAL.IPersonRepository _personRepository;
		private DAL.ICustomerRepository _customerRepository;

		public ReportPersonCustomerForm()
		{
			InitializeComponent();
			_personRepository = new DAL.PersonRepository();
			_customerRepository = new DAL.CustomerRepository();
		}

		private void ReportPersonCustomerForm_Load(object sender, System.EventArgs e)
		{
			try
			{
				// قطع موقت رویداد تغییر لیست برای جلوگیری از خطای اجرای زودهنگام
				peopleListBox.SelectedIndexChanged -= PeopleListBox_SelectedIndexChanged;

				// دریافت لیست اشخاص از لایه DAL
				var people = _personRepository.GetPeople();

				peopleListBox.ValueMember = "Id";
				peopleListBox.DisplayMember = "DisplayFullName";
				peopleListBox.DataSource = people;

				// وصل کردن مجدد رویداد
				peopleListBox.SelectedIndexChanged += PeopleListBox_SelectedIndexChanged;

				// اگر دیتایی وجود داشت، مشتریان نفر اول را لود می‌کنیم
				if (peopleListBox.Items.Count > 0)
				{
					LoadCustomers();
				}
			}
			catch (System.Exception ex)
			{
				MessageBox.Show(ex.Message, "خطا در واکشی اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void PeopleListBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			LoadCustomers();
		}

		private void LoadCustomers()
		{
			// بررسی اینکه واقعا شخصی انتخاب شده باشد
			if (peopleListBox.SelectedValue == null) return;

			try
			{
				System.Guid selectedPersonId = (System.Guid)peopleListBox.SelectedValue;

				// استفاده از متد جدید در DAL
				var customers = _customerRepository.GetCustomersByPersonId(selectedPersonId);

				customersListBox.DataSource = null;
				customersListBox.ValueMember = "Id";
				customersListBox.DisplayMember = "FullName";
				customersListBox.DataSource = customers;
			}
			catch (System.Exception ex)
			{
				MessageBox.Show(ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}
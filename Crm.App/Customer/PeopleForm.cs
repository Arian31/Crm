using Common;
using Models;
using System;
using System.Windows.Forms;

namespace Crm.App.Customer
{
	public partial class PeopleForm : Form
	{
		// **********
		// استفاده از اینترفیس‌ها به جای کلاس مستقیم (رعایت اصول معماری)
		private DAL.IPersonRepository _personRepository;
		private DAL.ICustomerRepository _customerRepository;
		// **********

		public PeopleForm()
		{
			InitializeComponent();

			// نیو کردن کلاس‌های واقعی و انتساب به اینترفیس‌ها
			_personRepository = new DAL.PersonRepository();
			_customerRepository = new DAL.CustomerRepository();
		}

		public bool IsCustomer { get; set; }
		public System.Guid PersonId { get; set; }
		public string FullName { get; set; }

		private void PeopleForm_Load(object sender, EventArgs e)
		{
			recordCountLabel.Text = string.Empty;
			LoadPeopleGrid(); // لود اولیه بدون فیلتر
		}

		private void RefreshButton_Click(object sender, EventArgs e)
		{
			filterTextBox.Text = string.Empty;
			LoadPeopleGrid();
		}

		private void FilterTextBox_TextChanged(object sender, EventArgs e)
		{
			// ارسال متن تکست‌باکس به متد یکپارچه لود گرید
			LoadPeopleGrid(filterText: filterTextBox.Text);
		}

		private void CreateButton_Click(object sender, EventArgs e)
		{
			CreateOrEditPersonForm createForm = new CreateOrEditPersonForm();
			createForm.State = CreateOrEditPersonForm.FormOperation.Insert;

			if (createForm.ShowDialog() == DialogResult.OK)
			{
				try
				{
					// نکته بسیار مهم: 
					// پراپرتی createForm.BirthDate خودش در پشت صحنه شمسی را به میلادی تبدیل می‌کند
					_personRepository.CreatePerson(
						createForm.FirstName,
						createForm.LastName,
						createForm.Phone,
						createForm.Email,
						createForm.BirthDate,
						createForm.Gender
					);

					MessageBox.Show("ثبت شخص با موفقیت انجام شد.", "عملیات موفق", MessageBoxButtons.OK, MessageBoxIcon.Information);
					LoadPeopleGrid();
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "خطا در ثبت", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			else
			{
				if (createForm.StateAdd == true)
				{
					LoadPeopleGrid();
				}
			}
		}

		private void EditButton_Click(object sender, EventArgs e)
		{
			if (peopleDataGridView.CurrentRow == null)
				return;

			try
			{
				System.Guid selectedId = Guid.Parse(peopleDataGridView.CurrentRow.Cells["Id"].Value.ToString());
				var selectPerson = _personRepository.GetPersonById(selectedId);

				if (selectPerson == null) return;

				CreateOrEditPersonForm editForm = new CreateOrEditPersonForm()
				{
					State = CreateOrEditPersonForm.FormOperation.Update,
					PersonId = selectPerson.Id,
					FirstName = selectPerson.FullName.FirstName,
					LastName = selectPerson.FullName.LastName,
					Phone = selectPerson.Phone,
					Email = selectPerson.Email,
					// در اینجا تاریخ میلادی به پراپرتی پاس داده می‌شود و پراپرتی آن را شمسی روی فرم چاپ می‌کند
					BirthDate = selectPerson.BirthDate,
					Gender = selectPerson.Gender
				};

				if (editForm.ShowDialog() == DialogResult.OK)
				{
					_personRepository.EditPerson(
						editForm.PersonId,
						editForm.FirstName,
						editForm.LastName,
						editForm.Phone,
						editForm.Email,
						editForm.BirthDate,
						editForm.Gender
					);

					MessageBox.Show("ویرایش با موفقیت انجام شد.", "عملیات موفق", MessageBoxButtons.OK, MessageBoxIcon.Information);
					LoadPeopleGrid();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "خطا در ویرایش", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void DeleteButton_Click(object sender, EventArgs e)
		{
			if (peopleDataGridView.CurrentRow == null)
				return;

			try
			{
				System.Guid selectedId = Guid.Parse(peopleDataGridView.CurrentRow.Cells["Id"].Value.ToString());

				if (_customerRepository.HasPerson(selectedId))
				{
					MessageBox.Show("شخص جاری در فرم مشتری استفاده شده، نمیتوان آن را حذف کرد", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}

				if (MessageBox.Show("آیا از حذف این شخص مطمئن هستید؟", "تایید حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					_personRepository.DeletePerson(selectedId);
					LoadPeopleGrid();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "خطا در حذف", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void SearchButton_Click(object sender, EventArgs e)
		{
			try
			{
				Models.Person.GenderType? searchGender = null;

				// روش ایمن‌تر برای خواندن مقدار کمبوباکس
				if (genderComboBox.SelectedIndex >= 0 && !string.IsNullOrWhiteSpace(genderComboBox.Text))
				{
					searchGender = (Models.Person.GenderType)genderComboBox.SelectedIndex;
				}

				var result = _personRepository.SearchPeople(
					firstNamePersonTextBox.Text,
					lastNamePersonTextBox.Text,
					emailTextBox.Text,
					searchGender
				);

				recordCountLabel.Text = $"تعداد رکورد ها : {result.Count}";
				peopleDataGridView.DataSource = result;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "خطا در جستجو", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void PeopleDataGridView_DoubleClick(object sender, EventArgs e)
		{
			if (IsCustomer)
			{
				if (peopleDataGridView.CurrentRow == null)
					return;

				PersonId = Guid.Parse(peopleDataGridView.CurrentRow.Cells["Id"].Value.ToString());
				FullName = peopleDataGridView.CurrentRow.Cells["DisplayFullName"].Value.ToString();
				this.DialogResult = DialogResult.OK;
			}
		}

		#region Helper Methods

		// **********
		// متد یکپارچه برای لود کردن و فیلتر کردن اطلاعات
		private void LoadPeopleGrid(string filterText = null)
		{
			try
			{
				var people = _personRepository.GetPeople(filterText);
				peopleDataGridView.DataSource = people;

				if (peopleDataGridView.Columns["Id"] != null)
				{
					peopleDataGridView.Columns["Id"].Visible = false;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "خطا در بارگذاری اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		// **********

		#endregion

		// **********
		private void PeopleDataGridView_CellFormatting(object sender, System.Windows.Forms.DataGridViewCellFormattingEventArgs e)
		{
			if (e.Value == null)
			{
				return;
			}

			string columnName = peopleDataGridView.Columns[e.ColumnIndex].Name;

			try
			{
				if (columnName == "BirthDate")
				{
					if (e.Value is System.DateTime dateValue)
					{
						e.Value = dateValue.ToJalali();
						e.FormattingApplied = true;
					}
				}
				else if (columnName == "Gender")
				{
					if (e.Value is Models.Person.GenderType genderValue)
					{
						e.Value = genderValue.GetDescription();
						e.FormattingApplied = true;
					}
				}
			}
			catch (System.Exception)
			{
				// نادیده گرفتن خطا برای جلوگیری از کرش شدن رابط کاربری
			}
		}
		// **********
	}
}
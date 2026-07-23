using System;
using System.Linq;
using System.Windows.Forms;

namespace Crm.App.Customer
{
	public partial class CustomersForm : System.Windows.Forms.Form
	{
		// **********
		// استفاده از Interface به جای کلاس مستقیم
		private DAL.ICustomerRepository _customerRepository;
		// **********

		public CustomersForm()
		{
			InitializeComponent();

			// در سمت راست مساوی، کلاسی که اینترفیس را پیاده‌سازی کرده New می‌کنیم
			_customerRepository = new DAL.CustomerRepository();
		}

		public int pageSize { get; set; } = 10;
		public int currentPage { get; set; } = 1;
		public int totalRecords { get; set; }
		public int totalPages { get; set; }

		public bool IsSelectionMode { get; set; }
		public Guid SelectedCustomerId { get; set; }
		public string SelectedCustomerName { get; set; }

		private void FormCustomers_Load(object sender, System.EventArgs e)
		{
			LoadData();
		}

		private void FilterTextBox_TextChanged(object sender, EventArgs e)
		{
			currentPage = 1;
			LoadData();
		}

		private void CreateButton_Click(object sender, System.EventArgs e)
		{
			CreateOrEditCustomerForm createForm = new CreateOrEditCustomerForm();
			createForm.State = CreateOrEditCustomerForm.FormOperation.Insert;

			if (createForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				try
				{
					_customerRepository.CreateCustomer
						(
							personId: createForm.PersonId,
							fullName: createForm.FullName,
							nationalCode: createForm.NationalCode,
							email: createForm.Email,
							economicCode: createForm.EconomicCode,
							phone: createForm.Phone,
							address: createForm.Address
						);

					System.Windows.Forms.MessageBox.Show("ثبت مشتری با موفقیت انجام شد.", "موفق", MessageBoxButtons.OK, MessageBoxIcon.Information);
					LoadData();
				}
				catch (System.Exception ex)
				{
					System.Windows.Forms.MessageBox.Show(ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private void EditButton_Click(object sender, System.EventArgs e)
		{
			if (customersDataGridView.CurrentRow == null)
				return;

			try
			{
				System.Guid selectedId = System.Guid.Parse(customersDataGridView.CurrentRow.Cells["Id"].Value.ToString());
				var selectCustomer = _customerRepository.GetCustomerById(customerId: selectedId);

				if (selectCustomer == null) return;

				var editForm = new CreateOrEditCustomerForm()
				{
					State = CreateOrEditCustomerForm.FormOperation.Update,
					CustomerId = selectCustomer.Id,
					FullName = selectCustomer.FullName,
					NationalCode = selectCustomer.NationalCode,
					Email = selectCustomer.Email,
					EconomicCode = selectCustomer.EconomicCode,
					Phone = selectCustomer.Phone,
					Address = selectCustomer.Address,
					PersonId = selectCustomer.PersonId,
				};

				if (editForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				{
					_customerRepository.ModifyCustomer
						(
							id: editForm.CustomerId,
							fullName: editForm.FullName,
							nationalCode: editForm.NationalCode,
							email: editForm.Email,
							economicCode: editForm.EconomicCode,
							phone: editForm.Phone,
							address: editForm.Address,
							personId: editForm.PersonId
						);

					System.Windows.Forms.MessageBox.Show("اطلاعات با موفقیت ذخیره شد.", "موفق", MessageBoxButtons.OK, MessageBoxIcon.Information);
					LoadData();
				}
			}
			catch (System.Exception ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.Message, "خطا در ویرایش", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void RefreshButton_Click(object sender, System.EventArgs e)
		{
			LoadData();
		}

		private void DeleteButton_Click(object sender, System.EventArgs e)
		{
			if (customersDataGridView.CurrentRow == null)
				return;

			try
			{
				System.Guid selectedId = System.Guid.Parse(customersDataGridView.CurrentRow.Cells["Id"].Value.ToString());

				if (System.Windows.Forms.MessageBox.Show("آیا از حذف این مشتری مطمئن هستید؟", "تایید", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					_customerRepository.DeleteCustomer(id: selectedId);
					LoadData();
				}
			}
			catch (System.Exception ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.Message, "خطا در حذف", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		#region Pagination Buttons
		private void FirstPageButton_Click(object sender, EventArgs e) { currentPage = 1; LoadData(); }
		private void PreviousPageButton_Click(object sender, EventArgs e) { if (currentPage > 1) { currentPage--; LoadData(); } }
		private void NextPageButton_Click(object sender, EventArgs e) { if (currentPage < totalPages) { currentPage++; LoadData(); } }
		private void LastPageButton_Click(object sender, EventArgs e) { currentPage = totalPages; LoadData(); }
		#endregion

		#region Helper Methods

		// **********
		private void LoadData()
		{
			try
			{
				int totalRecs = 0;

				// گرفتن لیست مدل‌ها از لایه DAL
				var customers = _customerRepository.GetPagedCustomers
					(
						filterText: filterTextBox.Text,
						pageIndex: currentPage,
						pageSize: pageSize,
						totalRecords: out totalRecs
					);

				totalRecords = totalRecs;
				totalPages = totalRecords == 0 ? 1 : (int)Math.Ceiling((double)totalRecords / pageSize);

				// تبدیل مدل‌ها به ViewModel در لایه UI
				var customerViewModels =
					customers
					.Select(current => new ViewModel.CustomerViewModel
					{
						Id = current.Id,
						Code = current.Code,
						FullName = current.Person != null ? current.Person.DisplayFullName : "شخصی متصل نیست",
						CustomerName = current.FullName,
						Phone = current.Phone,
						Email = current.Email
					})
					.ToList()
					;

				customersDataGridView.DataSource = customerViewModels;
				PageInfoLabel.Text = $"صفحه {currentPage} از {totalPages}";
			}
			catch (System.Exception ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.Message, "خطا در واکشی اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		// **********
		#endregion

		private void CustomersDataGridView_DoubleClick(object sender, EventArgs e)
		{
			if (IsSelectionMode)
			{
				if (customersDataGridView.CurrentRow == null)
					return;

				SelectedCustomerId = Guid.Parse(customersDataGridView.CurrentRow.Cells["Id"].Value.ToString());
				SelectedCustomerName = customersDataGridView.CurrentRow.Cells["CustomerName"].Value.ToString();
				this.DialogResult = DialogResult.OK;
				//MessageBox.Show($"{SelectedCustomerId} - {SelectedCustomerName}");
			}
		}

		private void CustomersDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			//MessageBox.Show($"{customersDataGridView.Columns[e.ColumnIndex].Name}");
		}
	}
}


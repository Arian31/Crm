using Common;
using Models;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace Crm.App
{
	public partial class ContractForm : Form
	{
		// ********** متغیرهای لایه دیتابیس **********
		private DAL.IContractRepository _contractRepository;
		// **********

		// ********** متغیرهای وضعیت فرم **********
		public enum FormState { View, Insert, Update }
		private FormState _currentState;
		private bool _isDirty = false;

		private Guid? _currentContractId = null;
		private Guid? _selectedCustomerId = null;
		// **********

		// ********** لیست متصل به گریدویو **********
		private BindingList<ContractItem> _contractItems;
		// **********

		public ContractForm()
		{
			InitializeComponent();
			_contractRepository = new DAL.ContractRepository();

			SetupDataGridView();

			_contractItems = new BindingList<ContractItem>();
			itemDataGridView.DataSource = _contractItems;
			_contractItems.ListChanged += (s, e) => _isDirty = true;
		}

		private void ContractForm_Load(object sender, EventArgs e)
		{
			SetFormState(FormState.View);
		}

		private void SelectCustomerButton_Click(object sender, EventArgs e)
		{

		}

		#region Setup Methods

		// تنظیمات اتوماتیک ستون‌های گریدویو
		private void SetupDataGridView()
		{
			itemDataGridView.AutoGenerateColumns = false;
			itemDataGridView.AllowUserToAddRows = false;
			itemDataGridView.Columns.Clear();

			itemDataGridView.Columns.Add(new DataGridViewTextBoxColumn
			{
				Name = "productNameColumn",
				HeaderText = "نام محصول / زیرسیستم",
				DataPropertyName = "ProductName",
				ReadOnly = true,
				Width = 200
			});

			itemDataGridView.Columns.Add(new DataGridViewTextBoxColumn
			{
				Name = "serialColumn",
				HeaderText = "سریال / دانگل",
				DataPropertyName = "SoftwareSerial",
				Width = 150
			});

			itemDataGridView.Columns.Add(new DataGridViewTextBoxColumn
			{
				Name = "computerNameColumn",
				HeaderText = "نام سرور / سیستم",
				DataPropertyName = "ComputerName",
				Width = 150
			});
		}
		#endregion

		#region State Machine

		private void SetFormState(FormState state)
		{
			_currentState = state;
			bool isEditing = (state == FormState.Insert || state == FormState.Update);

			panel1.Enabled = isEditing; // پنل اطلاعات بالا
			panel2.Enabled = isEditing; // پنل گریدویو و مشتری
			submitButton.Enabled = isEditing;
			cancelButton.Enabled = isEditing;

			newButton.Enabled = true;
			editButton.Enabled = !isEditing && _currentContractId.HasValue;
			deleteButton.Enabled = !isEditing && _currentContractId.HasValue;

			if (state == FormState.Insert)
			{
				ClearForm();
				startDateMaskedTextBox.Text = DateTime.Now.ToJalali();
				// پیش‌فرض یک سال اعتبار
				endDateMaskedTextBox.Text = DateTime.Now.AddYears(1).ToJalali();
			}
		}

		private void ClearForm()
		{
			_currentContractId = null;
			_selectedCustomerId = null;

			contractNumberTextBox.Text = string.Empty;
			customerNameTextBox.Text = string.Empty;
			startDateMaskedTextBox.Text = string.Empty;
			endDateMaskedTextBox.Text = string.Empty;
			descriptionTextBox.Text = string.Empty;
			numericUpDown1.Value = 0;
			freeWarrantyCheckBox.Checked = false;

			_contractItems.Clear();
			_isDirty = false;
		}

		private bool CheckUnsavedChanges()
		{
			if (_isDirty)
			{
				DialogResult result = MessageBox.Show(
					"اطلاعات فعلی ذخیره نشده است. رها کردن فرم؟",
					"هشدار", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
				return result == DialogResult.Yes;
			}
			return true;
		}

		#endregion


	}
}

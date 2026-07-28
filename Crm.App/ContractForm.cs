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
			WireUpEvents();

			_contractItems = new BindingList<ContractItem>();
			itemDataGridView.DataSource = _contractItems;
			_contractItems.ListChanged += (s, e) => _isDirty = true;
		}

		private void ContractForm_Load(object sender, EventArgs e)
		{
			SetFormState(FormState.View);
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

		// اتصال رویدادهای کلیک به دکمه‌های تول‌استریپ
		private void WireUpEvents()
		{
			newButton.Click += NewButton_Click;
			editButton.Click += EditButton_Click;
			deleteButton.Click += DeleteButton_Click;
			submitButton.Click += SubmitButton_Click;
			cancelButton.Click += CancelButton_Click;

			// رویدادهای تغییرات فرم
			contractNumberTextBox.TextChanged += (s, e) => _isDirty = true;
			descriptionTextBox.TextChanged += (s, e) => _isDirty = true;
			numericUpDown1.ValueChanged += (s, e) => _isDirty = true;

			// رویدادهای گریدویو و مشتری
			//itemDataGridView.KeyDown += ItemDataGridView_KeyDown;
			//selectCustomerButton.Click += SelectCustomerButton_Click;
			freeWarrantyCheckBox.CheckedChanged += FreeWarrantyCheckBox_CheckedChanged;
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

		#region Buttons (CRUD)

		private void NewButton_Click(object sender, EventArgs e)
		{
			if (CheckUnsavedChanges()) SetFormState(FormState.Insert);
		}

		private void EditButton_Click(object sender, EventArgs e)
		{
			SetFormState(FormState.Update);
		}

		private void CancelButton_Click(object sender, EventArgs e)
		{
			SetFormState(FormState.View);
			ClearForm();
		}

		private void DeleteButton_Click(object sender, EventArgs e)
		{
			if (_currentContractId.HasValue)
			{
				if (MessageBox.Show("آیا از حذف این قرارداد مطمئن هستید؟", "تایید", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					try
					{
						_contractRepository.DeleteContract(_currentContractId.Value);
						MessageBox.Show("قرارداد با موفقیت حذف شد.", "موفق", MessageBoxButtons.OK, MessageBoxIcon.Information);
						SetFormState(FormState.View);
						ClearForm();
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
			}
		}

		private void SubmitButton_Click(object sender, EventArgs e)
		{
			// 1. اعتبارسنجی فرم
			if (!_selectedCustomerId.HasValue)
			{
				MessageBox.Show("لطفا مشتری را انتخاب کنید.", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			if (string.IsNullOrWhiteSpace(contractNumberTextBox.Text))
			{
				MessageBox.Show("شماره قرارداد الزامی است.", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			DateTime? startDate = startDateMaskedTextBox.Text.ToGregorian();
			DateTime? endDate = endDateMaskedTextBox.Text.ToGregorian();
			if (startDate == null || endDate == null)
			{
				MessageBox.Show("تاریخ‌های قرارداد نامعتبر است.", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			if (_contractItems.Count == 0)
			{
				MessageBox.Show("حداقل یک زیرسیستم باید برای قرارداد انتخاب شود.", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			// 2. بررسی شماره تکراری
			if (_contractRepository.IsContractNumberExist(contractNumberTextBox.Text, _currentContractId))
			{
				MessageBox.Show("این شماره قرارداد قبلا ثبت شده است.", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			// 3. آماده‌سازی برای دیتابیس
			var itemsForDb = new System.Collections.Generic.List<ContractItem>();
			foreach (var item in _contractItems)
			{
				itemsForDb.Add(new ContractItem
				{
					Id = item.Id == Guid.Empty ? Guid.NewGuid() : item.Id,
					ContractId = _currentContractId ?? Guid.Empty,
					// در مدل جدید، ما فقط به کلید خارجیِ Asset نیاز داریم!
					CustomerAssetId = item.CustomerAssetId,
					
				});
			}

			try
			{
				Contract contract = new Contract
				{
					Id = _currentContractId ?? Guid.NewGuid(),
					ContractNumber = contractNumberTextBox.Text,
					StartDate = startDate.Value,
					EndDate = endDate.Value,
					CustomerId = _selectedCustomerId.Value,
					ContractAmount = numericUpDown1.Value,
					IsFreeWarranty = freeWarrantyCheckBox.Checked,
					Description = descriptionTextBox.Text,
					ContractItems = itemsForDb,

					// چون فاکتور در سناریوی ما اختیاری شد، برای جلوگیری از ارور EF
					// باید InvoiceId نال بماند مگر اینکه سناریویی برای ثبت آن داشته باشیم
					InvoiceId = Guid.Empty
				};

				if (_currentState == FormState.Insert)
					_contractRepository.CreateContract(contract);
				else
					_contractRepository.UpdateContract(contract);

				MessageBox.Show("قرارداد با موفقیت ثبت شد.", "موفق", MessageBoxButtons.OK, MessageBoxIcon.Information);
				_currentContractId = contract.Id;
				_isDirty = false;
				SetFormState(FormState.View);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "خطا در ثبت", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		#endregion

		#region UI Logic & Events

		// اگر گارانتی رایگان تیک خورد، مبلغ صفر می‌شود و غیرفعال می‌گردد
		private void FreeWarrantyCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (freeWarrantyCheckBox.Checked)
			{
				numericUpDown1.Value = 0;
				numericUpDown1.Enabled = false;
			}
			else
			{
				numericUpDown1.Enabled = true;
			}
		}

		private void SelectCustomerButton_Click(object sender, EventArgs e)
		{
			Customer.CustomersForm frm = new Customer.CustomersForm();
			frm.IsSelectionMode = true;

			if (frm.ShowDialog() == DialogResult.OK)
			{
				// اگر مشتری تغییر کرد، لایسنس‌های قبلی گریدویو باید پاک شوند
				if (_selectedCustomerId != frm.SelectedCustomerId)
				{
					_contractItems.Clear();
				}

				_selectedCustomerId = frm.SelectedCustomerId;
				customerNameTextBox.Text = frm.SelectedCustomerName;
				_isDirty = true;
			}
		}

		private void ItemDataGridView_KeyDown(object sender, KeyEventArgs e)
		{
			if (_currentState == FormState.View) return;

			// با زدن Space روی گریدویو فرم انتخاب لایسنس باز می‌شود
			if (e.KeyCode == Keys.Space)
			{
				if (!_selectedCustomerId.HasValue)
				{
					MessageBox.Show("لطفا ابتدا مشتری را انتخاب کنید.", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}

				// 💥 باز کردن فرم انتخاب لایسنس 💥
				SelectAssetForm frm = new SelectAssetForm(_selectedCustomerId.Value);

				if (frm.ShowDialog() == DialogResult.OK)
				{
					// کاربر ممکن است 3 نرم‌افزار را همزمان تیک زده باشد
					foreach (var selectedAsset in frm.SelectedAssets)
					{
						// جلوگیری از اضافه شدن تکراری در قرارداد
						if (!_contractItems.Any(i => i.CustomerAssetId == selectedAsset.Id))
						{
							_contractItems.Add(new ContractItem
							{
								Id = Guid.NewGuid(),
								CustomerAssetId = selectedAsset.Id,

								// اختصاص یک شیء Asset موقت برای گول زدن گریدویو جهت نمایش نام کالا و سریال
								CustomerAsset = new CustomerAsset
								{
									Product = new Commodity { Name = selectedAsset.Product.Name },
									SoftwareSerial = selectedAsset.SoftwareSerial,
									ComputerName = selectedAsset.ComputerName
								}
							});
						}
					}

					_isDirty = true;
				}

				e.Handled = true;
			}
			// حذف سطر با دکمه Delete
			else if (e.KeyCode == Keys.Delete && itemDataGridView.CurrentRow != null)
			{
				_contractItems.RemoveAt(itemDataGridView.CurrentRow.Index);
			}
		}
		#endregion

		// **********
		// متد لود قرارداد برای ویرایش (صدا زده شده از فرم لیست قراردادها)
		public void LoadContractForEdit(Guid contractId)
		{
			try
			{
				var contract = _contractRepository.GetContractById(contractId);
				if (contract == null) return;

				_currentContractId = contract.Id;
				_selectedCustomerId = contract.CustomerId;

				contractNumberTextBox.Text = contract.ContractNumber;
				customerNameTextBox.Text = contract.Customer.FullName;
				startDateMaskedTextBox.Text = contract.StartDate.ToJalali();
				endDateMaskedTextBox.Text = contract.EndDate.ToJalali();
				numericUpDown1.Value = contract.ContractAmount;
				freeWarrantyCheckBox.Checked = contract.IsFreeWarranty;
				descriptionTextBox.Text = contract.Description;

				_contractItems.Clear();
				foreach (var item in contract.ContractItems)
				{
					_contractItems.Add(item);
				}

				SetFormState(FormState.View);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "خطا در بارگذاری", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		// **********
	}
}
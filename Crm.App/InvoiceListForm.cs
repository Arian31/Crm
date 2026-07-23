using Common;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Crm.App
{
	public partial class InvoiceListForm : Form
	{
		// **********
		private DAL.IInvoiceRepository _invoiceRepository;
		// **********

		// ********** پراپرتی‌ها برای استفاده در حالت "انتخاب دیالوگ" **********
		public bool IsSelectionMode { get; set; } = false;
		public Guid SelectedInvoiceId { get; private set; }
		// **********

		// متغیر برای نگهداری نوع مرتب‌سازی فعلی
		private string _currentSortOrder = "Date";

		public InvoiceListForm()
		{
			InitializeComponent();
			_invoiceRepository = new DAL.InvoiceRepository();

			// جلوگیری از بهم‌ریختگی ستون‌ها
			invoiceDataGridView.AutoGenerateColumns = true;
			invoiceDataGridView.ReadOnly = true;
			invoiceDataGridView.AllowUserToAddRows = false;
			invoiceDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		}

		private void InvoiceListForm_Load(object sender, EventArgs e)
		{
			// اگر فرم برای "انتخاب یک فاکتور" باز شده باشد، دکمه انتخاب را نشان بده، در غیر اینصورت مخفی کن
			//choiceButton.Visible = IsSelectionMode;

			// لود اولیه اطلاعات
			LoadData();
		}

		#region Buttons Events

		private void SearchButton_Click(object sender, EventArgs e)
		{
			LoadData();
		}

		private void SortByDateButton_Click(object sender, EventArgs e)
		{
			_currentSortOrder = "Date";
			LoadData();
		}

		private void SortBySerialButton_Click(object sender, EventArgs e)
		{
			_currentSortOrder = "Serial";
			LoadData();
		}

		// این دکمه را در دیزاین به نام choiceButton ساخته بودید اما در کدها ننوشته بودید
		private void ChoiceButton_Click(object sender, EventArgs e)
		{
			SelectAndClose();
		}

		#endregion

		#region DataGridView Events

		private void InvoiceDataGridView_DoubleClick(object sender, EventArgs e)
		{
			// اگر کاربر روی یک سطر دابل‌کلیک کرد
			if (invoiceDataGridView.CurrentRow != null && invoiceDataGridView.CurrentRow.Index >= 0)
			{
				if (IsSelectionMode)
				{
					// اگر فرم برای انتخاب باز شده است
					SelectAndClose();
				}
				else
				{
					// 💥 روش اصولی استخراج دیتا از سطر انتخاب شده 💥
					// سطر انتخاب شده را مستقیماً به نوع ViewModel تبدیل می‌کنیم
					var selectedInvoice = invoiceDataGridView.CurrentRow.DataBoundItem as ViewModels.InvoiceViewModel;

					if (selectedInvoice != null)
					{
						InvoiceForm frm = new InvoiceForm();
						// آیدی را مستقیماً از شیء می‌خوانیم، نه از سلول گریدویو!
						frm.LoadInvoiceForEdit(selectedInvoice.Id);
						frm.ShowDialog();

						// بعد از بستن فرم ویرایش، لیست رفرش شود
						LoadData();
					}
				}
			}
		}
		#endregion

		#region Helper Methods

		private void LoadData()
		{
			try
			{
				// 1. دریافت اطلاعات خام از دیتابیس
				var invoices = _invoiceRepository.SearchInvoices(SerialTextBox.Text, customerTextBox.Text, _currentSortOrder);

				// 2. تبدیل لیست Models به لیست ViewModels (آماده‌سازی برای نمایش)
				var viewModels = invoices.Select(current => new ViewModels.InvoiceViewModel
				{
					Id = current.Id,
					SerialNumber = current.SerialNumber,
					CustomerName = current.Customer?.FullName ?? "نامشخص",
					Description = current.Description,
					// جادوی Common: تبدیل تاریخ به شمسی
					DateJalali = current.Date.ToJalali(),
					// جادوی 3 رقم 3 رقم مستقیما در زمان پاس دادن به ViewModel
					FinalAmount = current.FinalAmount.ToString("N0")
				}).ToList();

				// 3. اتصال به گریدویو
				invoiceDataGridView.DataSource = viewModels;

				// مخفی کردن ستون Id اگر هنوز پیداست
				if (invoiceDataGridView.Columns["Id"] != null)
				{
					invoiceDataGridView.Columns["Id"].Visible = false;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "خطا در واکشی فاکتورها", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void SelectAndClose()
		{
			if (invoiceDataGridView.CurrentRow != null)
			{
				// 💥 استخراج اصولی دیتا 💥
				var selectedInvoice = invoiceDataGridView.CurrentRow.DataBoundItem as ViewModels.InvoiceViewModel;

				if (selectedInvoice != null)
				{
					SelectedInvoiceId = selectedInvoice.Id;
					this.DialogResult = DialogResult.OK;
				}
			}
			else
			{
				MessageBox.Show("لطفا یک فاکتور را انتخاب کنید.", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}
		#endregion


	}
}
using Common;
using Crm.App.Customer;
using Models;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace Crm.App
{
	public partial class InvoiceForm : Form
	{

		// ********** متغیرهای لایه دیتابیس **********
		private DAL.IInvoiceRepository _invoiceRepository;
		// **********

		// ********** متغیرهای مدیریت وضعیت فرم **********
		public enum FormState { View, Insert, Update }
		private FormState _currentState;
		private bool _isDirty = false;

		// نگهداری اطلاعات فاکتور و مشتری جاری
		private Guid? _currentInvoiceId = null;
		private Guid? _selectedCustomerId = null;
		// **********

		// ********** لیست جادویی برای مدیریت سطرهای گریدویو **********
		private BindingList<InvoiceItem> _invoiceItems;
		// **********

		// **********
		CustomersForm customersForm;
		// **********

		public InvoiceForm()
		{
			InitializeComponent();

			// وهله‌سازی ریپوزیتوری
			_invoiceRepository = new DAL.InvoiceRepository();

			// تنظیمات گریدویو
			itemDataGridView.AutoGenerateColumns = false;
			itemDataGridView.AllowUserToAddRows = false; // جلوگیری از سطر خالی مزاحم

			// اتصال ستون‌های دیزاینر به پراپرتی‌های کلاس InvoiceItem
			productCodeColumn.DataPropertyName = "ProductCode"; 
			productNameColumn.DataPropertyName = "ProductName";
			//productNameColumn.DataPropertyName = "Product.Name";


			quantityColumn.DataPropertyName = "Quantity";
			amountColumn.DataPropertyName = "UnitPrice";
			discountColumn.DataPropertyName = "DiscountAmount";
			taxColumn.DataPropertyName = "TaxAmount";
			totalColumn.DataPropertyName = "RowTotalAmount";

			// فرمت ۳ رقم ۳ رقم برای ستون‌های مالی در گریدویو
			amountColumn.DefaultCellStyle.Format = "N0";
			discountColumn.DefaultCellStyle.Format = "N0";
			taxColumn.DefaultCellStyle.Format = "N0";
			totalColumn.DefaultCellStyle.Format = "N0";

			// راه‌اندازی لیست و اتصال به گریدویو
			_invoiceItems = new BindingList<InvoiceItem>();
			itemDataGridView.DataSource = _invoiceItems;

			// هر زمان لیست تغییر کرد (حذف، اضافه، ویرایش مقدار)، جمع کل را دوباره حساب کن
			_invoiceItems.ListChanged += _invoiceItems_ListChanged;
			customersForm = new CustomersForm();
		}

		private void InvoiceForm_Load(object sender, EventArgs e)
		{
			SetFormState(FormState.View);
		}

		#region State Machine & UI Management

		// تغییر وضعیت دکمه‌ها و پنل‌ها
		private void SetFormState(FormState state)
		{
			_currentState = state;

			bool isEditing = (state == FormState.Insert || state == FormState.Update);

			// مدیریت پنل‌ها
			headerPanel.Enabled = isEditing;
			detailPanel.Enabled = isEditing;
			submitButton.Enabled = isEditing;
			cancelButton.Enabled = isEditing;

			// مدیریت دکمه‌های بالا
			newButton.Enabled = true; // کاربر همیشه می‌تواند فاکتور جدید بزند
			editButton.Enabled = !isEditing && _currentInvoiceId.HasValue;
			deleteButton.Enabled = !isEditing && _currentInvoiceId.HasValue;

			if (state == FormState.Insert)
			{
				ClearForm();
				dateMaskedTextBox.Text = DateTime.Now.ToJalali();

				// 💥 گرفتن شماره سریال اتوماتیک از دیتابیس 💥
				serialNumberTextBox.Text = _invoiceRepository.GetNextSerialNumber().ToString();

				AddEmptyRow();
			}
		}

		private void ClearForm()
		{
			_currentInvoiceId = null;
			_selectedCustomerId = null;

			serialNumberTextBox.Text = string.Empty;
			customerTextBox.Text = string.Empty;
			dateMaskedTextBox.Text = string.Empty;
			textBox1.Text = string.Empty; // توضیحات

			_invoiceItems.Clear(); // پاک کردن سطرها

			CalculateTotals(); // صفر کردن لیبل‌های پایین
			_isDirty = false;
		}

		private bool CheckUnsavedChanges()
		{
			if (_isDirty)
			{
				DialogResult result = MessageBox.Show(
					"اطلاعات فعلی ذخیره نشده است. آیا مایلید فاکتور فعلی را رها کنید؟",
					"هشدار", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

				return result == DialogResult.Yes;
			}
			return true;
		}

		// محاسبه جمع مبالغ پایین فرم
		private void CalculateTotals()
		{
			decimal totalSub = 0;
			decimal totalTax = 0;
			decimal totalDiscount = 0; // فعلا فقط تخفیفات سطری

			foreach (var item in _invoiceItems)
			{
				totalSub += (item.Quantity * item.UnitPrice);
				totalTax += item.TaxAmount;
				totalDiscount += item.DiscountAmount;
			}

			decimal finalAmount = (totalSub - totalDiscount) + totalTax;

			// نمایش با فرمت 3 رقم 3 رقم
			sumLabel.Text = totalSub.ToString("N0");
			sumTaxLabel.Text = totalTax.ToString("N0");
			takhfifLabel.Text = totalDiscount.ToString("N0");
			TotalSumlabel.Text = finalAmount.ToString("N0");
		}

		private void _invoiceItems_ListChanged(object sender, ListChangedEventArgs e)
		{
			// هر تغییری در گریدویو باعث آپدیت شدن مبالغ پایین می‌شود
			CalculateTotals();
			_isDirty = true;
		}

		// این رویداد برای زمانی است که کاربر دستی عددی را در گرید عوض می‌کند تا سریعاً مبلغ آپدیت شود
		private void itemDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0)
			{
				// رفرش کردن گریدویو برای نمایش تغییرات محاسباتی سطر
				itemDataGridView.Refresh();
				CalculateTotals();
			}
		}

		#endregion

		#region Buttons (CRUD)

		private void NewButton_Click(object sender, EventArgs e)
		{
			if (CheckUnsavedChanges())
				SetFormState(FormState.Insert);
		}

		private void EditButton_Click(object sender, EventArgs e)
		{
			SetFormState(FormState.Update);
		}

		private void DeleteButton_Click(object sender, EventArgs e)
		{
			if (_currentInvoiceId.HasValue)
			{
				if (MessageBox.Show("آیا از حذف این فاکتور مطمئن هستید؟", "تایید", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					try
					{
						_invoiceRepository.DeleteInvoice(_currentInvoiceId.Value);
						MessageBox.Show("فاکتور با موفقیت حذف شد.", "موفق", MessageBoxButtons.OK, MessageBoxIcon.Information);
						SetFormState(FormState.View);
						ClearForm();
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message, "خطا در حذف", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
			}
		}

		private void CancelButton_Click(object sender, EventArgs e)
		{
			SetFormState(FormState.View);
			// در دنیای واقعی اینجا باید اطلاعات فاکتور قبلی را دوباره از دیتابیس لود کنیم
			// فعلا برای سادگی فرم را خالی می‌کنیم
			ClearForm();
		}

		private void SubmitButton_Click(object sender, EventArgs e)
		{
			// 1. اعتبارسنجی
			if (!_selectedCustomerId.HasValue)
			{
				MessageBox.Show("لطفاً یک مشتری انتخاب کنید.", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				customerTextBox.Focus();
				return;
			}
			if (string.IsNullOrWhiteSpace(serialNumberTextBox.Text) || !int.TryParse(serialNumberTextBox.Text, out int serial))
			{
				MessageBox.Show("شماره سریال معتبر نیست.", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				serialNumberTextBox.Focus();
				return;
			}
			DateTime? invoiceDate = dateMaskedTextBox.Text.ToGregorian();
			if (invoiceDate == null)
			{
				MessageBox.Show("تاریخ فاکتور نامعتبر است.", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				dateMaskedTextBox.Focus();
				return;
			}
			if (_invoiceItems.Count == 0)
			{
				MessageBox.Show("فاکتور نمی‌تواند بدون کالا باشد.", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			// 2. بررسی سریال تکراری
			if (_invoiceRepository.IsSerialNumberExist(serial, _currentInvoiceId))
			{
				// 💥 سوال از کاربر برای تولید سریال سیستمی 💥
				DialogResult result = MessageBox.Show(
					"این شماره سریال قبلاً در سیستم ثبت شده است.\nآیا مایل هستید سیستم به صورت خودکار شماره سریال بعدی را اختصاص دهد؟",
					"سریال تکراری",
					MessageBoxButtons.YesNo,
					MessageBoxIcon.Question);

				if (result == DialogResult.Yes)
				{
					// دریافت سریال جدید و نمایش روی فرم
					serialNumberTextBox.Text = _invoiceRepository.GetNextSerialNumber().ToString();
					// خروج از متد تا کاربر سریال جدید را ببیند و دوباره دکمه تایید را بزند
					return;
				}
				else
				{
					serialNumberTextBox.Focus();
					return;
				}
			}

			// دور ریختن سطرهای خالی
			var validItems = _invoiceItems.Where(i => i.ProductId != Guid.Empty).ToList();

			if (validItems.Count == 0)
			{
				MessageBox.Show("فاکتور نمی‌تواند بدون کالا باشد.", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			// 🔥 راه حل طلایی: ساخت یک لیست کپی و تمیز فقط برای ارسال به دیتابیس 🔥
			// با این کار شیء متصل به گریدویو دستکاری نمی‌شود و نام کالاها روی صفحه می‌ماند
			var itemsForDb = new System.Collections.Generic.List<Models.InvoiceItem>();
			foreach (var item in validItems)
			{
				itemsForDb.Add(new Models.InvoiceItem
				{
					// اگر آیدی سطر خالی بود (یعنی جدید است)، آیدی جدید می‌دهیم
					Id = item.Id == Guid.Empty ? Guid.NewGuid() : item.Id,

					InvoiceId = _currentInvoiceId ?? Guid.Empty,

					ProductId = item.ProductId,
					Quantity = item.Quantity,
					UnitPrice = item.UnitPrice,
					DiscountAmount = item.DiscountAmount,
					TaxAmount = item.TaxAmount,
					Description = item.Description
				});
			}

			try
			{
				// 3. ساخت مدل فاکتور با استفاده از لیست تمیز شده
				Invoice invoice = new Invoice
				{
					Id = _currentInvoiceId ?? Guid.NewGuid(),
					SerialNumber = serial,
					Date = invoiceDate.Value,
					CustomerId = _selectedCustomerId.Value,
					Description = textBox1.Text,
					TotalDiscount = 0,
					InvoiceItems = itemsForDb // 👈 لیست جدید را اینجا می‌دهیم
				};

				// 4. ارسال به دیتابیس
				if (_currentState == FormState.Insert)
					_invoiceRepository.CreateInvoice(invoice);
				else if (_currentState == FormState.Update)
					_invoiceRepository.UpdateInvoice(invoice);

				MessageBox.Show("فاکتور با موفقیت ثبت شد.", "موفق", MessageBoxButtons.OK, MessageBoxIcon.Information);
				// 💥 راه حل مشکل سطر خالی: حذف سطر خالی از گریدویو بعد از ثبت موفقیت آمیز
				var emptyRow = _invoiceItems.FirstOrDefault(i => i.ProductId == Guid.Empty);
				if (emptyRow != null)
				{
					_invoiceItems.Remove(emptyRow);
				}
				_currentInvoiceId = invoice.Id;
				_isDirty = false;
				SetFormState(FormState.View);
			}
			catch (Exception ex)
			{
				// این کد ارور اصلی که در اعماق EF گیر کرده را بیرون می‌کشد!
				string errorMsg = ex.Message;
				if (ex.InnerException != null)
				{
					errorMsg += "\nجزئیات: " + ex.InnerException.Message;
					if (ex.InnerException.InnerException != null)
					{
						errorMsg += "\nعلت اصلی: " + ex.InnerException.InnerException.Message;
					}
				}

				MessageBox.Show(errorMsg, "خطا در ثبت", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		#endregion

		#region Selection Events (Space / DoubleClick)

		// باز کردن فرم مشتری با دابل کلیک یا Space
		private void CustomerTextBox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Space && _currentState != FormState.View)
			{
				SelectCustomer();
				e.Handled = true;
				e.SuppressKeyPress = true; // جلوگیری از تایپ شدن Space در تکست‌باکس
			}
		}

		private void CustomerTextBox_DoubleClick(object sender, EventArgs e)
		{
			if (_currentState != FormState.View) SelectCustomer();
		}

		private void SelectCustomer()
		{
			// فرض می‌کنیم فرم FormCustomers را طوری تغییر داده‌اید که اگر به عنوان دیالوگ باز شد، 
			// بتواند آیدی و نام مشتری را برگرداند (مثل کاری که با PeopleForm کردیم)
			Customer.CustomersForm frm = new Customer.CustomersForm();
			frm.IsSelectionMode = true; // این پراپرتی را باید در فرم مشتریان ایجاد کنید

			if (frm.ShowDialog() == DialogResult.OK)
			{
				_selectedCustomerId = frm.SelectedCustomerId;
				customerTextBox.Text = frm.SelectedCustomerName;
				_isDirty = true;
			}
		}

		// باز کردن فرم کالاها با زدن Space روی گریدویو یا کلید Insert
		// **********
		private void ItemDataGridView_KeyDown(object sender, KeyEventArgs e)
		{
			if (_currentState == FormState.View)
				return;

			// 1. باز کردن فرم انتخاب کالا با Space
			if (e.KeyCode == Keys.Space && itemDataGridView.CurrentCell != null)
			{
				string colName = itemDataGridView.Columns[itemDataGridView.CurrentCell.ColumnIndex].Name;
				if (colName == "productCodeColumn" || colName == "productNameColumn")
				{
					SelectProduct(itemDataGridView.CurrentCell.RowIndex);
					e.Handled = true;
				}
			}
			// 2. امکان حذف سطر با دکمه Delete
			else if (e.KeyCode == Keys.Delete && itemDataGridView.CurrentRow != null)
			{
				_invoiceItems.RemoveAt(itemDataGridView.CurrentRow.Index);

				// اگر همه سطرها پاک شد، یک سطر خالی می‌سازیم تا کاربر گیر نکند
				if (_invoiceItems.Count == 0) AddEmptyRow();
			}
			// 💥 3. ساخت سطر جدید با زدن دکمه جهت پایین (Down Arrow) 💥
			else if (e.KeyCode == Keys.Down)
			{
				// بررسی می‌کنیم که آیا روی آخرین سطرِ گرید هستیم؟
				if (itemDataGridView.CurrentRow != null &&
					itemDataGridView.CurrentRow.Index == itemDataGridView.Rows.Count - 1)
				{
					// فقط در صورتی سطر جدید می‌سازیم که سطر آخر خودش خالی نباشد!
					if (_invoiceItems.Last().ProductId != Guid.Empty)
					{
						AddEmptyRow();

						// انتقال اتوماتیک نشانگر (فوکوس) به سطر جدید ساخته شده
						int newRowIndex = itemDataGridView.Rows.Count - 1;
						itemDataGridView.CurrentCell = itemDataGridView.Rows[newRowIndex].Cells["productNameColumn"];
						e.Handled = true;
					}
				}
			}
		}
		// **********

		private void AddEmptyRow()
		{
			//چک میکنیم لیست خالی است، یا آخرین سطر لیسا کالا دارد، یک سطر خالی جدید بساز
			if (_invoiceItems.Count == 0 || _invoiceItems.Last().ProductId != Guid.Empty)
			{
				_invoiceItems.Add
					(new Models.InvoiceItem
					{
						ProductId = Guid.Empty, // این یعنی سطر هنوز خالی است
						Quantity = 1
					});
			}
		}

		//private void SelectProduct(int rowIndex)
		//{
		//	// باز کردن فرم کالاها برای انتخاب
		//	CommoditiesForm frm = new CommoditiesForm();
		//	frm.IsSelectionMode = true; // باید این قابلیت را به فرم کالا اضافه کنید

		//	if (frm.ShowDialog() == DialogResult.OK)
		//	{
		//		var currentItem =
		//			_invoiceItems[rowIndex];
		//		//Guid prodId = frm.SelectedProductId;
		//		//string prodName = frm.SelectedProductName;
		//		//decimal defPrice = frm.SelectedDefaultPrice;

		//		currentItem.ProductId = frm.SelectedProductId;
		//		//currentItem.
		//		currentItem.Product = new Models.Commodity { Name = frm.SelectedProductName };
		//		currentItem.UnitPrice = frm.SelectedDefaultPrice;
		//		currentItem.TaxAmount =
		//			(frm.IsTaxable) ? (frm.SelectedDefaultPrice * frm.SelectedTaxPercentage / 100) : 0;

		//		// رفرش گرید و آپدیت مبالغ پایین فرم
		//		itemDataGridView.Refresh();
		//		CalculateTotals();

		//		// ساخت یک سطر خالی 
		//		AddEmptyRow();

		//		/* موقتا با دیتای تستی پر می‌کنیم تا شما فرم انتخاب کالا را تکمیل کنید
		//		InvoiceItem newItem = new InvoiceItem
		//		{
		//			Id = Guid.NewGuid(),
		//			ProductId = prodId,
		//			Product = new Commodity { Name = prodName }, // برای نمایش نام در گرید
		//			Quantity = 1,
		//			UnitPrice = defPrice,
		//			DiscountAmount = 0,
		//			TaxAmount = 0
		//		};

		//		_invoiceItems.Add(newItem);
		//		_isDirty = true;
		//		*/
		//	}
		//}

		private void SelectProduct(int rowIndex)
		{
			CommoditiesForm frm = new CommoditiesForm();
			frm.IsSelectionMode = true;

			if (frm.ShowDialog() == DialogResult.OK)
			{
				var currentItem = _invoiceItems[rowIndex];

				currentItem.ProductId = frm.SelectedProductId;

				// اینجا هم نام و هم کد کالا را به شیء مجازی می‌دهیم تا گریدویو آن را بخواند
				currentItem.Product = new Models.Commodity
				{
					Code = frm.SelectedProductCode,
					Name = frm.SelectedProductName
				};

				currentItem.UnitPrice = frm.SelectedDefaultPrice;

				// محاسبه مالیات بر اساس قیمت پیش‌فرض
				currentItem.TaxAmount = (frm.IsTaxable) ? (frm.SelectedDefaultPrice * frm.SelectedTaxPercentage / 100) : 0;

				itemDataGridView.Refresh();
				CalculateTotals();

				//AddEmptyRow();
			}
		}

		#endregion

		// **********
		private void ItemDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (_currentState == FormState.View || e.RowIndex < 0)
				return;
			// نام ستونی که کاربر روی آن کلیک کرده
			string colName =
				itemDataGridView.Columns[e.ColumnIndex].Name;

			// بررسی اینکه آیا روی ستون کد کالا یا نام کالا کلیک شده؟
			if (colName == "productCodeColumn" || colName == "productNameColumn")
			{
				SelectProduct(e.RowIndex);
				//MessageBox.Show(colName);
			}
		}

		private void ListButton_Click(object sender, EventArgs e)
		{
			InvoiceListForm invoiceListForm = new InvoiceListForm();
			invoiceListForm.ShowDialog();
		}
		// **********

		// **********
		/// <summary>
		/// این متد از بیرون (مثلا فرم لیست فاکتورها) صدا زده می‌شود
		/// تا فاکتور از دیتابیس خوانده شده و روی صفحه نمایش داده شود
		/// </summary>
		public void LoadInvoiceForEdit(Guid invoiceId)
		{
			try
			{
				// 1. خواندن فاکتور از دیتابیس (به همراه مشتری و اقلام)
				var invoice = _invoiceRepository.GetInvoiceById(invoiceId);

				if (invoice == null)
				{
					MessageBox.Show("فاکتور مورد نظر یافت نشد!", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
				
				// 2. پر کردن متغیرهای مخفی فرم
				_currentInvoiceId = invoice.Id;
				_selectedCustomerId = invoice.CustomerId;

				// 3. پر کردن هدر (تکست‌باکس‌ها)
				serialNumberTextBox.Text = invoice.SerialNumber.ToString();
				customerTextBox.Text = invoice.Customer.FullName;
				dateMaskedTextBox.Text = invoice.Date.ToJalali(); // جادوی تبدیل تاریخ!
				textBox1.Text = invoice.Description;

				// 4. پر کردن گریدویو
				_invoiceItems.Clear(); // اول لیست را خالی می‌کنیم
				foreach (var item in invoice.InvoiceItems)
				{
					// به خاطر Include در لایه DAL، مدل Product همراه با Name و Code لود شده است
					// پس وقتی به لیست اضافه می‌کنیم، گریدویو نام و کد کالا را به درستی نشان می‌دهد
					_invoiceItems.Add(item);
				}
				//AddEmptyRow();

				CalculateTotals();

				// 5. فرم را در حالت فقط‌خواندنی قرار می‌دهیم تا کاربر خودش دکمه ویرایش را بزند
				SetFormState(FormState.View);
				_isDirty = false;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "خطا در لود فاکتور", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		// **********

	}
}
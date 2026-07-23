using System;
using System.Windows.Forms;

namespace Crm.App
{
	/// <summary>
	/// فرم ثبت کالای جدید یا ویرایش اطلاعات کالای موجود
	/// این فرم کاملا مستقل از دیتابیس (بدون لایه DAL) طراحی شده است
	/// و وظیفه ارتباط با دیتابیس بر عهده فرم پدر (CommoditiesForm) می‌باشد
	/// </summary>
	public partial class CreateOrEditCommodityForm : Form
	{
		// **********
		/// <summary>
		/// متد سازنده فرم
		/// </summary>
		public CreateOrEditCommodityForm()
		{
			InitializeComponent();
		}
		// **********

		// **********
		/// <summary>
		/// یک شمارشی (Enum) برای مشخص کردن وضعیت فرم (ثبت رکورد جدید یا آپدیت رکورد قبلی)
		/// </summary>
		public enum FormOperation
		{
			Insert,
			Update
		}
		// **********

		#region Properties

		// **********
		// فیلد پشتیبان برای وضعیت فرم
		private FormOperation _state;

		/// <summary>
		/// وضعیت فعلی فرم را نگهداری می‌کند
		/// </summary>
		public FormOperation State
		{
			get { return _state; }
			set { _state = value; }
		}
		// **********

		// **********
		/// <summary>
		/// شناسه کالا (در حالت ویرایش، فرم پدر این شناسه را مقداردهی می‌کند)
		/// </summary>
		public Guid IdCommodity { get; set; }
		// **********

		// **********
		/// <summary>
		/// کد کالا (به صورت مستقیم به تکست‌باکس روی فرم متصل شده است)
		/// با این روش نیازی به متغیر واسطه نداریم
		/// </summary>
		public string CodeCommodity
		{
			get
			{
				return codeTextBox.Text;
			}
			set
			{
				codeTextBox.Text = value;
			}
		}
		// **********

		// **********
		/// <summary>
		/// نام کالا (به صورت مستقیم به تکست‌باکس روی فرم متصل شده است)
		/// </summary>
		public string NameCommodity
		{
			get
			{
				return nameTextBox.Text;
			}
			set
			{
				nameTextBox.Text = value;
			}
		}
		// **********

		// **********
		public decimal DefaultPrice
		{
			get
			{
				return defaultPriceNumericUpDown.Value;
			}
			set
			{
				defaultPriceNumericUpDown.Value = value;
			}
		}
		// **********

		// **********
		public bool IsTaxable
		{
			get
			{
				return isTaxableCheckBox.Checked;
			}
			set
			{
				isTaxableCheckBox.Checked = value;
			}
		}
		// **********

		// **********
		public decimal TaxPercentage
		{
			get
			{
				return taxPercentageNumericUpDown.Value;
			}
			set
			{
				taxPercentageNumericUpDown.Value= value;
			}
		}
		// **********
		#endregion

		// **********
		/// <summary>
		/// رویداد بارگذاری (Load) فرم
		/// </summary>
		private void CreateOrEditCommoditiesForm_Load(object sender, EventArgs e)
		{
			// تنظیم عنوان فرم (Text) برای راهنمایی بهتر کاربر بر اساس وضعیت فرم
			if (State == FormOperation.Insert)
			{
				this.Text = "افزودن کالای جدید";
			}
			else if (State == FormOperation.Update)
			{
				this.Text = "ویرایش اطلاعات کالا";

				// نکته آموزشی معماری:
				// در کدهای قبلی شما، اینجا یک Select به دیتابیس زده شده بود.
				// اما چون فرم پدر (CommoditiesForm) مقادیر CodeCommodity و NameCommodity را 
				// قبل از باز شدن این فرم پر کرده است، نیازی به ارتباط مجدد با دیتابیس نیست!
				// حذف کدهای EF از اینجا باعث می‌شود فرم شما با بالاترین سرعت ممکن باز شود.
			}
		}
		// **********

		// **********
		/// <summary>
		/// رویداد کلیک دکمه تایید / ثبت
		/// </summary>
		private void SubmitButton_Click(object sender, EventArgs e)
		{
			// این دکمه فقط نتیجه فرم (DialogResult) را برابر OK قرار می‌دهد.
			// با این کار فرم بسته شده و فرم پدر متوجه می‌شود که کاربر عملیات را تایید کرده است
			// تا اطلاعات را از طریق پراپرتی‌ها خوانده و در دیتابیس ثبت کند.
			this.DialogResult = System.Windows.Forms.DialogResult.OK;
		}
		// **********
	}
}
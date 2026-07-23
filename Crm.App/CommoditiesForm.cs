using System;
using System.Windows.Forms;

namespace Crm.App
{
	/// <summary>
	/// فرم مدیریت کالاها (نمایش لیست، افزودن، ویرایش و حذف)
	/// </summary>
	public partial class CommoditiesForm : Form
	{
		// **********
		// تعریف شیء از کلاس ریپوزیتوری برای ارتباط با لایه دیتابیس
		private DAL.CommodityRepository _commodityRepository;
		// **********

		// **********
		/// <summary>
		/// متد سازنده فرم
		/// </summary>
		public CommoditiesForm()
		{
			InitializeComponent();

			// وهله‌سازی ریپوزیتوری
			_commodityRepository = new DAL.CommodityRepository();
		}
		// **********
		public bool IsSelectionMode { get; set; }
		// **********

		// **********
		public string SelectedProductCode { get; set; }
		// **********

		// **********
		public Guid SelectedProductId { get; set; }
		// **********

		// **********
		public string SelectedProductName { get; set; }
		// **********

		// **********
		public decimal SelectedDefaultPrice { get; set; }
		// **********

		// **********
		public bool IsTaxable { get; set; }
		// **********

		// **********
		public decimal SelectedTaxPercentage { get; set; }
		// **********

		// **********
		/// <summary>
		/// رویداد لود شدن فرم. در ابتدا لیست کالاها را در گریدویو نمایش می‌دهد
		/// </summary>
		private void CommoditiesForm_Load(object sender, EventArgs e)
		{
			LoadData();
		}
		// **********

		// **********
		/// <summary>
		/// رویداد کلیک روی دکمه ثبت کالای جدید
		/// </summary>
		private void CreateButton_Click(object sender, EventArgs e)
		{
			// باز کردن فرم ایجاد/ویرایش در حالت Insert
			CreateOrEditCommodityForm createCommodityForm = new CreateOrEditCommodityForm();
			createCommodityForm.State = CreateOrEditCommodityForm.FormOperation.Insert;

			if (createCommodityForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				try
				{
					// ارسال اطلاعات به لایه DAL برای ثبت در دیتابیس
					_commodityRepository.CreateCommodity
						(
							code: createCommodityForm.CodeCommodity,
							name: createCommodityForm.NameCommodity,
							defaultPrice: createCommodityForm.DefaultPrice,
							isTaxable: createCommodityForm.IsTaxable,
							taxPercentage: createCommodityForm.TaxPercentage
						);

					MessageBox.Show("ثبت کالا با موفقیت انجام شد.", "عملیات موفق", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				catch (Exception ex)
				{
					// نمایش خطاهای احتمالی (مثل تکراری بودن کد کالا)
					MessageBox.Show(ex.Message, "خطا در ثبت", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}

			// در هر صورت بعد از بسته شدن فرم ثبت، لیست را رفرش می‌کنیم
			LoadData();
		}
		// **********

		// **********
		/// <summary>
		/// رویداد کلیک روی دکمه ویرایش کالای انتخاب شده
		/// </summary>
		private void EditButton_Click(object sender, EventArgs e)
		{
			// بررسی اینکه آیا رکوردی در گریدویو انتخاب شده است یا خیر
			if (CommoditiesDataGridView.CurrentRow == null)
				return;

			try
			{
				// استخراج شناسه کالای انتخاب شده از گریدویو
				System.Guid selectedId = Guid.Parse(CommoditiesDataGridView.CurrentRow.Cells["Id"].Value.ToString());

				// واکشی اطلاعات کالا از دیتابیس جهت نمایش در فرم ویرایش
				var selectCommodity = _commodityRepository.GetCommodityById(commodityId: selectedId);

				if (selectCommodity == null)
				{
					MessageBox.Show("کالای مورد نظر یافت نشد!", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}

				// آماده‌سازی فرم ویرایش و پاس دادن اطلاعات به آن
				CreateOrEditCommodityForm editForm = new CreateOrEditCommodityForm()
				{
					State = CreateOrEditCommodityForm.FormOperation.Update,
					IdCommodity = selectCommodity.Id,
					CodeCommodity = selectCommodity.Code,
					NameCommodity = selectCommodity.Name,
					DefaultPrice = selectCommodity.DefaultPrice,
					IsTaxable = selectCommodity.IsTaxable,
					TaxPercentage = selectCommodity.TaxPercentage,
				};

				// اگر کاربر دکمه تایید فرم ویرایش را زد
				if (editForm.ShowDialog() == DialogResult.OK)
				{
					// ارسال اطلاعات جدید به لایه DAL جهت آپدیت دیتابیس
					_commodityRepository.EditCommodity
						(
							commodityId: editForm.IdCommodity,
							code: editForm.CodeCommodity,
							name: editForm.NameCommodity,
							defaultPrice: editForm.DefaultPrice,
							isTaxable: editForm.IsTaxable,
							taxPercentage: editForm.TaxPercentage
						);

					MessageBox.Show("ویرایش کالا با موفقیت انجام شد.", "عملیات موفق", MessageBoxButtons.OK, MessageBoxIcon.Information);
					LoadData();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "خطا در ویرایش", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		// **********

		// **********
		/// <summary>
		/// رویداد کلیک روی دکمه حذف کالا
		/// </summary>
		private void DeleteButton_Click(object sender, EventArgs e)
		{
			// بررسی انتخاب سطر
			if (CommoditiesDataGridView.CurrentRow == null)
				return;

			try
			{
				// دریافت شناسه سطر انتخابی
				System.Guid selectedId = Guid.Parse(CommoditiesDataGridView.CurrentRow.Cells["Id"].Value.ToString());

				// گرفتن تاییدیه از کاربر قبل از حذف (تکنیک مهم در UI)
				if (MessageBox.Show("آیا از حذف این کالا مطمئن هستید؟", "تایید حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					// ارجاع به لایه DAL برای حذف رکورد
					_commodityRepository.DeleteCommodity(commodityId: selectedId);

					// رفرش کردن گریدویو
					LoadData();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "خطا در حذف", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		// **********

		// **********
		/// <summary>
		/// رویداد کلیک روی دکمه تازه‌سازی (رفرش) اطلاعات
		/// </summary>
		private void refreshButton_Click(object sender, EventArgs e)
		{
			LoadData();
		}
		// **********

		// **********
		/// <summary>
		/// رویداد تغییر متن در تکست‌باکس جستجو (فیلتر زنده)
		/// </summary>
		private void FilterTextBox_TextChanged(object sender, EventArgs e)
		{
			// با هر بار تایپ حرف جدید، متد LoadData فراخوانی شده و متن را فیلتر می‌کند
			LoadData();
		}
		// **********

		#region Helper Methods

		// **********
		/// <summary>
		/// یک متد متمرکز برای واکشی کالاها و اتصال آن‌ها به گریدویو
		/// این متد جایگزین GetCommodities و کدهای تکراری در Filter شده است
		/// </summary>
		private void LoadData()
		{
			try
			{
				// دریافت اطلاعات از لایه Repository (متن فیلتر هم مستقیماً پاس داده می‌شود)
				var commodities = _commodityRepository.GetCommodities(filterText: filterTextBox.Text);

				// اتصال اطلاعات به گریدویو
				CommoditiesDataGridView.DataSource = commodities;

				// مخفی کردن ستون کلید اصلی از دید کاربر
				if (CommoditiesDataGridView.Columns["Id"] != null)
				{
					CommoditiesDataGridView.Columns["Id"].Visible = false;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "خطا در واکشی اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		// **********

		#endregion

		private void CommoditiesDataGridView_DoubleClick(object sender, EventArgs e)
		{
			if (IsSelectionMode)
			{
				if (CommoditiesDataGridView.CurrentRow == null)
					return;
				System.Guid selectedId = Guid.Parse(CommoditiesDataGridView.CurrentRow.Cells["Id"].Value.ToString());
				var selectCommodity = _commodityRepository.GetCommodityById(commodityId: selectedId);
				SelectedProductId = selectCommodity.Id;
				SelectedProductCode = selectCommodity.Code;
				SelectedProductName = selectCommodity.Name;
				SelectedDefaultPrice = selectCommodity.DefaultPrice;
				IsTaxable = selectCommodity.IsTaxable;
				SelectedTaxPercentage = selectCommodity.TaxPercentage;
				//MessageBox.Show($"{SelectedProductId} - {SelectedProductName} - {SelectedDefaultPrice} " +
				//	$"- {IsTaxable} - {SelectedTaxPercentage} ");
				this.DialogResult = DialogResult.OK;
			}
		}
	}
}
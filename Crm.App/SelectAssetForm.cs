using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Crm.App
{
	public partial class SelectAssetForm : Form
	{
		private DAL.ICustomerRepository _customerRepository;
		private Guid _customerId;

		// لیستی برای نگهداری لایسنس‌هایی که کاربر تیک زده است
		public List<CustomerAsset> SelectedAssets { get; private set; }

		// سازنده فرم شناسه مشتری را دریافت می‌کند
		public SelectAssetForm(Guid customerId)
		{
			InitializeComponent();

			_customerRepository = new DAL.CustomerRepository();
			_customerId = customerId;
			SelectedAssets = new List<CustomerAsset>();

			SetupGridView();
			LoadCustomerAssets();
		}

		private void SetupGridView()
		{
			assetDataGridView.AutoGenerateColumns = false;
			assetDataGridView.AllowUserToAddRows = false;
			assetDataGridView.RowHeadersVisible = false;

			// 💥 جادوی اضافه کردن ستون CheckBox از طریق کد 💥
			DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn
			{
				Name = "chkSelect",
				HeaderText = "انتخاب",
				Width = 50,
				ReadOnly = false // فقط این ستون قابل ویرایش است
			};
			assetDataGridView.Columns.Add(checkColumn);

			assetDataGridView.Columns.Add(new DataGridViewTextBoxColumn
			{
				Name = "productName",
				HeaderText = "نام نرم‌افزار",
				//DataPropertyName = "Product.Name", // <--- این اشتباه بود
				DataPropertyName = "ProductName",     // <--- این درست است
				Width = 200,
				ReadOnly = true
			});
			assetDataGridView.Columns.Add(new DataGridViewTextBoxColumn
			{
				Name = "serial",
				HeaderText = "سریال/دانگل",
				DataPropertyName = "SoftwareSerial",
				Width = 150,
				ReadOnly = true
			});
		}

		private void LoadCustomerAssets()
		{
			try
			{
				var assets = _customerRepository.GetCustomerAssets(_customerId);
				assetDataGridView.DataSource = assets;

				if (assets.Count == 0)
				{
					MessageBox.Show("هیچ لایسنس/نرم‌افزاری برای این مشتری یافت نشد!", "اطلاع", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "خطا در واکشی اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		// رویداد کلیک روی دکمه تایید
		private void ConfirmButton_Click(object sender, EventArgs e)
		{
			SelectedAssets.Clear();

			// پیمایش روی تمام سطرهای گریدویو
			foreach (DataGridViewRow row in assetDataGridView.Rows)
			{
				// بررسی می‌کنیم آیا تیکِ ستون اول خورده است یا خیر؟
				bool isChecked = Convert.ToBoolean(row.Cells["chkSelect"].Value);
				if (isChecked)
				{
					// اگر تیک خورده بود، آن لایسنس را به لیست خروجی اضافه می‌کنیم
					var asset = row.DataBoundItem as CustomerAsset;
					if (asset != null)
					{
						SelectedAssets.Add(asset);
					}
				}
			}

			// ********** این خط فراموش شده بود! **********
			// بستن فرم و ارسال تاییدیه به فرم قرارداد
			this.DialogResult = DialogResult.OK;
			// *********************************************
		}
		private void SelectAssetForm_Load(object sender, EventArgs e)
		{
		
		}
	}
}

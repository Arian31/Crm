namespace Crm.App.Customer
{
	partial class CustomersForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.createButton = new System.Windows.Forms.ToolStripButton();
			this.editButton = new System.Windows.Forms.ToolStripButton();
			this.deleteButton = new System.Windows.Forms.ToolStripButton();
			this.refreshButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
			this.filterTextBox = new System.Windows.Forms.ToolStripTextBox();
			this.lastPageButton = new System.Windows.Forms.ToolStripButton();
			this.nextPageButton = new System.Windows.Forms.ToolStripButton();
			this.previousPageButton = new System.Windows.Forms.ToolStripButton();
			this.firstPageButton = new System.Windows.Forms.ToolStripButton();
			this.PageInfoLabel = new System.Windows.Forms.ToolStripLabel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.customersDataGridView = new System.Windows.Forms.DataGridView();
			this.toolStrip1.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.customersDataGridView)).BeginInit();
			this.SuspendLayout();
			// 
			// toolStrip1
			// 
			this.toolStrip1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createButton,
            this.editButton,
            this.deleteButton,
            this.refreshButton,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.filterTextBox,
            this.lastPageButton,
            this.nextPageButton,
            this.previousPageButton,
            this.firstPageButton,
            this.PageInfoLabel});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(800, 55);
			this.toolStrip1.TabIndex = 0;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// createButton
			// 
			this.createButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.createButton.Image = global::Crm.App.Properties.Resources._1371475930_filenew;
			this.createButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.createButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.createButton.Name = "createButton";
			this.createButton.Size = new System.Drawing.Size(44, 52);
			this.createButton.Text = "اضافه کردن مشتری";
			this.createButton.Click += new System.EventHandler(this.CreateButton_Click);
			// 
			// editButton
			// 
			this.editButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.editButton.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.editButton.Image = global::Crm.App.Properties.Resources._1371475973_document_edit;
			this.editButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.editButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.editButton.Name = "editButton";
			this.editButton.Size = new System.Drawing.Size(44, 52);
			this.editButton.Text = "ویرایش کردن مشتری";
			this.editButton.Click += new System.EventHandler(this.EditButton_Click);
			// 
			// deleteButton
			// 
			this.deleteButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.deleteButton.Image = global::Crm.App.Properties.Resources._1371476007_Close_Box_Red;
			this.deleteButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.deleteButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.deleteButton.Name = "deleteButton";
			this.deleteButton.Size = new System.Drawing.Size(44, 52);
			this.deleteButton.Text = "حذف مشتری";
			this.deleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
			// 
			// refreshButton
			// 
			this.refreshButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.refreshButton.Image = global::Crm.App.Properties.Resources._1371476342_Refresh;
			this.refreshButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.refreshButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.refreshButton.Name = "refreshButton";
			this.refreshButton.Size = new System.Drawing.Size(44, 52);
			this.refreshButton.Text = "بروز رسانی";
			this.refreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 55);
			// 
			// toolStripLabel1
			// 
			this.toolStripLabel1.Name = "toolStripLabel1";
			this.toolStripLabel1.Size = new System.Drawing.Size(53, 52);
			this.toolStripLabel1.Text = "جستجو :";
			// 
			// filterTextBox
			// 
			this.filterTextBox.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.filterTextBox.Name = "filterTextBox";
			this.filterTextBox.Size = new System.Drawing.Size(100, 55);
			this.filterTextBox.TextChanged += new System.EventHandler(this.FilterTextBox_TextChanged);
			// 
			// lastPageButton
			// 
			this.lastPageButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.lastPageButton.Image = global::Crm.App.Properties.Resources.icons8_end_48;
			this.lastPageButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.lastPageButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.lastPageButton.Name = "lastPageButton";
			this.lastPageButton.Size = new System.Drawing.Size(52, 52);
			this.lastPageButton.Text = "صفحه آخر";
			this.lastPageButton.Click += new System.EventHandler(this.LastPageButton_Click);
			// 
			// nextPageButton
			// 
			this.nextPageButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.nextPageButton.Image = global::Crm.App.Properties.Resources.icons8_fast_forward_48;
			this.nextPageButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.nextPageButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.nextPageButton.Name = "nextPageButton";
			this.nextPageButton.Size = new System.Drawing.Size(52, 52);
			this.nextPageButton.Text = "صفحه بعدی";
			this.nextPageButton.Click += new System.EventHandler(this.NextPageButton_Click);
			// 
			// previousPageButton
			// 
			this.previousPageButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.previousPageButton.Image = global::Crm.App.Properties.Resources.icons8_rewind_48;
			this.previousPageButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.previousPageButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.previousPageButton.Name = "previousPageButton";
			this.previousPageButton.Size = new System.Drawing.Size(52, 52);
			this.previousPageButton.Text = "صفحه قبلی";
			this.previousPageButton.Click += new System.EventHandler(this.PreviousPageButton_Click);
			// 
			// firstPageButton
			// 
			this.firstPageButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.firstPageButton.Image = global::Crm.App.Properties.Resources.icons8_skip_to_start_48;
			this.firstPageButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.firstPageButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.firstPageButton.Name = "firstPageButton";
			this.firstPageButton.Size = new System.Drawing.Size(52, 52);
			this.firstPageButton.Text = "اولین صفحه";
			this.firstPageButton.Click += new System.EventHandler(this.FirstPageButton_Click);
			// 
			// PageInfoLabel
			// 
			this.PageInfoLabel.Name = "PageInfoLabel";
			this.PageInfoLabel.Size = new System.Drawing.Size(88, 52);
			this.PageInfoLabel.Text = "toolStripLabel2";
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.customersDataGridView);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 55);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(800, 395);
			this.panel1.TabIndex = 1;
			// 
			// customersDataGridView
			// 
			this.customersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.customersDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.customersDataGridView.Location = new System.Drawing.Point(0, 0);
			this.customersDataGridView.Name = "customersDataGridView";
			this.customersDataGridView.Size = new System.Drawing.Size(800, 395);
			this.customersDataGridView.TabIndex = 0;
			this.customersDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CustomersDataGridView_CellDoubleClick);
			this.customersDataGridView.DoubleClick += new System.EventHandler(this.CustomersDataGridView_DoubleClick);
			// 
			// CustomersForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.toolStrip1);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Name = "CustomersForm";
			this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "FormCustomers";
			this.Load += new System.EventHandler(this.FormCustomers_Load);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.customersDataGridView)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton createButton;
		private System.Windows.Forms.ToolStripButton editButton;
		private System.Windows.Forms.ToolStripButton refreshButton;
		private System.Windows.Forms.ToolStripButton deleteButton;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripLabel toolStripLabel1;
		private System.Windows.Forms.ToolStripTextBox filterTextBox;
		private System.Windows.Forms.ToolStripButton firstPageButton;
		private System.Windows.Forms.ToolStripButton previousPageButton;
		private System.Windows.Forms.ToolStripButton nextPageButton;
		private System.Windows.Forms.ToolStripButton lastPageButton;
		private System.Windows.Forms.ToolStripLabel PageInfoLabel;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.DataGridView customersDataGridView;
	}
}
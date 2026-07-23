namespace Crm.App
{
	partial class CommoditiesForm
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
			this.CommoditiesDataGridView = new System.Windows.Forms.DataGridView();
			this.toolStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.CommoditiesDataGridView)).BeginInit();
			this.SuspendLayout();
			// 
			// toolStrip1
			// 
			this.toolStrip1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createButton,
            this.editButton,
            this.deleteButton,
            this.refreshButton,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.filterTextBox});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(800, 47);
			this.toolStrip1.TabIndex = 1;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// createButton
			// 
			this.createButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.createButton.Image = global::Crm.App.Properties.Resources._1371475930_filenew;
			this.createButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.createButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.createButton.Name = "createButton";
			this.createButton.Size = new System.Drawing.Size(44, 44);
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
			this.editButton.Size = new System.Drawing.Size(44, 44);
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
			this.deleteButton.Size = new System.Drawing.Size(44, 44);
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
			this.refreshButton.Size = new System.Drawing.Size(44, 44);
			this.refreshButton.Text = "بروز رسانی";
			this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 47);
			// 
			// toolStripLabel1
			// 
			this.toolStripLabel1.Name = "toolStripLabel1";
			this.toolStripLabel1.Size = new System.Drawing.Size(53, 44);
			this.toolStripLabel1.Text = "جستجو :";
			// 
			// filterTextBox
			// 
			this.filterTextBox.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.filterTextBox.Name = "filterTextBox";
			this.filterTextBox.Size = new System.Drawing.Size(100, 47);
			this.filterTextBox.TextChanged += new System.EventHandler(this.FilterTextBox_TextChanged);
			// 
			// CommoditiesDataGridView
			// 
			this.CommoditiesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.CommoditiesDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.CommoditiesDataGridView.Location = new System.Drawing.Point(0, 47);
			this.CommoditiesDataGridView.Name = "CommoditiesDataGridView";
			this.CommoditiesDataGridView.RowHeadersWidth = 62;
			this.CommoditiesDataGridView.Size = new System.Drawing.Size(800, 403);
			this.CommoditiesDataGridView.TabIndex = 3;
			this.CommoditiesDataGridView.DoubleClick += new System.EventHandler(this.CommoditiesDataGridView_DoubleClick);
			// 
			// CommoditiesForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.CommoditiesDataGridView);
			this.Controls.Add(this.toolStrip1);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
			this.Name = "CommoditiesForm";
			this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "CommoditiesForm";
			this.Load += new System.EventHandler(this.CommoditiesForm_Load);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.CommoditiesDataGridView)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton createButton;
		private System.Windows.Forms.ToolStripButton editButton;
		private System.Windows.Forms.ToolStripButton deleteButton;
		private System.Windows.Forms.ToolStripButton refreshButton;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripLabel toolStripLabel1;
		private System.Windows.Forms.ToolStripTextBox filterTextBox;
		private System.Windows.Forms.DataGridView CommoditiesDataGridView;
	}
}
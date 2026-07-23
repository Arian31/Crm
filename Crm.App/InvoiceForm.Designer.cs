namespace Crm.App
{
	partial class InvoiceForm
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
			this.newButton = new System.Windows.Forms.ToolStripButton();
			this.editButton = new System.Windows.Forms.ToolStripButton();
			this.deleteButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.listButton = new System.Windows.Forms.ToolStripButton();
			this.printButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.headerPanel = new System.Windows.Forms.Panel();
			this.printCheckBox = new System.Windows.Forms.CheckBox();
			this.button1 = new System.Windows.Forms.Button();
			this.dateMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.customerTextBox = new System.Windows.Forms.TextBox();
			this.serialNumberTextBox = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.detailPanel = new System.Windows.Forms.Panel();
			this.itemDataGridView = new System.Windows.Forms.DataGridView();
			this.productCodeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.productNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.quantityColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.amountColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.discountColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.taxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.totalColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.panel1 = new System.Windows.Forms.Panel();
			this.TotalSumlabel = new System.Windows.Forms.Label();
			this.takhfifLabel = new System.Windows.Forms.Label();
			this.sumLabel = new System.Windows.Forms.Label();
			this.sumTaxLabel = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.cancelButton = new System.Windows.Forms.Button();
			this.submitButton = new System.Windows.Forms.Button();
			this.toolStrip1.SuspendLayout();
			this.headerPanel.SuspendLayout();
			this.detailPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.itemDataGridView)).BeginInit();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newButton,
            this.editButton,
            this.deleteButton,
            this.toolStripSeparator1,
            this.listButton,
            this.printButton,
            this.toolStripSeparator2});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(845, 47);
			this.toolStrip1.TabIndex = 0;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// newButton
			// 
			this.newButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.newButton.Image = global::Crm.App.Properties.Resources._1371475930_filenew;
			this.newButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.newButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.newButton.Name = "newButton";
			this.newButton.Size = new System.Drawing.Size(44, 44);
			this.newButton.Text = "فاکتور جدید";
			this.newButton.Click += new System.EventHandler(this.NewButton_Click);
			// 
			// editButton
			// 
			this.editButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.editButton.Image = global::Crm.App.Properties.Resources._1371475973_document_edit;
			this.editButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.editButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.editButton.Name = "editButton";
			this.editButton.Size = new System.Drawing.Size(44, 44);
			this.editButton.Text = "ویرایش فاکتور";
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
			this.deleteButton.Text = "toolStripButton3";
			this.deleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 47);
			// 
			// listButton
			// 
			this.listButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.listButton.Image = global::Crm.App.Properties.Resources.list2;
			this.listButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.listButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.listButton.Name = "listButton";
			this.listButton.Size = new System.Drawing.Size(44, 44);
			this.listButton.Text = "فهرست فاکتورها";
			this.listButton.Click += new System.EventHandler(this.ListButton_Click);
			// 
			// printButton
			// 
			this.printButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.printButton.Image = global::Crm.App.Properties.Resources._1371476276_Print;
			this.printButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.printButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.printButton.Name = "printButton";
			this.printButton.Size = new System.Drawing.Size(44, 44);
			this.printButton.Text = "toolStripButton1";
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 47);
			// 
			// headerPanel
			// 
			this.headerPanel.Controls.Add(this.printCheckBox);
			this.headerPanel.Controls.Add(this.button1);
			this.headerPanel.Controls.Add(this.dateMaskedTextBox);
			this.headerPanel.Controls.Add(this.textBox1);
			this.headerPanel.Controls.Add(this.label2);
			this.headerPanel.Controls.Add(this.customerTextBox);
			this.headerPanel.Controls.Add(this.serialNumberTextBox);
			this.headerPanel.Controls.Add(this.label4);
			this.headerPanel.Controls.Add(this.label3);
			this.headerPanel.Controls.Add(this.label1);
			this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.headerPanel.Location = new System.Drawing.Point(0, 47);
			this.headerPanel.Name = "headerPanel";
			this.headerPanel.Size = new System.Drawing.Size(845, 97);
			this.headerPanel.TabIndex = 1;
			// 
			// printCheckBox
			// 
			this.printCheckBox.AutoSize = true;
			this.printCheckBox.Location = new System.Drawing.Point(394, 61);
			this.printCheckBox.Name = "printCheckBox";
			this.printCheckBox.Size = new System.Drawing.Size(142, 17);
			this.printCheckBox.TabIndex = 4;
			this.printCheckBox.Text = "پرینت اتوماتیک بعد از تایید";
			this.printCheckBox.UseVisualStyleBackColor = true;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(572, 59);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(29, 21);
			this.button1.TabIndex = 3;
			this.button1.Text = "...";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.CustomerTextBox_DoubleClick);
			// 
			// dateMaskedTextBox
			// 
			this.dateMaskedTextBox.Location = new System.Drawing.Point(436, 18);
			this.dateMaskedTextBox.Mask = "0000/00/00";
			this.dateMaskedTextBox.Name = "dateMaskedTextBox";
			this.dateMaskedTextBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.dateMaskedTextBox.Size = new System.Drawing.Size(100, 21);
			this.dateMaskedTextBox.TabIndex = 2;
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(21, 18);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(349, 62);
			this.textBox1.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(376, 21);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(54, 13);
			this.label2.TabIndex = 0;
			this.label2.Text = "توضیحات :";
			// 
			// customerTextBox
			// 
			this.customerTextBox.Location = new System.Drawing.Point(607, 59);
			this.customerTextBox.Name = "customerTextBox";
			this.customerTextBox.Size = new System.Drawing.Size(104, 21);
			this.customerTextBox.TabIndex = 1;
			this.customerTextBox.DoubleClick += new System.EventHandler(this.CustomerTextBox_DoubleClick);
			this.customerTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CustomerTextBox_KeyDown);
			// 
			// serialNumberTextBox
			// 
			this.serialNumberTextBox.Location = new System.Drawing.Point(615, 18);
			this.serialNumberTextBox.Name = "serialNumberTextBox";
			this.serialNumberTextBox.Size = new System.Drawing.Size(104, 21);
			this.serialNumberTextBox.TabIndex = 1;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(729, 62);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(51, 13);
			this.label4.TabIndex = 0;
			this.label4.Text = "مشتری :";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(558, 21);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(35, 13);
			this.label3.TabIndex = 0;
			this.label3.Text = "تاریخ :";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(737, 21);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(43, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "سریال :";
			// 
			// detailPanel
			// 
			this.detailPanel.Controls.Add(this.itemDataGridView);
			this.detailPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.detailPanel.Location = new System.Drawing.Point(0, 144);
			this.detailPanel.Name = "detailPanel";
			this.detailPanel.Size = new System.Drawing.Size(845, 258);
			this.detailPanel.TabIndex = 2;
			// 
			// itemDataGridView
			// 
			this.itemDataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
			this.itemDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.itemDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.productCodeColumn,
            this.productNameColumn,
            this.quantityColumn,
            this.amountColumn,
            this.discountColumn,
            this.taxColumn,
            this.totalColumn});
			this.itemDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.itemDataGridView.Location = new System.Drawing.Point(0, 0);
			this.itemDataGridView.Name = "itemDataGridView";
			this.itemDataGridView.Size = new System.Drawing.Size(845, 258);
			this.itemDataGridView.TabIndex = 0;
			this.itemDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ItemDataGridView_CellDoubleClick);
			this.itemDataGridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ItemDataGridView_KeyDown);
			// 
			// productCodeColumn
			// 
			this.productCodeColumn.DataPropertyName = "productCode";
			this.productCodeColumn.HeaderText = "کد کالا";
			this.productCodeColumn.Name = "productCodeColumn";
			// 
			// productNameColumn
			// 
			this.productNameColumn.DataPropertyName = "productName";
			this.productNameColumn.HeaderText = "نام کالا";
			this.productNameColumn.Name = "productNameColumn";
			this.productNameColumn.Width = 250;
			// 
			// quantityColumn
			// 
			this.quantityColumn.DataPropertyName = "quantity";
			this.quantityColumn.HeaderText = "تعداد";
			this.quantityColumn.Name = "quantityColumn";
			this.quantityColumn.Width = 50;
			// 
			// amountColumn
			// 
			this.amountColumn.DataPropertyName = "amount";
			this.amountColumn.HeaderText = "مبلغ";
			this.amountColumn.Name = "amountColumn";
			// 
			// discountColumn
			// 
			this.discountColumn.DataPropertyName = "discount";
			this.discountColumn.HeaderText = "تخفیف";
			this.discountColumn.Name = "discountColumn";
			// 
			// taxColumn
			// 
			this.taxColumn.DataPropertyName = "tax";
			this.taxColumn.HeaderText = "مالیات";
			this.taxColumn.Name = "taxColumn";
			// 
			// totalColumn
			// 
			this.totalColumn.DataPropertyName = "total";
			this.totalColumn.HeaderText = "جمع کل سطر";
			this.totalColumn.Name = "totalColumn";
			this.totalColumn.ReadOnly = true;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.TotalSumlabel);
			this.panel1.Controls.Add(this.takhfifLabel);
			this.panel1.Controls.Add(this.sumLabel);
			this.panel1.Controls.Add(this.sumTaxLabel);
			this.panel1.Controls.Add(this.label8);
			this.panel1.Controls.Add(this.label7);
			this.panel1.Controls.Add(this.label6);
			this.panel1.Controls.Add(this.label5);
			this.panel1.Controls.Add(this.cancelButton);
			this.panel1.Controls.Add(this.submitButton);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 425);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(845, 77);
			this.panel1.TabIndex = 3;
			// 
			// TotalSumlabel
			// 
			this.TotalSumlabel.AutoSize = true;
			this.TotalSumlabel.Location = new System.Drawing.Point(21, 47);
			this.TotalSumlabel.Name = "TotalSumlabel";
			this.TotalSumlabel.Size = new System.Drawing.Size(13, 13);
			this.TotalSumlabel.TabIndex = 9;
			this.TotalSumlabel.Text = "0";
			// 
			// takhfifLabel
			// 
			this.takhfifLabel.AutoSize = true;
			this.takhfifLabel.Location = new System.Drawing.Point(250, 47);
			this.takhfifLabel.Name = "takhfifLabel";
			this.takhfifLabel.Size = new System.Drawing.Size(13, 13);
			this.takhfifLabel.TabIndex = 9;
			this.takhfifLabel.Text = "0";
			// 
			// sumLabel
			// 
			this.sumLabel.AutoSize = true;
			this.sumLabel.Location = new System.Drawing.Point(250, 10);
			this.sumLabel.Name = "sumLabel";
			this.sumLabel.Size = new System.Drawing.Size(13, 13);
			this.sumLabel.TabIndex = 9;
			this.sumLabel.Text = "0";
			// 
			// sumTaxLabel
			// 
			this.sumTaxLabel.AutoSize = true;
			this.sumTaxLabel.Location = new System.Drawing.Point(21, 10);
			this.sumTaxLabel.Name = "sumTaxLabel";
			this.sumTaxLabel.Size = new System.Drawing.Size(13, 13);
			this.sumTaxLabel.TabIndex = 8;
			this.sumTaxLabel.Text = "0";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(155, 47);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(63, 13);
			this.label8.TabIndex = 7;
			this.label8.Text = "مبلغ نهایی :";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(365, 47);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(87, 13);
			this.label7.TabIndex = 6;
			this.label7.Text = "مجموع تخفیفات :";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(155, 10);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(77, 13);
			this.label6.TabIndex = 5;
			this.label6.Text = "مجموع مالیات :";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(365, 10);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(72, 13);
			this.label5.TabIndex = 4;
			this.label5.Text = "مجموع فاکتور:";
			// 
			// cancelButton
			// 
			this.cancelButton.Location = new System.Drawing.Point(615, 42);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(75, 23);
			this.cancelButton.TabIndex = 0;
			this.cancelButton.Text = "&انصراف";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
			// 
			// submitButton
			// 
			this.submitButton.Location = new System.Drawing.Point(710, 42);
			this.submitButton.Name = "submitButton";
			this.submitButton.Size = new System.Drawing.Size(75, 23);
			this.submitButton.TabIndex = 0;
			this.submitButton.Text = "&تایید";
			this.submitButton.UseVisualStyleBackColor = true;
			this.submitButton.Click += new System.EventHandler(this.SubmitButton_Click);
			// 
			// InvoiceForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(845, 502);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.detailPanel);
			this.Controls.Add(this.headerPanel);
			this.Controls.Add(this.toolStrip1);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "InvoiceForm";
			this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "InvoiceForm";
			this.Load += new System.EventHandler(this.InvoiceForm_Load);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.headerPanel.ResumeLayout(false);
			this.headerPanel.PerformLayout();
			this.detailPanel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.itemDataGridView)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.Panel headerPanel;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.MaskedTextBox dateMaskedTextBox;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox customerTextBox;
		private System.Windows.Forms.TextBox serialNumberTextBox;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel detailPanel;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.DataGridView itemDataGridView;
		private System.Windows.Forms.Button submitButton;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.Label sumTaxLabel;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label TotalSumlabel;
		private System.Windows.Forms.Label takhfifLabel;
		private System.Windows.Forms.Label sumLabel;
		private System.Windows.Forms.CheckBox printCheckBox;
		private System.Windows.Forms.ToolStripButton newButton;
		private System.Windows.Forms.ToolStripButton editButton;
		private System.Windows.Forms.ToolStripButton deleteButton;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton listButton;
		private System.Windows.Forms.ToolStripButton printButton;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.DataGridViewTextBoxColumn productCodeColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn productNameColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn quantityColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn amountColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn discountColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn taxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn totalColumn;
	}
}
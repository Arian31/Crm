namespace Crm.App
{
	partial class InvoiceListForm
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.choiceButton = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.sortBySerialButton = new System.Windows.Forms.Button();
			this.sortByDateButton = new System.Windows.Forms.Button();
			this.searchButton = new System.Windows.Forms.Button();
			this.customerTextBox = new System.Windows.Forms.TextBox();
			this.SerialTextBox = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.invoiceDataGridView = new System.Windows.Forms.DataGridView();
			this.panel1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.invoiceDataGridView)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.choiceButton);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 411);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(800, 51);
			this.panel1.TabIndex = 1;
			// 
			// choiceButton
			// 
			this.choiceButton.Location = new System.Drawing.Point(27, 12);
			this.choiceButton.Name = "choiceButton";
			this.choiceButton.Size = new System.Drawing.Size(730, 23);
			this.choiceButton.TabIndex = 2;
			this.choiceButton.Text = "جستجو";
			this.choiceButton.UseVisualStyleBackColor = true;
			this.choiceButton.Click += new System.EventHandler(this.ChoiceButton_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.sortBySerialButton);
			this.groupBox1.Controls.Add(this.sortByDateButton);
			this.groupBox1.Controls.Add(this.searchButton);
			this.groupBox1.Controls.Add(this.customerTextBox);
			this.groupBox1.Controls.Add(this.SerialTextBox);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(800, 100);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "جستجو";
			// 
			// sortBySerialButton
			// 
			this.sortBySerialButton.Location = new System.Drawing.Point(606, 56);
			this.sortBySerialButton.Name = "sortBySerialButton";
			this.sortBySerialButton.Size = new System.Drawing.Size(151, 23);
			this.sortBySerialButton.TabIndex = 2;
			this.sortBySerialButton.Text = "مرتب سازی بر اساس سریال";
			this.sortBySerialButton.UseVisualStyleBackColor = true;
			this.sortBySerialButton.Click += new System.EventHandler(this.SortBySerialButton_Click);
			// 
			// sortByDateButton
			// 
			this.sortByDateButton.Location = new System.Drawing.Point(606, 27);
			this.sortByDateButton.Name = "sortByDateButton";
			this.sortByDateButton.Size = new System.Drawing.Size(151, 23);
			this.sortByDateButton.TabIndex = 2;
			this.sortByDateButton.Text = "مرتب سازی بر اساس تاریخ";
			this.sortByDateButton.UseVisualStyleBackColor = true;
			this.sortByDateButton.Click += new System.EventHandler(this.SortByDateButton_Click);
			// 
			// searchButton
			// 
			this.searchButton.Location = new System.Drawing.Point(27, 66);
			this.searchButton.Name = "searchButton";
			this.searchButton.Size = new System.Drawing.Size(75, 23);
			this.searchButton.TabIndex = 2;
			this.searchButton.Text = "جستجو";
			this.searchButton.UseVisualStyleBackColor = true;
			this.searchButton.Click += new System.EventHandler(this.SearchButton_Click);
			// 
			// customerTextBox
			// 
			this.customerTextBox.Location = new System.Drawing.Point(187, 64);
			this.customerTextBox.Name = "customerTextBox";
			this.customerTextBox.Size = new System.Drawing.Size(100, 21);
			this.customerTextBox.TabIndex = 1;
			// 
			// SerialTextBox
			// 
			this.SerialTextBox.Location = new System.Drawing.Point(187, 24);
			this.SerialTextBox.Name = "SerialTextBox";
			this.SerialTextBox.Size = new System.Drawing.Size(100, 21);
			this.SerialTextBox.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(316, 67);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(51, 13);
			this.label2.TabIndex = 0;
			this.label2.Text = "مشتری :";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(316, 27);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(43, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "سریال :";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.invoiceDataGridView);
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox2.Location = new System.Drawing.Point(0, 100);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(800, 311);
			this.groupBox2.TabIndex = 3;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "لیست فاکتورها";
			// 
			// invoiceDataGridView
			// 
			this.invoiceDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.invoiceDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.invoiceDataGridView.Location = new System.Drawing.Point(3, 17);
			this.invoiceDataGridView.Name = "invoiceDataGridView";
			this.invoiceDataGridView.Size = new System.Drawing.Size(794, 291);
			this.invoiceDataGridView.TabIndex = 0;
			this.invoiceDataGridView.DoubleClick += new System.EventHandler(this.InvoiceDataGridView_DoubleClick);
			// 
			// InvoiceListForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 462);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
			this.Name = "InvoiceListForm";
			this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "InvoiceListForm";
			this.Load += new System.EventHandler(this.InvoiceListForm_Load);
			this.panel1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.invoiceDataGridView)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button searchButton;
		private System.Windows.Forms.TextBox SerialTextBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.DataGridView invoiceDataGridView;
		private System.Windows.Forms.TextBox customerTextBox;
		private System.Windows.Forms.Button sortBySerialButton;
		private System.Windows.Forms.Button sortByDateButton;
		private System.Windows.Forms.Button choiceButton;
		private System.Windows.Forms.Label label2;
	}
}
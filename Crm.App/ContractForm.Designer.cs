namespace Crm.App
{
	partial class ContractForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContractForm));
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.panel1 = new System.Windows.Forms.Panel();
			this.freeWarrantyCheckBox = new System.Windows.Forms.CheckBox();
			this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
			this.endDateMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
			this.startDateMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.descriptionTextBox = new System.Windows.Forms.TextBox();
			this.contractNumberTextBox = new System.Windows.Forms.TextBox();
			this.panel2 = new System.Windows.Forms.Panel();
			this.itemDataGridView = new System.Windows.Forms.DataGridView();
			this.selectCustomerButton = new System.Windows.Forms.Button();
			this.customerNameTextBox = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.newButton = new System.Windows.Forms.ToolStripButton();
			this.editButton = new System.Windows.Forms.ToolStripButton();
			this.deleteButton = new System.Windows.Forms.ToolStripButton();
			this.submitButton = new System.Windows.Forms.ToolStripButton();
			this.cancelButton = new System.Windows.Forms.ToolStripButton();
			this.toolStrip1.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.itemDataGridView)).BeginInit();
			this.SuspendLayout();
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newButton,
            this.editButton,
            this.deleteButton,
            this.submitButton,
            this.cancelButton});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(508, 47);
			this.toolStrip1.TabIndex = 0;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.freeWarrantyCheckBox);
			this.panel1.Controls.Add(this.numericUpDown1);
			this.panel1.Controls.Add(this.endDateMaskedTextBox);
			this.panel1.Controls.Add(this.startDateMaskedTextBox);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.label5);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.descriptionTextBox);
			this.panel1.Controls.Add(this.contractNumberTextBox);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 47);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(508, 306);
			this.panel1.TabIndex = 1;
			// 
			// freeWarrantyCheckBox
			// 
			this.freeWarrantyCheckBox.AutoSize = true;
			this.freeWarrantyCheckBox.Location = new System.Drawing.Point(53, 123);
			this.freeWarrantyCheckBox.Name = "freeWarrantyCheckBox";
			this.freeWarrantyCheckBox.Size = new System.Drawing.Size(88, 17);
			this.freeWarrantyCheckBox.TabIndex = 6;
			this.freeWarrantyCheckBox.Text = "گارانتی رایگان";
			this.freeWarrantyCheckBox.UseVisualStyleBackColor = true;
			this.freeWarrantyCheckBox.CheckedChanged += new System.EventHandler(this.FreeWarrantyCheckBox_CheckedChanged);
			// 
			// numericUpDown1
			// 
			this.numericUpDown1.Location = new System.Drawing.Point(184, 122);
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.numericUpDown1.Size = new System.Drawing.Size(215, 21);
			this.numericUpDown1.TabIndex = 5;
			this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// endDateMaskedTextBox
			// 
			this.endDateMaskedTextBox.Location = new System.Drawing.Point(30, 66);
			this.endDateMaskedTextBox.Mask = "0000/00/00";
			this.endDateMaskedTextBox.Name = "endDateMaskedTextBox";
			this.endDateMaskedTextBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.endDateMaskedTextBox.Size = new System.Drawing.Size(100, 21);
			this.endDateMaskedTextBox.TabIndex = 4;
			// 
			// startDateMaskedTextBox
			// 
			this.startDateMaskedTextBox.Location = new System.Drawing.Point(273, 66);
			this.startDateMaskedTextBox.Mask = "0000/00/00";
			this.startDateMaskedTextBox.Name = "startDateMaskedTextBox";
			this.startDateMaskedTextBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.startDateMaskedTextBox.Size = new System.Drawing.Size(100, 21);
			this.startDateMaskedTextBox.TabIndex = 4;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(173, 69);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(57, 13);
			this.label3.TabIndex = 3;
			this.label3.Text = "تاریخ پایان :";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(416, 175);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(54, 13);
			this.label5.TabIndex = 3;
			this.label5.Text = "توضیحات :";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(415, 123);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(66, 13);
			this.label4.TabIndex = 3;
			this.label4.Text = "تاریخ شروع :";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(416, 71);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(66, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "تاریخ شروع :";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(416, 19);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = " شماره قرارداد :";
			// 
			// descriptionTextBox
			// 
			this.descriptionTextBox.Location = new System.Drawing.Point(30, 173);
			this.descriptionTextBox.Multiline = true;
			this.descriptionTextBox.Name = "descriptionTextBox";
			this.descriptionTextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.descriptionTextBox.Size = new System.Drawing.Size(369, 113);
			this.descriptionTextBox.TabIndex = 2;
			// 
			// contractNumberTextBox
			// 
			this.contractNumberTextBox.Location = new System.Drawing.Point(237, 15);
			this.contractNumberTextBox.Name = "contractNumberTextBox";
			this.contractNumberTextBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.contractNumberTextBox.Size = new System.Drawing.Size(162, 21);
			this.contractNumberTextBox.TabIndex = 2;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.itemDataGridView);
			this.panel2.Controls.Add(this.selectCustomerButton);
			this.panel2.Controls.Add(this.customerNameTextBox);
			this.panel2.Controls.Add(this.label6);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel2.Location = new System.Drawing.Point(0, 337);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(508, 192);
			this.panel2.TabIndex = 2;
			// 
			// itemDataGridView
			// 
			this.itemDataGridView.AllowUserToAddRows = false;
			this.itemDataGridView.AllowUserToDeleteRows = false;
			this.itemDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.itemDataGridView.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.itemDataGridView.Location = new System.Drawing.Point(0, 48);
			this.itemDataGridView.Name = "itemDataGridView";
			this.itemDataGridView.ReadOnly = true;
			this.itemDataGridView.Size = new System.Drawing.Size(508, 144);
			this.itemDataGridView.TabIndex = 5;
			this.itemDataGridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ItemDataGridView_KeyDown);
			// 
			// selectCustomerButton
			// 
			this.selectCustomerButton.Location = new System.Drawing.Point(13, 9);
			this.selectCustomerButton.Name = "selectCustomerButton";
			this.selectCustomerButton.Size = new System.Drawing.Size(34, 23);
			this.selectCustomerButton.TabIndex = 4;
			this.selectCustomerButton.Text = "...";
			this.selectCustomerButton.UseVisualStyleBackColor = true;
			this.selectCustomerButton.Click += new System.EventHandler(this.SelectCustomerButton_Click);
			// 
			// customerNameTextBox
			// 
			this.customerNameTextBox.Location = new System.Drawing.Point(53, 12);
			this.customerNameTextBox.Name = "customerNameTextBox";
			this.customerNameTextBox.ReadOnly = true;
			this.customerNameTextBox.Size = new System.Drawing.Size(371, 21);
			this.customerNameTextBox.TabIndex = 0;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(430, 15);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(67, 13);
			this.label6.TabIndex = 3;
			this.label6.Text = "نام مشتری :";
			// 
			// newButton
			// 
			this.newButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.newButton.Image = global::Crm.App.Properties.Resources._1371475930_filenew;
			this.newButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.newButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.newButton.Name = "newButton";
			this.newButton.Size = new System.Drawing.Size(44, 44);
			this.newButton.Text = "قرارداد جدید";
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
			this.editButton.Text = "ویرایش قرارداد";
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
			this.deleteButton.Text = "حذف قرارداد";
			this.deleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
			// 
			// submitButton
			// 
			this.submitButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.submitButton.Image = global::Crm.App.Properties.Resources.done;
			this.submitButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.submitButton.Name = "submitButton";
			this.submitButton.Size = new System.Drawing.Size(23, 44);
			this.submitButton.Text = "تایید";
			this.submitButton.Click += new System.EventHandler(this.SubmitButton_Click);
			// 
			// cancelButton
			// 
			this.cancelButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.cancelButton.Image = ((System.Drawing.Image)(resources.GetObject("cancelButton.Image")));
			this.cancelButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(23, 44);
			this.cancelButton.Text = "انصراف";
			this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
			// 
			// ContractForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(508, 529);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.toolStrip1);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.Name = "ContractForm";
			this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.Text = "ContractForm";
			this.Load += new System.EventHandler(this.ContractForm_Load);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.itemDataGridView)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.MaskedTextBox endDateMaskedTextBox;
		private System.Windows.Forms.MaskedTextBox startDateMaskedTextBox;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox contractNumberTextBox;
		private System.Windows.Forms.NumericUpDown numericUpDown1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.CheckBox freeWarrantyCheckBox;
		private System.Windows.Forms.TextBox descriptionTextBox;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.TextBox customerNameTextBox;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button selectCustomerButton;
		private System.Windows.Forms.DataGridView itemDataGridView;
		private System.Windows.Forms.ToolStripButton newButton;
		private System.Windows.Forms.ToolStripButton editButton;
		private System.Windows.Forms.ToolStripButton deleteButton;
		private System.Windows.Forms.ToolStripButton submitButton;
		private System.Windows.Forms.ToolStripButton cancelButton;
	}
}
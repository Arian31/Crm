namespace Crm.App.Customer
{
	partial class PeopleForm
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.genderComboBox = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.lastNamePersonTextBox = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.recordCountLabel = new System.Windows.Forms.Label();
			this.searchButton = new System.Windows.Forms.Button();
			this.emailTextBox = new System.Windows.Forms.TextBox();
			this.firstNamePersonTextBox = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.peopleDataGridView = new System.Windows.Forms.DataGridView();
			this.toolStrip1.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.peopleDataGridView)).BeginInit();
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
			this.toolStrip1.Size = new System.Drawing.Size(796, 47);
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
			this.refreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
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
			// panel1
			// 
			this.panel1.Controls.Add(this.genderComboBox);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.lastNamePersonTextBox);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.recordCountLabel);
			this.panel1.Controls.Add(this.searchButton);
			this.panel1.Controls.Add(this.emailTextBox);
			this.panel1.Controls.Add(this.firstNamePersonTextBox);
			this.panel1.Controls.Add(this.label5);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 47);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(796, 100);
			this.panel1.TabIndex = 1;
			// 
			// genderComboBox
			// 
			this.genderComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.genderComboBox.FormattingEnabled = true;
			this.genderComboBox.Items.AddRange(new object[] {
            "خانم",
            "آقا"});
			this.genderComboBox.Location = new System.Drawing.Point(95, 11);
			this.genderComboBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.genderComboBox.Name = "genderComboBox";
			this.genderComboBox.Size = new System.Drawing.Size(149, 21);
			this.genderComboBox.TabIndex = 6;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(262, 14);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(51, 13);
			this.label4.TabIndex = 5;
			this.label4.Text = "جنسیت :";
			// 
			// lastNamePersonTextBox
			// 
			this.lastNamePersonTextBox.Location = new System.Drawing.Point(334, 11);
			this.lastNamePersonTextBox.Name = "lastNamePersonTextBox";
			this.lastNamePersonTextBox.Size = new System.Drawing.Size(122, 21);
			this.lastNamePersonTextBox.TabIndex = 4;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(462, 17);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(103, 13);
			this.label3.TabIndex = 3;
			this.label3.Text = "نام خانوادگی شخص:";
			// 
			// recordCountLabel
			// 
			this.recordCountLabel.AutoSize = true;
			this.recordCountLabel.Location = new System.Drawing.Point(13, 37);
			this.recordCountLabel.Name = "recordCountLabel";
			this.recordCountLabel.Size = new System.Drawing.Size(19, 13);
			this.recordCountLabel.TabIndex = 9;
			this.recordCountLabel.Text = "...";
			// 
			// searchButton
			// 
			this.searchButton.Location = new System.Drawing.Point(13, 62);
			this.searchButton.Name = "searchButton";
			this.searchButton.Size = new System.Drawing.Size(75, 23);
			this.searchButton.TabIndex = 10;
			this.searchButton.Text = "جستجو";
			this.searchButton.UseVisualStyleBackColor = true;
			this.searchButton.Click += new System.EventHandler(this.SearchButton_Click);
			// 
			// emailTextBox
			// 
			this.emailTextBox.Location = new System.Drawing.Point(587, 59);
			this.emailTextBox.Name = "emailTextBox";
			this.emailTextBox.Size = new System.Drawing.Size(122, 21);
			this.emailTextBox.TabIndex = 8;
			// 
			// firstNamePersonTextBox
			// 
			this.firstNamePersonTextBox.Location = new System.Drawing.Point(587, 14);
			this.firstNamePersonTextBox.Name = "firstNamePersonTextBox";
			this.firstNamePersonTextBox.Size = new System.Drawing.Size(122, 21);
			this.firstNamePersonTextBox.TabIndex = 2;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(727, 62);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(39, 13);
			this.label5.TabIndex = 7;
			this.label5.Text = "ایمیل :";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(727, 17);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(58, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "نام شخص:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(727, 14);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(0, 13);
			this.label1.TabIndex = 0;
			// 
			// peopleDataGridView
			// 
			this.peopleDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.peopleDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.peopleDataGridView.Location = new System.Drawing.Point(0, 147);
			this.peopleDataGridView.Name = "peopleDataGridView";
			this.peopleDataGridView.RowHeadersWidth = 62;
			this.peopleDataGridView.Size = new System.Drawing.Size(796, 233);
			this.peopleDataGridView.TabIndex = 2;
			this.peopleDataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.PeopleDataGridView_CellFormatting);
			this.peopleDataGridView.DoubleClick += new System.EventHandler(this.PeopleDataGridView_DoubleClick);
			// 
			// PeopleForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(796, 380);
			this.Controls.Add(this.peopleDataGridView);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.toolStrip1);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Name = "PeopleForm";
			this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "PeopleForm";
			this.Load += new System.EventHandler(this.PeopleForm_Load);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.peopleDataGridView)).EndInit();
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
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.DataGridView peopleDataGridView;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox firstNamePersonTextBox;
		private System.Windows.Forms.Button searchButton;
		private System.Windows.Forms.Label recordCountLabel;
		private System.Windows.Forms.TextBox lastNamePersonTextBox;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox genderComboBox;
		private System.Windows.Forms.TextBox emailTextBox;
		private System.Windows.Forms.Label label5;
	}
}
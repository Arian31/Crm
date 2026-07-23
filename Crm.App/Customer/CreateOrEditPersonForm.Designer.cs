namespace Crm.App.Customer
{
	partial class CreateOrEditPersonForm
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
			this.label7 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.exitButton = new System.Windows.Forms.Button();
			this.submitAndExitButton = new System.Windows.Forms.Button();
			this.panel2 = new System.Windows.Forms.Panel();
			this.submitButton = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.genderComboBox = new System.Windows.Forms.ComboBox();
			this.lastNameTextBox = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.mobileTextBox = new System.Windows.Forms.TextBox();
			this.emailTextBox = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.firstNameTextBox = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.BirthDateMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.panel2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label7
			// 
			this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(689, 30);
			this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(84, 13);
			this.label7.TabIndex = 0;
			this.label7.Text = "اطلاعات اشخاص";
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.label7);
			this.panel1.Controls.Add(this.pictureBox1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(882, 76);
			this.panel1.TabIndex = 0;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.pictureBox1.Location = new System.Drawing.Point(815, 16);
			this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(32, 32);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// exitButton
			// 
			this.exitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.exitButton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.exitButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.exitButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.exitButton.Location = new System.Drawing.Point(27, 8);
			this.exitButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.exitButton.Name = "exitButton";
			this.exitButton.Size = new System.Drawing.Size(112, 63);
			this.exitButton.TabIndex = 2;
			this.exitButton.Text = "انصراف";
			this.exitButton.UseVisualStyleBackColor = true;
			this.exitButton.Click += new System.EventHandler(this.ExitButton_Click);
			// 
			// submitAndExitButton
			// 
			this.submitAndExitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.submitAndExitButton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.submitAndExitButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.submitAndExitButton.Location = new System.Drawing.Point(736, 5);
			this.submitAndExitButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.submitAndExitButton.Name = "submitAndExitButton";
			this.submitAndExitButton.Size = new System.Drawing.Size(112, 63);
			this.submitAndExitButton.TabIndex = 0;
			this.submitAndExitButton.Text = "تایید و خروج";
			this.submitAndExitButton.UseVisualStyleBackColor = true;
			this.submitAndExitButton.Click += new System.EventHandler(this.SubmitAndExitButton_Click);
			// 
			// panel2
			// 
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.submitButton);
			this.panel2.Controls.Add(this.exitButton);
			this.panel2.Controls.Add(this.submitAndExitButton);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel2.Location = new System.Drawing.Point(0, 323);
			this.panel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(882, 78);
			this.panel2.TabIndex = 2;
			// 
			// submitButton
			// 
			this.submitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.submitButton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.submitButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.submitButton.Location = new System.Drawing.Point(616, 5);
			this.submitButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.submitButton.Name = "submitButton";
			this.submitButton.Size = new System.Drawing.Size(112, 63);
			this.submitButton.TabIndex = 1;
			this.submitButton.Text = "تایید";
			this.submitButton.UseVisualStyleBackColor = true;
			this.submitButton.Click += new System.EventHandler(this.SubmitButton_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.BirthDateMaskedTextBox);
			this.groupBox1.Controls.Add(this.genderComboBox);
			this.groupBox1.Controls.Add(this.lastNameTextBox);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.mobileTextBox);
			this.groupBox1.Controls.Add(this.emailTextBox);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.firstNameTextBox);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(27, 102);
			this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.groupBox1.Size = new System.Drawing.Size(821, 190);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "اطلاعات فردی";
			// 
			// genderComboBox
			// 
			this.genderComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.genderComboBox.FormattingEnabled = true;
			this.genderComboBox.Items.AddRange(new object[] {
            "خانم",
            "آقا"});
			this.genderComboBox.Location = new System.Drawing.Point(45, 139);
			this.genderComboBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.genderComboBox.Name = "genderComboBox";
			this.genderComboBox.Size = new System.Drawing.Size(284, 21);
			this.genderComboBox.TabIndex = 11;
			// 
			// lastNameTextBox
			// 
			this.lastNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lastNameTextBox.Location = new System.Drawing.Point(457, 92);
			this.lastNameTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.lastNameTextBox.MaxLength = 100;
			this.lastNameTextBox.Name = "lastNameTextBox";
			this.lastNameTextBox.Size = new System.Drawing.Size(204, 20);
			this.lastNameTextBox.TabIndex = 3;
			// 
			// label5
			// 
			this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(691, 134);
			this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(52, 13);
			this.label5.TabIndex = 4;
			this.label5.Text = "تاریخ تولد:";
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(691, 95);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(69, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "نا&م خانوادگی:";
			// 
			// mobileTextBox
			// 
			this.mobileTextBox.Location = new System.Drawing.Point(45, 92);
			this.mobileTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.mobileTextBox.MaxLength = 10;
			this.mobileTextBox.Name = "mobileTextBox";
			this.mobileTextBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.mobileTextBox.Size = new System.Drawing.Size(284, 20);
			this.mobileTextBox.TabIndex = 9;
			// 
			// emailTextBox
			// 
			this.emailTextBox.Location = new System.Drawing.Point(45, 52);
			this.emailTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.emailTextBox.Name = "emailTextBox";
			this.emailTextBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.emailTextBox.Size = new System.Drawing.Size(284, 20);
			this.emailTextBox.TabIndex = 7;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(340, 143);
			this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(48, 13);
			this.label6.TabIndex = 10;
			this.label6.Text = "جنسیت:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(340, 101);
			this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(42, 13);
			this.label4.TabIndex = 8;
			this.label4.Text = "موبایل :";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(340, 57);
			this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(36, 13);
			this.label3.TabIndex = 6;
			this.label3.Text = "&ایمیل:";
			// 
			// firstNameTextBox
			// 
			this.firstNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.firstNameTextBox.Location = new System.Drawing.Point(457, 52);
			this.firstNameTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.firstNameTextBox.MaxLength = 50;
			this.firstNameTextBox.Name = "firstNameTextBox";
			this.firstNameTextBox.Size = new System.Drawing.Size(204, 20);
			this.firstNameTextBox.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(691, 55);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(24, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "&نام:";
			// 
			// BirthDateMaskedTextBox
			// 
			this.BirthDateMaskedTextBox.Location = new System.Drawing.Point(457, 139);
			this.BirthDateMaskedTextBox.Mask = "0000/00/00";
			this.BirthDateMaskedTextBox.Name = "BirthDateMaskedTextBox";
			this.BirthDateMaskedTextBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.BirthDateMaskedTextBox.Size = new System.Drawing.Size(100, 20);
			this.BirthDateMaskedTextBox.TabIndex = 12;
			this.BirthDateMaskedTextBox.ValidatingType = typeof(System.DateTime);
			// 
			// CreateOrEditPersonForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(882, 401);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.MinimizeBox = false;
			this.Name = "CreateOrEditPersonForm";
			this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "CreateOrEditPersonForm";
			this.Load += new System.EventHandler(this.CreateOrEditPersonForm_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.panel2.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button exitButton;
		private System.Windows.Forms.Button submitAndExitButton;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Button submitButton;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.ComboBox genderComboBox;
		private System.Windows.Forms.TextBox lastNameTextBox;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox mobileTextBox;
		private System.Windows.Forms.TextBox emailTextBox;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox firstNameTextBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.MaskedTextBox BirthDateMaskedTextBox;
	}
}
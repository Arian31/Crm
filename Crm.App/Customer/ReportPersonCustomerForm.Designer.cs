namespace Crm.App.Customer
{
	partial class ReportPersonCustomerForm
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
			this.peopleListBox = new System.Windows.Forms.ListBox();
			this.customersListBox = new System.Windows.Forms.ListBox();
			this.SuspendLayout();
			// 
			// peopleListBox
			// 
			this.peopleListBox.Dock = System.Windows.Forms.DockStyle.Top;
			this.peopleListBox.FormattingEnabled = true;
			this.peopleListBox.Location = new System.Drawing.Point(0, 0);
			this.peopleListBox.Name = "peopleListBox";
			this.peopleListBox.Size = new System.Drawing.Size(362, 212);
			this.peopleListBox.TabIndex = 0;
			this.peopleListBox.SelectedIndexChanged += new System.EventHandler(this.PeopleListBox_SelectedIndexChanged);
			// 
			// customersListBox
			// 
			this.customersListBox.Dock = System.Windows.Forms.DockStyle.Top;
			this.customersListBox.FormattingEnabled = true;
			this.customersListBox.Location = new System.Drawing.Point(0, 212);
			this.customersListBox.Name = "customersListBox";
			this.customersListBox.Size = new System.Drawing.Size(362, 238);
			this.customersListBox.TabIndex = 1;
			// 
			// ReportPersonCustomerForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(362, 458);
			this.Controls.Add(this.customersListBox);
			this.Controls.Add(this.peopleListBox);
			this.Name = "ReportPersonCustomerForm";
			this.Text = "ReportPersonCustomerForm";
			this.Load += new System.EventHandler(this.ReportPersonCustomerForm_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListBox peopleListBox;
		private System.Windows.Forms.ListBox customersListBox;
	}
}
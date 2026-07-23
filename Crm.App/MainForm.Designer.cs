namespace Crm.App
{
	partial class MainForm
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
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.baseButton = new System.Windows.Forms.ToolStripMenuItem();
			this.personalButton = new System.Windows.Forms.ToolStripMenuItem();
			this.customerButton = new System.Windows.Forms.ToolStripMenuItem();
			this.گزارشToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.customerReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.انبارToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.commodityButton = new System.Windows.Forms.ToolStripMenuItem();
			this.buttonGenerateInitializer = new System.Windows.Forms.Button();
			this.invoiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.baseButton,
            this.انبارToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(800, 24);
			this.menuStrip1.TabIndex = 1;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// baseButton
			// 
			this.baseButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.personalButton,
            this.customerButton,
            this.گزارشToolStripMenuItem});
			this.baseButton.Name = "baseButton";
			this.baseButton.Size = new System.Drawing.Size(80, 20);
			this.baseButton.Text = "اطلاعات پایه";
			// 
			// personalButton
			// 
			this.personalButton.Name = "personalButton";
			this.personalButton.Size = new System.Drawing.Size(113, 22);
			this.personalButton.Text = "اشخاص";
			this.personalButton.Click += new System.EventHandler(this.PersonalButton_Click);
			// 
			// customerButton
			// 
			this.customerButton.Name = "customerButton";
			this.customerButton.Size = new System.Drawing.Size(113, 22);
			this.customerButton.Text = "مشتری";
			this.customerButton.Click += new System.EventHandler(this.CustomerButton_Click);
			// 
			// گزارشToolStripMenuItem
			// 
			this.گزارشToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.customerReportToolStripMenuItem});
			this.گزارشToolStripMenuItem.Name = "گزارشToolStripMenuItem";
			this.گزارشToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
			this.گزارشToolStripMenuItem.Text = "گزارش";
			// 
			// customerReportToolStripMenuItem
			// 
			this.customerReportToolStripMenuItem.Name = "customerReportToolStripMenuItem";
			this.customerReportToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
			this.customerReportToolStripMenuItem.Text = "گزارش مشتری";
			this.customerReportToolStripMenuItem.Click += new System.EventHandler(this.CustomerReportToolStripMenuItem_Click);
			// 
			// انبارToolStripMenuItem
			// 
			this.انبارToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.commodityButton,
            this.invoiceToolStripMenuItem});
			this.انبارToolStripMenuItem.Name = "انبارToolStripMenuItem";
			this.انبارToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
			this.انبارToolStripMenuItem.Text = "انبار";
			// 
			// commodityButton
			// 
			this.commodityButton.Name = "commodityButton";
			this.commodityButton.Size = new System.Drawing.Size(180, 22);
			this.commodityButton.Text = "تعریف کالا";
			this.commodityButton.Click += new System.EventHandler(this.commodityButton_Click);
			// 
			// buttonGenerateInitializer
			// 
			this.buttonGenerateInitializer.Location = new System.Drawing.Point(12, 39);
			this.buttonGenerateInitializer.Name = "buttonGenerateInitializer";
			this.buttonGenerateInitializer.Size = new System.Drawing.Size(197, 29);
			this.buttonGenerateInitializer.TabIndex = 2;
			this.buttonGenerateInitializer.Text = "generate";
			this.buttonGenerateInitializer.UseVisualStyleBackColor = true;
			this.buttonGenerateInitializer.Click += new System.EventHandler(this.ButtonGenerateInitializer_Click);
			// 
			// invoiceToolStripMenuItem
			// 
			this.invoiceToolStripMenuItem.Name = "invoiceToolStripMenuItem";
			this.invoiceToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.invoiceToolStripMenuItem.Text = "فاکتور";
			this.invoiceToolStripMenuItem.Click += new System.EventHandler(this.InvoiceToolStripMenuItem_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.buttonGenerateInitializer);
			this.Controls.Add(this.menuStrip1);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "MainForm";
			this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "صفحه اصلی";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.Shown += new System.EventHandler(this.MainForm_Shown);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem baseButton;
		private System.Windows.Forms.ToolStripMenuItem personalButton;
		private System.Windows.Forms.ToolStripMenuItem customerButton;
		private System.Windows.Forms.Button buttonGenerateInitializer;
		private System.Windows.Forms.ToolStripMenuItem گزارشToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem customerReportToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem انبارToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem commodityButton;
		private System.Windows.Forms.ToolStripMenuItem invoiceToolStripMenuItem;
	}
}


namespace Crm.App
{
	partial class SelectAssetForm
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
			this.ConfirmButton = new System.Windows.Forms.Button();
			this.assetDataGridView = new System.Windows.Forms.DataGridView();
			((System.ComponentModel.ISupportInitialize)(this.assetDataGridView)).BeginInit();
			this.SuspendLayout();
			// 
			// ConfirmButton
			// 
			this.ConfirmButton.Location = new System.Drawing.Point(2, 271);
			this.ConfirmButton.Name = "ConfirmButton";
			this.ConfirmButton.Size = new System.Drawing.Size(457, 23);
			this.ConfirmButton.TabIndex = 0;
			this.ConfirmButton.Text = "تایید";
			this.ConfirmButton.UseVisualStyleBackColor = true;
			// 
			// assetDataGridView
			// 
			this.assetDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.assetDataGridView.Dock = System.Windows.Forms.DockStyle.Top;
			this.assetDataGridView.Location = new System.Drawing.Point(0, 0);
			this.assetDataGridView.Name = "assetDataGridView";
			this.assetDataGridView.Size = new System.Drawing.Size(462, 265);
			this.assetDataGridView.TabIndex = 1;
			// 
			// SelectAssetForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(462, 306);
			this.Controls.Add(this.assetDataGridView);
			this.Controls.Add(this.ConfirmButton);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.Name = "SelectAssetForm";
			this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			((System.ComponentModel.ISupportInitialize)(this.assetDataGridView)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button ConfirmButton;
		private System.Windows.Forms.DataGridView assetDataGridView;
	}
}
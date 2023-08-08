namespace WinFormsApp1.Models
{
	partial class InfoPopUp
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
			infoLabel = new Label();
			okButton = new Button();
			SuspendLayout();
			// 
			// label1
			// 
			infoLabel.AutoSize = true;
			infoLabel.Location = new Point(143, 68);
			infoLabel.Name = "label1";
			infoLabel.Size = new Size(38, 15);
			infoLabel.TabIndex = 0;
			infoLabel.Text = "label1";
			// 
			// button1
			// 
			okButton.Location = new Point(125, 86);
			okButton.Name = "button1";
			okButton.Size = new Size(75, 23);
			okButton.TabIndex = 1;
			okButton.Text = "OK";
			okButton.UseVisualStyleBackColor = true;
			okButton.Click += button1_Click;
			// 
			// InfoPopUp
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(349, 186);
			Controls.Add(okButton);
			Controls.Add(infoLabel);
			Name = "InfoPopUp";
			Text = "InfoPopUp";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label infoLabel;
		private Button okButton;
	}
}
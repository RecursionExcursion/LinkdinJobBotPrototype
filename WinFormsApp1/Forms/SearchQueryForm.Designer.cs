namespace WinFormsApp1.Forms
{
	partial class SearchQueryForm
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
			locationLabel = new Label();
			locationListBox = new CheckedListBox();
			experianceListBox = new CheckedListBox();
			positionLabel = new Label();
			jobSearchLabel = new Label();
			jobSearchTextBox = new TextBox();
			locationSearchTextBox = new TextBox();
			jobLocationLabel = new Label();
			startBotButton = new Button();
			SuspendLayout();
			// 
			// locationLabel
			// 
			locationLabel.AutoSize = true;
			locationLabel.Location = new Point(259, 78);
			locationLabel.Name = "locationLabel";
			locationLabel.Size = new Size(53, 15);
			locationLabel.TabIndex = 0;
			locationLabel.Text = "Location";
			// 
			// locationListBox
			// 
			locationListBox.FormattingEnabled = true;
			locationListBox.Items.AddRange(new object[] { "Remote", "Hybrid", "OnSite" });
			locationListBox.Location = new Point(224, 96);
			locationListBox.Name = "locationListBox";
			locationListBox.Size = new Size(120, 58);
			locationListBox.TabIndex = 1;
			// 
			// positionListBox
			// 
			experianceListBox.FormattingEnabled = true;
			experianceListBox.Items.AddRange(new object[] { "Internship", "Entry Level", "Associate", "Mid-Senior Level", "Director", "Executive" });
			experianceListBox.Location = new Point(402, 96);
			experianceListBox.Name = "positionListBox";
			experianceListBox.Size = new Size(120, 112);
			experianceListBox.TabIndex = 3;
			// 
			// positionLabel
			// 
			positionLabel.AutoSize = true;
			positionLabel.Location = new Point(437, 78);
			positionLabel.Name = "positionLabel";
			positionLabel.Size = new Size(54, 15);
			positionLabel.TabIndex = 2;
			positionLabel.Text = "Postition";
			// 
			// jobSearchLabel
			// 
			jobSearchLabel.AutoSize = true;
			jobSearchLabel.Location = new Point(198, 248);
			jobSearchLabel.Name = "jobSearchLabel";
			jobSearchLabel.Size = new Size(63, 15);
			jobSearchLabel.TabIndex = 4;
			jobSearchLabel.Text = "Job Search";
			// 
			// jobSearchTextBox
			// 
			jobSearchTextBox.Location = new Point(278, 245);
			jobSearchTextBox.Name = "jobSearchTextBox";
			jobSearchTextBox.Size = new Size(244, 23);
			jobSearchTextBox.TabIndex = 5;
			// 
			// locationSearchTextBox
			// 
			locationSearchTextBox.Location = new Point(278, 295);
			locationSearchTextBox.Name = "locationSearchTextBox";
			locationSearchTextBox.Size = new Size(244, 23);
			locationSearchTextBox.TabIndex = 7;
			// 
			// jobLocationLabel
			// 
			jobLocationLabel.AutoSize = true;
			jobLocationLabel.Location = new Point(198, 298);
			jobLocationLabel.Name = "jobLocationLabel";
			jobLocationLabel.Size = new Size(74, 15);
			jobLocationLabel.TabIndex = 6;
			jobLocationLabel.Text = "Job Location";
			// 
			// startBotButton
			// 
			startBotButton.Location = new Point(340, 357);
			startBotButton.Name = "startBotButton";
			startBotButton.Size = new Size(75, 23);
			startBotButton.TabIndex = 8;
			startBotButton.Text = "Start Bot";
			startBotButton.UseVisualStyleBackColor = true;
			startBotButton.Click += StartBotButton_Click;
			// 
			// SearchQueryForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(startBotButton);
			Controls.Add(locationSearchTextBox);
			Controls.Add(jobLocationLabel);
			Controls.Add(jobSearchTextBox);
			Controls.Add(jobSearchLabel);
			Controls.Add(experianceListBox);
			Controls.Add(positionLabel);
			Controls.Add(locationListBox);
			Controls.Add(locationLabel);
			Name = "SearchQueryForm";
			Text = "SearchQueryForm";
			Resize += OnFormResize;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label locationLabel;
		private CheckedListBox locationListBox;
		private CheckedListBox experianceListBox;
		private Label positionLabel;
		private Label jobSearchLabel;
		private TextBox jobSearchTextBox;
		private TextBox locationSearchTextBox;
		private Label jobLocationLabel;
		private Button startBotButton;
	}
}
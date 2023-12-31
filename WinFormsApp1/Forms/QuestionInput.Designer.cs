﻿namespace WinFormsApp1.Forms
{
	partial class QuestionInput
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
			submitButton = new Button();
			questionLabel = new Label();
			answerTextBox = new TextBox();
			answerCheckList = new CheckedListBox();
			SuspendLayout();
			// 
			// submitButton
			// 
			submitButton.Location = new Point(159, 174);
			submitButton.Name = "submitButton";
			submitButton.Size = new Size(75, 23);
			submitButton.TabIndex = 0;
			submitButton.Text = "Submit";
			submitButton.UseVisualStyleBackColor = true;
			submitButton.Click += SubmitButton_Click;
			// 
			// questionLabel
			// 
			questionLabel.AutoSize = true;
			questionLabel.Location = new Point(181, 45);
			questionLabel.Name = "questionLabel";
			questionLabel.Size = new Size(38, 15);
			questionLabel.TabIndex = 1;
			questionLabel.Text = "label1";
			// 
			// answerTextBox
			// 
			answerTextBox.Location = new Point(150, 74);
			answerTextBox.Name = "answerTextBox";
			answerTextBox.Size = new Size(100, 23);
			answerTextBox.TabIndex = 2;
			// 
			// answerCheckList
			// 
			answerCheckList.FormattingEnabled = true;
			answerCheckList.Location = new Point(141, 63);
			answerCheckList.Name = "answerCheckList";
			answerCheckList.Size = new Size(120, 94);
			answerCheckList.TabIndex = 3;
			// 
			// QuestionInput
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(405, 229);
			Controls.Add(answerCheckList);
			Controls.Add(answerTextBox);
			Controls.Add(questionLabel);
			Controls.Add(submitButton);
			Name = "QuestionInput";
			Text = "Form1";
			Resize += OnFormResize;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Button submitButton;
		private Label questionLabel;
		private TextBox answerTextBox;
		private CheckedListBox answerCheckList;
	}
}
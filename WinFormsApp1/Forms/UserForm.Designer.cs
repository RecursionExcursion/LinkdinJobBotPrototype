namespace WinFormsApp1.Forms
{
	partial class UserForm
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
			usernameTextbox = new TextBox();
			userNameLabel = new Label();
			emailLabel = new Label();
			emailTextBox = new TextBox();
			passwordLabel = new Label();
			passwordTextBox = new TextBox();
			submitButton = new Button();
			cancelButton = new Button();
			deleteButton = new Button();
			SuspendLayout();
			// 
			// usernameTextbox
			// 
			usernameTextbox.Location = new Point(324, 113);
			usernameTextbox.Name = "usernameTextbox";
			usernameTextbox.Size = new Size(173, 25);
			usernameTextbox.TabIndex = 0;
			// 
			// userNameLabel
			// 
			userNameLabel.AutoSize = true;
			userNameLabel.Location = new Point(249, 117);
			userNameLabel.Name = "userNameLabel";
			userNameLabel.Size = new Size(71, 19);
			userNameLabel.TabIndex = 1;
			userNameLabel.Text = "Username";
			// 
			// emailLabel
			// 
			emailLabel.AutoSize = true;
			emailLabel.Location = new Point(249, 169);
			emailLabel.Name = "emailLabel";
			emailLabel.Size = new Size(41, 19);
			emailLabel.TabIndex = 3;
			emailLabel.Text = "Email";
			// 
			// emailTextBox
			// 
			emailTextBox.Location = new Point(324, 165);
			emailTextBox.Name = "emailTextBox";
			emailTextBox.Size = new Size(173, 25);
			emailTextBox.TabIndex = 2;
			// 
			// passwordLabel
			// 
			passwordLabel.AutoSize = true;
			passwordLabel.Location = new Point(249, 217);
			passwordLabel.Name = "passwordLabel";
			passwordLabel.Size = new Size(67, 19);
			passwordLabel.TabIndex = 5;
			passwordLabel.Text = "Password";
			// 
			// passwordTextBox
			// 
			passwordTextBox.Location = new Point(324, 213);
			passwordTextBox.Name = "passwordTextBox";
			passwordTextBox.Size = new Size(173, 25);
			passwordTextBox.TabIndex = 4;
			// 
			// submitButton
			// 
			submitButton.Location = new Point(296, 305);
			submitButton.Margin = new Padding(2);
			submitButton.Name = "submitButton";
			submitButton.Size = new Size(75, 25);
			submitButton.TabIndex = 6;
			submitButton.Text = "Submit";
			submitButton.UseVisualStyleBackColor = true;
			submitButton.Click += SubmitButton_Click;
			// 
			// cancelButton
			// 
			cancelButton.Location = new Point(422, 305);
			cancelButton.Margin = new Padding(2);
			cancelButton.Name = "cancelButton";
			cancelButton.Size = new Size(75, 25);
			cancelButton.TabIndex = 7;
			cancelButton.Text = "Cancel";
			cancelButton.UseVisualStyleBackColor = true;
			cancelButton.Click += CancelButton_Click;
			// 
			// deleteButton
			// 
			deleteButton.Anchor = AnchorStyles.None;
			deleteButton.AutoSize = true;
			deleteButton.Location = new Point(12, 12);
			deleteButton.Name = "deleteButton";
			deleteButton.Size = new Size(75, 29);
			deleteButton.TabIndex = 8;
			deleteButton.Text = "Delete";
			deleteButton.UseVisualStyleBackColor = true;
			deleteButton.Click += DeleteButton_Click;
			// 
			// UserForm
			// 
			AutoScaleDimensions = new SizeF(7F, 17F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(784, 461);
			Controls.Add(deleteButton);
			Controls.Add(cancelButton);
			Controls.Add(submitButton);
			Controls.Add(passwordLabel);
			Controls.Add(passwordTextBox);
			Controls.Add(emailLabel);
			Controls.Add(emailTextBox);
			Controls.Add(userNameLabel);
			Controls.Add(usernameTextbox);
			Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
			Name = "UserForm";
			Text = "AddUserForm";
			Resize += OnFormResize;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private TextBox usernameTextbox;
		private Label userNameLabel;
		private Label emailLabel;
		private TextBox emailTextBox;
		private Label passwordLabel;
		private TextBox passwordTextBox;
		private Button submitButton;
		private Button cancelButton;
		private Button deleteButton;
	}
}
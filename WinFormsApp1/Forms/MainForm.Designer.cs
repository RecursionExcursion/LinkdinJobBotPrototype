namespace WinFormsApp1
{
	partial class MainForm
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			startBotButton = new Button();
			userListView = new ListView();
			addUserButton = new Button();
			editUserButton = new Button();
			SuspendLayout();
			// 
			// startBotButton
			// 
			startBotButton.Anchor = AnchorStyles.None;
			startBotButton.AutoSize = true;
			startBotButton.Location = new Point(344, 376);
			startBotButton.Name = "startBotButton";
			startBotButton.Size = new Size(75, 25);
			startBotButton.TabIndex = 3;
			startBotButton.Text = "Start";
			startBotButton.UseVisualStyleBackColor = true;
			startBotButton.Click += StartBotButton_Click;
			// 
			// userListView
			// 
			userListView.Location = new Point(212, 85);
			userListView.Name = "userListView";
			userListView.Size = new Size(350, 280);
			userListView.TabIndex = 2;
			userListView.UseCompatibleStateImageBehavior = false;
			userListView.SelectedIndexChanged += UserListViewSelectedIndexChanged;
			// 
			// addUserButton
			// 
			addUserButton.AutoSize = true;
			addUserButton.Location = new Point(212, 54);
			addUserButton.Name = "addUserButton";
			addUserButton.Size = new Size(75, 25);
			addUserButton.TabIndex = 1;
			addUserButton.Text = "Add User";
			addUserButton.UseVisualStyleBackColor = true;
			addUserButton.Click += AddUserButton_Click;
			// 
			// editUserButton
			// 
			editUserButton.AutoSize = true;
			editUserButton.Location = new Point(487, 54);
			editUserButton.Name = "editUserButton";
			editUserButton.Size = new Size(75, 25);
			editUserButton.TabIndex = 4;
			editUserButton.Text = "Edit User";
			editUserButton.UseVisualStyleBackColor = true;
			editUserButton.Click += EditUserButton_Click;
			// 
			// MainForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			AutoSize = true;
			ClientSize = new Size(784, 461);
			Controls.Add(editUserButton);
			Controls.Add(addUserButton);
			Controls.Add(startBotButton);
			Controls.Add(userListView);
			Name = "MainForm";
			Text = "Form1";
			Load += OnFormLoad;
			Resize += OnFormResize;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Button startBotButton;
		private ListView userListView;
		private Button addUserButton;
		private Button editUserButton;
	}
}
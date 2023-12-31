﻿using System.Data;
using WinFormsApp1.Forms.Utility;
using WinFormsApp1.Models;
using WinFormsApp1.Selenium;

namespace WinFormsApp1.Forms
{
	public partial class UserForm : FormBase
	{

		public UserProfile? NewUser { get; private set; }

		private UserProfile? existingUser;

		public UserForm()
		{
			InitializeComponent();
			InitializeControlResizer();

			FormUtility.DisableControl(deleteButton);
		}

		public UserForm(UserProfile user)
		{
			InitializeComponent();
			InitializeControlResizer();

			existingUser = user;
			InitailzieTextBoxesForUser(existingUser);
		}

		/* Events */
		private void CancelButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void SubmitButton_Click(object sender, EventArgs e)
		{


			bool textBoxhasNullValue = this.Controls
										.Cast<Control>()
										.Where(c => c is TextBox)
										.Select(tb => tb.Text)
										.Where(t => string.IsNullOrEmpty(t))
										.Any();

			if (!textBoxhasNullValue)
			{
				if (existingUser == null)
				{
					NewUser = new UserProfile(usernameTextbox.Text, emailTextBox.Text, passwordTextBox.Text);
				}
				else
				{
					existingUser.ProfileName = usernameTextbox.Text;
					existingUser.Email = emailTextBox.Text;
					existingUser.Password = passwordTextBox.Text;
				}
				this.Close();
			}
		}

		private void DeleteButton_Click(object sender, EventArgs e)
		{
			if (existingUser != null)
			{
				UserManager.Instance.DeleteUser(existingUser);
				Close();
			}
		}
		/* Helpers */

		private void InitailzieTextBoxesForUser(UserProfile user)
		{
			usernameTextbox.Text = user.ProfileName;
			emailTextBox.Text = user.Email;
			passwordTextBox.Text = user.Password;
		}

		private void OnFormResize(object sender, EventArgs e)
		{
			controlResizer.ResizeControlsOnFormResize();
		}
	}
}

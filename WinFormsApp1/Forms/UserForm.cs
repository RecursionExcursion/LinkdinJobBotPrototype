using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp1.Forms.Utility;
using WinFormsApp1.Models;

namespace WinFormsApp1.Forms
{
	public partial class UserForm : Form
	{

		public UserProfile NewUser { get; private set; }

		private UserProfile existingUser;

		public UserForm()
		{
			InitializeComponent();
			FormInitalizer.Initalize(this);
		}

		public UserForm(UserProfile user)
		{
			InitializeComponent();
			FormInitalizer.Initalize(this);
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
			Func<String[], Boolean> DoStringsHaveValues = (strings) => {

				foreach (var s in strings)
				{
					if (string.IsNullOrEmpty(s))
					{
						return false;
					}
				}
				return true;
			};

			string[] textBoxStrings = new string[]
			{
				usernameTextbox.Text, emailTextBox.Text, passwordTextBox.Text
			};

			if (DoStringsHaveValues(textBoxStrings))
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

		/* Helpers */

		private void InitailzieTextBoxesForUser(UserProfile user)
		{
			usernameTextbox.Text = user.ProfileName;
			emailTextBox.Text = user.Email;
			passwordTextBox.Text = user.Password;
		}
	}
}

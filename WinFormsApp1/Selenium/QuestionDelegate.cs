using WinFormsApp1.Forms;
using WinFormsApp1.Models;

namespace WinFormsApp1.Selenium
{
	public class QuestionDelegate
	{
		private readonly UserProfile user;
		private readonly UserManager userManager = UserManager.Instance;

		public QuestionDelegate(UserProfile user)
		{
			this.user = user;
		}

		public string GetAnswer(string question)
		{
			string ans;
			try
			{
				ans = user.Q_A[question];
			}
			catch (Exception)
			{
				AddDataFromPopUp(question);
				ans = user.Q_A[question];
			}
			return ans;
		}

		public void RemoveQAFromUser(string question)
		{
			user.Q_A.Remove(question);
			userManager.SyncData();
		}

		public void AddDataFromPopUp(string question)
		{
			QuestionInput input = new QuestionInput(question);
			input.ShowDialog();

			user.Q_A.Add(question, input.GetSubmittedAnswer());
			userManager.SyncData();
		}

		public void HandleIncorrectInput(string question)
		{
			string message = "Answer does not apply, please try again";
			MessageBox.Show(message);
			RemoveQAFromUser(question);
		}
	}
}
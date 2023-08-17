using WinFormsApp1.Forms;
using WinFormsApp1.Models;

namespace WinFormsApp1.Selenium.QA
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
			return GetAnswer(question, null);
		}

		public string GetAnswer(string question, List<string>? answerList)
		{
			string ans;
			try
			{
				ans = user.Q_A[question];
				if (string.IsNullOrEmpty(ans))
				{
					RemoveQAFromUser(question);
					throw new NullReferenceException();
				}
			}
			catch (Exception)
			{
				if (answerList == null)
				{
					AddDataFromPopUp(question);
				}
				else
				{
					AddDataFromPopUp(question, answerList);
				}
				ans = user.Q_A[question];
			}
			return ans;
		}

		private void AddDataFromPopUp(string question)
		{
			AddDataFromPopUp(question, null);
		}
		private void AddDataFromPopUp(string question, List<string>? answerList)
		{
			QuestionInput input = answerList == null ? new(question) : new(question, answerList);
			input.ShowDialog();
			user.Q_A.Add(question, input.GetSubmittedAnswer());
			userManager.SyncData();
		}

		public void RemoveQAFromUser(string question)
		{
			user.Q_A.Remove(question);
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
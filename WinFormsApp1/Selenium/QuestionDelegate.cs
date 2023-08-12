using WinFormsApp1.Forms;
using WinFormsApp1.Models;

namespace WinFormsApp1.Selenium
{
	public class QuestionDelegate
	{

		private readonly UserProfile user;
		private readonly Dictionary<string, string> questionAsnwerDictionary;
		private readonly UserManager userManager = UserManager.Instance;

		public QuestionDelegate(UserProfile user)
		{
			this.user = user;
			questionAsnwerDictionary = user.Q_A.ToDictionary(qa => qa.Question, qa => qa.Answer);
		}

		public string GetAnswer(string question) => questionAsnwerDictionary[question];

		public void AddDataIfDoesNotExist(string question)
		{
			while (questionAsnwerDictionary[question] == null)
			{
				AddDataFromPopUp(question);
			}
		}

		public void RemoveQAFromUser(string question)
		{
			foreach (var qa in user.Q_A)
			{
				if (string.Equals(qa.Question, question, StringComparison.OrdinalIgnoreCase))
				{
					user.Q_A.Remove(qa);
					break;
				}
			}
			userManager.SyncData();
		}

		public void AddDataFromPopUp(string question)
		{
			QuestionInput input = new QuestionInput(question);
			input.ShowDialog();

			QA qa = new QA() {
				Question = question,
				Answer = input.GetSubmittedAnswer()
			};

			user.Q_A.Add(qa);
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
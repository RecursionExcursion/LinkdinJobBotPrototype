using OpenQA.Selenium;
using WinFormsApp1.Selenium.Phases;
using WinFormsApp1.Selenium.Utility;

namespace WinFormsApp1.Selenium.QA
{
	public class RadioQuestion : QA
	{

		public List<string>? AnswerValues { get; set; }

	
		public RadioQuestion(CustomDriver driver, IWebElement parentDiv) : base(driver, parentDiv) { }

		public override void Run()
		{
			Answer();
		}

		protected override void Answer()
		{
			List<IWebElement> inputTags = elementLocator.FindElements(parentDiv, By.XPath(".//input"));
			IWebElement span = elementLocator.FindElement(parentDiv, By.XPath(".//span[@aria-hidden=\"true\"]"));

			List<string> ansValues = inputTags.Select(i => i.GetAttribute("value")).ToList();

			string question = span.Text;

			bool questionAnswered = false;
			while (!questionAnswered)
			{
				try
				{
					string ans = questionDelegate.GetAnswer(question, ansValues);
					foreach (IWebElement input in inputTags)
					{
						string val = input.GetAttribute("value");
						if (string.Equals(val, ans, StringComparison.OrdinalIgnoreCase))
						{
							actions.MoveToAndClick(input).Perform();
							questionAnswered = true;
							break;
						}
					}
				}
				catch (Exception)
				{
					questionDelegate.HandleIncorrectInput(question);
				}
			}
		}
	}
}
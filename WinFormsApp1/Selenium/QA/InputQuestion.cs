using OpenQA.Selenium;
using WinFormsApp1.Selenium.Phases;
using WinFormsApp1.Selenium.Utility;

namespace WinFormsApp1.Selenium.QA
{
	internal class InputQuestion : QA
	{
		public InputQuestion(CustomDriver driver, IWebElement parentDiv) : base(driver, parentDiv) { }

		public override void Run()
		{
			Answer();
		}

		protected override void Answer()
		{
			string question = GetQuestion(parentDiv);

			//Input
			IWebElement inputTag = elementLocator.FindElement(parentDiv, By.XPath(".//input"));

			string value = inputTag.GetAttribute("value");
			string answer = questionDelegate.GetAnswer(question);

			if (string.IsNullOrEmpty(value))
			{
				actions.MoveToAndClick(inputTag)
							  .SendKeys(answer)
							  .Perform();
			}
			else if (string.Equals(value, answer, StringComparison.OrdinalIgnoreCase))
			{
				actions.MoveToAndClick(inputTag)
							  .ClearKeys()
							  .SendKeys(answer)
							  .Perform();
			}
		}
	}
}

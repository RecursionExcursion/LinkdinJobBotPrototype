using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using WinFormsApp1.Selenium.Phases;
using WinFormsApp1.Selenium.Utility;

namespace WinFormsApp1.Selenium.QA
{
	public class SelectQuestion : QA
	{
		public SelectQuestion(CustomDriver driver, IWebElement parentDiv) : base(driver, parentDiv) { }

		public override void Run()
		{
			Answer();
		}

		protected override void Answer()
		{
			string question = GetQuestion(parentDiv);

			//Select
			IWebElement selectTag = elementLocator.FindElement(parentDiv, By.XPath(".//select"));
			SelectElement select = new SelectElement(selectTag);

			bool questionAnswered = false;
			while (!questionAnswered)
			{
				try
				{
					List<string> optionValues = select.Options
													  .Select(o => o.GetAttribute("value"))
													  .Where(v => !string.Equals(v, "Select an option", StringComparison.OrdinalIgnoreCase))
													  .ToList();


					string ans = questionDelegate.GetAnswer(question, optionValues);

					select.SelectByValue(ans);
					questionAnswered = true;
				}
				catch (Exception)
				{
					questionDelegate.HandleIncorrectInput(question);
				}
			}
		}
	}
}

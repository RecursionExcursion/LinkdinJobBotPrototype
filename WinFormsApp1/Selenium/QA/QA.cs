using OpenQA.Selenium;
using WinFormsApp1.Selenium.Phases;
using WinFormsApp1.Selenium.Utility;

namespace WinFormsApp1.Selenium.QA
{
	public abstract class QA : BotPhase
	{

		protected IWebElement parentDiv;

		protected QA(CustomDriver driver, IWebElement parentDiv) : base(driver)
		{
			this.parentDiv = parentDiv;
		}

		protected string GetQuestion(IWebElement parentDiv)
		{
			//Question Lae=bel
			IWebElement label = elementLocator.FindElement(parentDiv, By.XPath(".//label"));
			//Question Span
			List<IWebElement> spans = elementLocator.FindElements(label, By.XPath(".//span"));
			return spans.Count == 0 ? label.Text : spans[0].Text;
		}

		protected abstract void Answer();
	}
}

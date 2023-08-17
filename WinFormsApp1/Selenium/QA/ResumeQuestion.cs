using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1.Selenium.Utility;

namespace WinFormsApp1.Selenium.QA
{
	public class ResumeQuestion : QA
	{
		public ResumeQuestion(CustomDriver driver, IWebElement parentDiv) : base(driver, parentDiv) { }

		public override void Run()
		{
			Answer();
		}

		protected override void Answer()
		{
			//H3
			List<IWebElement> h3Tags = elementLocator.FindElements(parentDiv, By.XPath(".//h3"));

			List<string> resumeText = h3Tags.Select(t => t.Text).ToList();

			string question = "Resume";

			string resumeName = questionDelegate.GetAnswer(question, resumeText);

			IWebElement? resumeH3 = null;

			foreach (IWebElement h3Tag in h3Tags)
			{
				if (string.Equals(h3Tag.Text, resumeName, StringComparison.OrdinalIgnoreCase))
				{
					resumeH3 = h3Tag;
				}
			}

			if (resumeH3 != null)
			{
				//Xpath retrieves parent's parent element h3->p->div
				IWebElement resumeDiv = elementLocator.FindElement(resumeH3, By.XPath("./../.."));
				if (string.Equals(resumeDiv.GetAttribute("aria-label"), "Selected", StringComparison.OrdinalIgnoreCase))
				{
					actions.MoveToAndClick(resumeDiv).Perform();
				}
			}
			else
			{
				throw new NotFoundException("Could not find h3 for resume");
			}
		}
	}
}

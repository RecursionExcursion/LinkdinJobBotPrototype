using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using WinFormsApp1.Models;
using WinFormsApp1.Selenium.QA;
using WinFormsApp1.Selenium.Utility;

namespace WinFormsApp1.Selenium.Phases
{
	public class ApplyForJob : BotPhase
	{

		private readonly int applyMax;

		public ApplyForJob(CustomDriver driver, int applyMax) : base(driver)
		{
			this.applyMax = applyMax;
		}


		public override void Run()
		{
			//Search Results Div
			IWebElement searchResultDiv = elementLocator.FindElement(By.XPath("//ul[@class=\"scaffold-layout__list-container\"]"));

			//Search Result elements
			List<IWebElement> searchResultsElements = elementLocator.FindElements(searchResultDiv, By.ClassName("jobs-search-results__list-item"));

			int applied = 0;

			for (int i = 0; i < searchResultsElements.Count && applied < applyMax; i++)
			{
				IWebElement element = searchResultsElements[i];
				actions.MoveToAndClick(element).Perform();
				try
				{
					FindAndClickEasyApplyButton();
				}
				catch (Exception)
				{
					continue;
				}
				Apply();
				applied++;
			}
		}

		private void FindAndClickEasyApplyButton()
		{
			//TODO replace try catch with boolean?
			IWebElement easyApplyButtonElement = elementLocator.FindElementAfterSleep(By.XPath("//span[text()='Easy Apply']//parent::button"), 1.5);
			actions.MoveToAndClick(easyApplyButtonElement).Perform();
		}

		private void Apply()
		{

			bool applicationFinished = false;

			while (!applicationFinished)
			{
				//App Form
				IWebElement formDiv = elementLocator.FindElement(By.XPath("//div[@class=\"ph5\"]//parent::form"));

				//Resume
				List<IWebElement> resumeDivs = elementLocator.FindElements(formDiv, By.XPath(".//div[@class=\"mt2\"]"));
				//Question
				List<IWebElement> questionDivs = elementLocator.FindElements(formDiv, By.XPath(".//div[starts-with(@class,\"jobs-easy-apply-form-section__grouping\")]"));

				foreach (IWebElement div in questionDivs)
				{
					if (IsSelectQuestion(div))
					{
						AnswerSelectQuestion(div);
					}
					else if (IsRadioQuestion(div))
					{
						AnswerRadioQuestion(div);
					}
					else if (IsInputQuestion(div))
					{
						AnswerInputQuestion(div);
					}
					else
					{
						throw new NotFoundException("Question type not found");
					}
				}


				foreach (IWebElement resumeDiv in resumeDivs)
				{
					SelectResume(resumeDiv);
				}

				//Find and click continue button
				IWebElement? continueButton = GetContinueButton(formDiv);
				if (continueButton == null)
				{
					throw new NullReferenceException("Continue button is null");
				}
				if (continueButton.GetAttribute("aria-label").Equals("Review your application", StringComparison.OrdinalIgnoreCase))
				{
					applicationFinished = true;
				}

				actions.MoveToAndClick(continueButton).Perform();
			}
			ReviewApplication();
			PostApplyDialog();

		}

		private bool IsRadioQuestion(IWebElement div) => elementLocator.ElementExists(div, By.TagName("fieldset"));

		private bool IsSelectQuestion(IWebElement div) => elementLocator.ElementExists(div, By.TagName("select"));

		private bool IsInputQuestion(IWebElement div) => elementLocator.ElementExists(div, By.TagName("input"));

		private void AnswerSelectQuestion(IWebElement div) => new SelectQuestion(driver, div).Run();

		private void AnswerRadioQuestion(IWebElement div) => new RadioQuestion(driver, div).Run();

		private void AnswerInputQuestion(IWebElement div) => new InputQuestion(driver, div).Run();

		private void SelectResume(IWebElement parentDiv) => new ResumeQuestion(driver, parentDiv).Run();

		private IWebElement? GetContinueButton(IWebElement formDiv)
		{
			Func<By, IWebElement?> GetButtonOrNull = b => {
				List<IWebElement> buttons = elementLocator.FindElements(formDiv, b);
				return buttons.Count > 0 ? elementLocator.FindElement(formDiv, b) : null;
			};

			//Continue Next
			By nextXpath = By.XPath(".//button[@aria-label=\"Continue to next step\"]");
			//Continue Review
			By reviewXpath = By.XPath(".//button[@aria-label=\"Review your application\"]");
			//Continue Submit
			By submitXpath = By.XPath(".//button[@aria-label=\"Submit application\"]");

			IWebElement?[] buttons = new List<By> { nextXpath, reviewXpath, submitXpath }
									.Select(by => GetButtonOrNull(by))
									.Where(s => s != null)
									.ToArray();

			return buttons.Length != 0 ? buttons[0] : null;
		}

		private void ReviewApplication()
		{
			//Review Follow Label
			By followlabelBy = By.XPath("//label[@for=\"follow-company-checkbox\"]");
			List<IWebElement> elements = elementLocator.FindElements(followlabelBy);
			if (elements.Count > 0)
			{
				IWebElement followInputDiv = elementLocator.FindElement(followlabelBy);
				followInputDiv.Click();
				//TODO remove?
				//actions.MoveToAndClick(followInputDiv).Perform();
			}

			//Review big Div
			By bigDivBy = By.XPath("//div[@class=\"jobs-easy-apply-content\"]");
			IWebElement bigDiv = elementLocator.FindElement(bigDivBy);
			IWebElement? submitButton = GetContinueButton(bigDiv);
			if (submitButton != null)
			{
				actions.MoveToAndClick(submitButton).Perform();
			}
			else
			{
				throw new Exception("Button is null");
			}
		}

		private void PostApplyDialog()
		{
			//Post Apply modal
			IWebElement postApply = elementLocator.FindElement(By.XPath("//div[@aria-labelledby=\"post-apply-modal\"]"));
			//Post Apply Dismiss Button
			IWebElement dismissButton = elementLocator.FindElement(postApply, By.XPath(".//button[@aria-label=\"Dismiss\"]"));
			actions.MoveToAndClick(dismissButton).Perform();
		}
	}
}
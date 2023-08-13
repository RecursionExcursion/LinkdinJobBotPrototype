using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using WinFormsApp1.Models;
using WinFormsApp1.Selenium.Constants;
using static WinFormsApp1.Selenium.Constants.ApplyByConstants;
using static WinFormsApp1.Selenium.Constants.ApplyByConstants.ByKeys;

namespace WinFormsApp1.Selenium.Phases
{
	public class ApplyForJob : BotPhase<ByKeys>
	{

		private readonly QuestionDelegate questionDelegate;
		private readonly int applyMax;

		public ApplyForJob(IWebDriver driver, ApplyByConstants constants, params object[] parameters) : base(driver, constants, parameters)
		{
			UserProfile user = (UserProfile) parameters[0];
			questionDelegate = new QuestionDelegate(user);
			applyMax = (int) parameters[1];
		}


		public override void Run()
		{

			IWebElement searchResultDiv = elementLocator.FindElement(by[SearchResultsDiv]);
			List<IWebElement> searchResultsElements = elementLocator.FindElements(searchResultDiv, by[SearchResutlsElements]);

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
			IWebElement easyApplyButtonElement = elementLocator.FindElementAfterSleep(by[EasyApplyButton], 1.5);
			actions.MoveToAndClick(easyApplyButtonElement).Perform();
		}

		private void Apply()
		{

			bool applicationFinished = false;

			while (!applicationFinished)
			{

				IWebElement formDiv = elementLocator.FindElement(by[AppForm]);

				List<IWebElement> resumeDivs = elementLocator.FindElements(formDiv, by[Resume]);

				List<IWebElement> questionDivs = elementLocator.FindElements(formDiv, by[Question]);

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
				IWebElement continueButton = GetContinueButton(formDiv);

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

		private void AnswerSelectQuestion(IWebElement div)
		{
			string question = GetQuestion(div);

			IWebElement selectTag = elementLocator.FindElement(div, by[Select]);
			SelectElement select = new SelectElement(selectTag);

			bool questionAnswered = false;
			while (!questionAnswered)
			{
				try
				{
					select.SelectByValue(questionDelegate.GetAnswer(question));
					questionAnswered = true;
				}
				catch (Exception)
				{
					questionDelegate.HandleIncorrectInput(question);
				}
			}
		}

		private void AnswerRadioQuestion(IWebElement div)
		{
			////TODO Handle when input does not match output

			List<IWebElement> inputTags = elementLocator.FindElements(div, By.XPath(".//input"));
			IWebElement span = elementLocator.FindElement(div, By.XPath(".//span[@aria-hidden=\"true\"]"));

			string question = span.Text;

			bool questionAnswered = false;
			while (!questionAnswered)
			{
				try
				{
					string ans = questionDelegate.GetAnswer(question);
					foreach (IWebElement input in inputTags)
					{
						string val = input.GetAttribute("value");
						if (string.Equals(val, question, StringComparison.OrdinalIgnoreCase))
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

		private void AnswerInputQuestion(IWebElement div)
		{
			string question = GetQuestion(div);

			//TODO
			//questionDelegate.AddDataIfDoesNotExist(question);

			IWebElement inputTag = elementLocator.FindElement(div, by[Input]);

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

		private string GetQuestion(IWebElement parentDiv)
		{
			IWebElement label = elementLocator.FindElement(parentDiv, by[QuestionLabel]);
			List<IWebElement> spans = elementLocator.FindElements(label, by[QuestionSpan]);
			return spans.Count == 0 ? label.Text : spans[0].Text;
		}

		private void SelectResume(IWebElement parentDiv)
		{
			List<IWebElement> h3Tags = elementLocator.FindElements(parentDiv, by[ResumeH3]);

			string question = "Resume";

			//questionDelegate.AddDataIfDoesNotExist(question);

			string resumeName = questionDelegate.GetAnswer(question);

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

		private IWebElement? GetContinueButton(IWebElement formDiv)
		{

			Func<By, IWebElement?> getButtonOrNull = b => {
				List<IWebElement> buttons = elementLocator.FindElements(formDiv, b);
				return buttons.Count > 0 ? elementLocator.FindElement(formDiv, b) : null;
			};

			By nextXpath = by[ContinueNext];
			By reviewXpath = by[ContinueReview];
			By submitXpath = by[ContinueSubmit];

			IWebElement?[] buttons = new List<By> { nextXpath, reviewXpath, submitXpath }
									.Select(by => getButtonOrNull(by))
									.Where(s => s != null)
									.ToArray();

			return buttons.Length != 0 ? buttons[0] : null;
		}

		private void ReviewApplication()
		{
			By followlabelBy = by[ReviewFollowLabel];
			List<IWebElement> elements = elementLocator.FindElements(followlabelBy);
			if (elements.Count > 0)
			{
				IWebElement followInputDiv = elementLocator.FindElement(followlabelBy);
				actions.MoveToAndClick(followInputDiv).Perform();
			}

			By bigDivBy = by[ReviewBigDiv];
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
			IWebElement postApply = elementLocator.FindElement(by[PostApplyModal]);
			IWebElement dismissButton = elementLocator.FindElement(postApply, by[PostApplyDismissButton]);
			actions.MoveToAndClick(dismissButton).Perform();
		}
	}
}
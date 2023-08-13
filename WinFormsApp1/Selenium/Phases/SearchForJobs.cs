using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Diagnostics;
using WinFormsApp1.Selenium.Constants;
using static WinFormsApp1.Selenium.Constants.SearchForJobsByConstants;
using static WinFormsApp1.Selenium.Constants.SearchForJobsByConstants.ByKeys;

namespace WinFormsApp1.Selenium.Phases
{
	public class SearchForJobs : BotPhase<ByKeys>
	{
		private readonly string jobDescription;
		private readonly string? jobLocation;
		private readonly SearchQuery searchQuery;

		public SearchForJobs(IWebDriver driver, SearchForJobsByConstants constants, params object[] parameters) : base(driver, constants, parameters)
		{
			searchQuery = (SearchQuery) parameters[0];
			jobLocation = searchQuery.LocationSearch;
			jobDescription = searchQuery.JobSearch;
		}

		public override void Run()
		{
			Size originalSize = MaximizeWindow();

			ClickJobsButton();
			EnterSearchbarData();
			SetFilters();

			ResetWindowSize(originalSize);
		}


		private void EnterSearchbarData()
		{
			EnterJobDescriptionInSearchbar(jobDescription);
			EnterJobLocationInSearchbar(jobLocation);
			actions.PressEnter().Perform();
		}

		private void EnterJobDescriptionInSearchbar(string jobDescription)
		{
			if (!string.IsNullOrEmpty(jobDescription))
			{
				IWebElement webElement = elementLocator.FindElement(by[TitleBar]);
				SendKeysToSearchBar(webElement, jobDescription);
			};
		}

		private void EnterJobLocationInSearchbar(string? jobLocation)
		{
			if (string.IsNullOrEmpty(jobLocation))
			{
				jobLocation = "";
			}

			IWebElement webElement = elementLocator.FindElement(by[LocationBar]);
			SendKeysToSearchBar(webElement, jobLocation);
		}

		private void SendKeysToSearchBar(IWebElement element, string searchText)
		{
			actions.MoveToAndClick(element)
				   .SendKeys(searchText)
				   .Perform();
		}

		private void ClickJobsButton() => ClickButton(by[JobsButton]);

		private void ClickButton(By by) => actions.MoveToAndClick(elementLocator.FindElement(by)).Perform();

		private void SetFilters()
		{
			if (searchQuery.ExperianceChoiceID.Count != 0)
			{
				SetUpExperienceFilters();
			}

			if (searchQuery.LocationChoiceID.Count != 0)
			{
				SetUpLocationFilters();
			}

			ClickButton(by[EasyApplyButton]);
		}

		private void SetUpExperienceFilters()
		{
			SetSearchParams(by[ExperianceSearchFilterButton], searchQuery.ExperianceChoiceID);
		}

		private void SetUpLocationFilters()
		{
			SetSearchParams(by[WorkplaceTypeSearchFilterButton], searchQuery.LocationChoiceID);
		}

		private void SetSearchParams(By buttonId, List<string> idList)
		{
			elementLocator.WaitForDOMUpdate(TimeSpan.FromSeconds(1.0));

			//Presses main button
			IWebElement parameterButton = elementLocator.FindElement(buttonId);

			actions.MoveToAndClick(parameterButton).Perform();

			elementLocator.WaitForDOMUpdate(TimeSpan.FromSeconds(1.0));

			List<IWebElement> allInputs = elementLocator.FindElements(By.TagName("input"));
			List<IWebElement> filteredElements = allInputs.Where(e => idList.Contains(e.GetAttribute("id"))).ToList();


			foreach (IWebElement element in filteredElements)
			{
				actions.MoveToAndClick(element).Perform();
			}

			//Click filter button again to remove overlay
			parameterButton = elementLocator.FindElement(buttonId);

			actions.MoveToAndClick(parameterButton).Perform();

			elementLocator.WaitForDOMUpdate(TimeSpan.FromSeconds(3.0));
		}

		private Size MaximizeWindow()
		{
			Size originalSize = driver.Manage().Window.Size;
			driver.Manage().Window.Maximize();
			return originalSize;
		}

		private void ResetWindowSize(Size originalSize)
		{
			driver.Manage().Window.Size = originalSize;
		}
	}
}
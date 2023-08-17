using OpenQA.Selenium;
using WinFormsApp1.Selenium.Utility;

namespace WinFormsApp1.Selenium.Phases
{
	public class SearchForJobs : BotPhase
	{
		private readonly string jobDescription;
		private readonly string? jobLocation;
		private readonly SearchQuery searchQuery;

		public SearchForJobs(CustomDriver driver, SearchQuery searchQuery) : base(driver)
		{
			this.searchQuery = searchQuery;
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
				//Title bar
				IWebElement webElement = elementLocator.FindElement(By.XPath("//input[starts-with(@id,'jobs-search-box-keyword-id-ember')]"));
				SendKeysToSearchBar(webElement, jobDescription);
			};
		}

		private void EnterJobLocationInSearchbar(string? jobLocation)
		{
			if (string.IsNullOrEmpty(jobLocation))
			{
				jobLocation = "";
			}

			//Location bar
			IWebElement webElement = elementLocator.FindElement(By.XPath("//input[starts-with(@id,'jobs-search-box-location-id-ember')]"));
			SendKeysToSearchBar(webElement, jobLocation);
		}

		private void SendKeysToSearchBar(IWebElement element, string searchText)
		{
			actions.MoveToAndClick(element)
				   .SendKeys(searchText)
				   .Perform();
		}

		//Jobs Button
		private void ClickJobsButton() => ClickButton(By.XPath("//a[@href='https://www.linkedin.com/jobs/?']"));

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
			//Easy Apply Button
			ClickButton(By.XPath("//button[@aria-label=\"Easy Apply filter.\"]"));
		}

		private void SetUpExperienceFilters()
		{
			//Experiance Filter button
			SetSearchParams(By.Id("searchFilter_experience"), searchQuery.ExperianceChoiceID);
		}

		private void SetUpLocationFilters()
		{
			//Workplace type filter button
			SetSearchParams(By.Id("searchFilter_workplaceType"), searchQuery.LocationChoiceID);
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
			Size originalSize = driver.Driver.Manage().Window.Size;
			driver.Driver.Manage().Window.Maximize();
			return originalSize;
		}

		private void ResetWindowSize(Size originalSize)
		{
			driver.Driver.Manage().Window.Size = originalSize;
		}
	}
}
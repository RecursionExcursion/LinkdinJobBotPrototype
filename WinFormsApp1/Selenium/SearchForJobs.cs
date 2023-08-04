using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Selenium
{
	public class SearchForJobs
	{
		private readonly IWebDriver driver;
		private readonly ActionsDelegate actions;
		private readonly string jobDescription;
		private readonly string jobLocation;
		private readonly SmartElementLocator elementLocator;


		private SearchForJobs(IWebDriver driver, string jobDescription, string jobLocation)
		{
			this.driver = driver;
			this.jobDescription = jobDescription;
			this.jobLocation = jobLocation;
			actions = ActionsDelegate.BuildActionChain(driver);
			elementLocator = new SmartElementLocator(driver);
		}


		public static void ExecuteSearch(IWebDriver driver, string jobDescription, string jobLocation)
		{
			new SearchForJobs(driver, jobDescription, jobLocation).Search();
		}


		private void Search()
		{
			Size originalSize = driver.Manage().Window.Size;
			driver.Manage().Window.Maximize();

			ClickJobsButton();

			EnterJobDescriptionInSearchbar(jobDescription);
			EnterJobLocationInSearchbar(jobLocation);
			actions.PressEnter().Perform();

			SetUpExperienceFilters();
			SetUpLocationFilters();
			ClickEasyApplyButton();

			driver.Manage().Window.Size = originalSize;
		}


		private void EnterJobDescriptionInSearchbar(string jobDescription)
		{
			if (!string.IsNullOrEmpty(jobDescription))
			{
				string jobTitleBarXpath = "//input[starts-with(@id,'jobs-search-box-keyword-id-ember')]";
				IWebElement webElement = elementLocator.FindElement(By.XPath(jobTitleBarXpath));
				SendKeysToSearchBar(webElement, jobDescription);
			};
		}


		private void EnterJobLocationInSearchbar(string jobLocation)
		{

			if (String.IsNullOrEmpty(jobLocation))
			{
				jobLocation = "";
			}

			string locationBarXpath =
				"//input[starts-with(@id,'jobs-search-box-location-id-ember')]";
			IWebElement webElement = elementLocator.FindElement(By.XPath(locationBarXpath));
			SendKeysToSearchBar(webElement, jobLocation);

		}


		private void SendKeysToSearchBar(IWebElement element, string searchText)
		{
			actions.MoveToAndClick(element)
				   .SendKeys(searchText)
				   .Perform();
		}


		private void ClickJobsButton() =>
			ClickButton("//a[@href='https://www.linkedin.com/jobs/?']");

		private void ClickEasyApplyButton() =>
			ClickButton("//button[@aria-label=\"Easy Apply filter.\"]");


		private void ClickButton(string buttonXpath)
		{
			IWebElement element = elementLocator.FindElement(By.XPath(buttonXpath));
			actions.MoveToAndClick(element).Perform();
		}


		private void SetUpExperienceFilters()
		{
			By parentBy = By.XPath("//div[@id=\"hoverable-outlet-experience-level-filter-value\"]");

			string experienceParametersButtonXpath = "//button[contains(@aria-label,\"Experience level filter.\")]";

			List<string> ids = new List<string> { experianceIDMap["Internship"], experianceIDMap["Entry Level"] };

			SetSearchParams(experienceParametersButtonXpath, parentBy, ids);
		}


		private void SetUpLocationFilters()
		{
			By parentBy = By.XPath("//div[@id=\"hoverable-outlet-on-site/remote-filter-value\"]");

			string locationParametersButtonXpath = "//button[contains(@aria-label,\"On-site/remote filter.\")]";

			List<String> ids = new List<string> { locationIDMap["Remote"] };

			SetSearchParams(locationParametersButtonXpath, parentBy, ids);
		}


		//TODO not working
		private void SetSearchParams(string buttonXpath, By parentBy, List<string> idList)
		{
			//Presses main button
			IWebElement parameterButton = elementLocator.FindElement(By.XPath(buttonXpath));

			actions.MoveToAndClick(parameterButton).Perform();

			//Selects from drop down
			IWebElement parent = elementLocator.FindElementAfter(parentBy, 2);

			List<IWebElement> inputs = elementLocator.FindElements(parent, By.XPath(".//input"));

			IEnumerable<IWebElement> elements = inputs.Where(inp => idList.Contains(inp.GetAttribute("id")));

			foreach (IWebElement element in elements)
			{
				actions.MoveToAndClick(element);
			}
			actions.Perform();

			//Click filter button again to remove overlay
			parameterButton = elementLocator.FindElement(By.XPath(buttonXpath));

			actions.MoveToAndClick(parameterButton).Perform();
		}


		//TODO Testing only
		private static readonly Dictionary<string, string> locationIDMap = getLocationIDMap();
		private static readonly Dictionary<string, string> experianceIDMap = getExperienceIDMap();

		private static Dictionary<string, string> getLocationIDMap()
		{
			Dictionary<string, string> locationIdMap = new Dictionary<string, string>
			{
				{ "OnSite", "workplaceType-1" },
				{ "Remote", "workplaceType-2" },
				{ "Hybrid", "workplaceType-3" }
			};
			return locationIdMap;
		}

		private static Dictionary<string, string> getExperienceIDMap()
		{
			Dictionary<string, string> experianceIdMap = new Dictionary<string, string>
			{
				{ "Internship", "experience-1" },
				{ "Entry Level", "experience-2" },
				{ "Associate", "experience-3" },
				{ "Mid-Senior Level", "experience-4" },
				{ "Director", "experience-5" },
				{ "Executive", "experience-6" }
			};
			return experianceIdMap;
		}
	}
}

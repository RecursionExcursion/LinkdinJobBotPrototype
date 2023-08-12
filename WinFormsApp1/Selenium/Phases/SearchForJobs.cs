using OpenQA.Selenium;
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
            Size originalSize = driver.Manage().Window.Size;
            driver.Manage().Window.Maximize();
            //Click 'Jobs' button
            ClickButton(by[JobsButton]);

            EnterJobDescriptionInSearchbar(jobDescription);
            EnterJobLocationInSearchbar(jobLocation);
            actions.PressEnter().Perform();

            SetUpExperienceFilters();
            SetUpLocationFilters();

            //Click 'Easy Apply' button
            ClickButton(by[EasyApplyButton]);

            driver.Manage().Window.Size = originalSize;
        }


        private void EnterJobDescriptionInSearchbar(string jobDescription)
        {
            if (!string.IsNullOrEmpty(jobDescription))
            {
                IWebElement webElement = elementLocator.FindElement(by[TitleBar]);
                SendKeysToSearchBar(webElement, jobDescription);
            };
        }


        private void EnterJobLocationInSearchbar(string jobLocation)
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

        private void ClickButton(By by)
        {
            IWebElement element = elementLocator.FindElement(by);
            actions.MoveToAndClick(element).Perform();
        }


        private void SetUpExperienceFilters()
        {
            SetSearchParams(by[ExperienceFiltersButton], by[ExperienceFiltersParent], searchQuery.ExperianceChoiceID);
        }


        private void SetUpLocationFilters()
        {
            SetSearchParams(by[LocationFiltersParent], by[LocationFiltersButton], searchQuery.LocationChoiceID);
        }


        private void SetSearchParams(By buttonBy, By parentBy, List<string> idList)
        {
            //Presses main button
            IWebElement parameterButton = elementLocator.FindElementAfter(buttonBy,3);

            actions.MoveToAndClick(parameterButton).Perform();

            //Selects from drop down
            IWebElement parent = elementLocator.FindElementAfter(parentBy, 3);

            List<IWebElement> inputs = elementLocator.FindElements(parent, by[InElementInput]);

            IEnumerable<IWebElement> elements = inputs.Where(inp => idList.Contains(inp.GetAttribute("id")));

            foreach (IWebElement element in elements)
            {
                actions.MoveToAndClick(element);
            }
            actions.Perform();

            //Click filter button again to remove overlay
            parameterButton = elementLocator.FindElement(buttonBy);

            actions.MoveToAndClick(parameterButton).Perform();
        }
    }
}

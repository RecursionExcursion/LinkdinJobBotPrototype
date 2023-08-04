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

            IWebElement experienceDiv = elementLocator.FindElement(By.XPath("//div[@id=\"hoverable-outlet-experience-level-filter-value\"]"));

            string experienceParametersButtonXpath = "//button[contains(@aria-label,\"Experience level filter.\")]";

            List<string> ids = new List<string> { experianceIDMap["Internship"], experianceIDMap["Entry Level"] };

            SetSearchParams(experienceParametersButtonXpath, experienceDiv, ids);
        }

        private void SetUpLocationFilters()
        {

            IWebElement locationDiv = elementLocator.FindElementAfter(By.XPath("//div[@id=\"hoverable-outlet-on-site/remote-filter-value\"]"), 5);

            string locationParametersButtonXpath = "//button[contains(@aria-label,\"On-site/remote filter.\")]";

            List<String> ids = new List<string> { locationIDMap["Remote"] };

            SetSearchParams(locationParametersButtonXpath, locationDiv, ids);
        }

        //TODO not working
        private void SetSearchParams(string buttonXpath, IWebElement parent, List<string> idList)
        {
            //Presses main button
            IWebElement parameterButton = elementLocator.FindElement(By.XPath(buttonXpath));

            actions.MoveToAndClick(parameterButton).Perform();

            //Selects from drop down
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




            //List < By > bys = new List<By>();

            //List<string> xPaths = new List<string>();

            //foreach (string id in idList)
            //{
            //    xPaths.Add($"//input[@id='{id}']");
            //    bys.Add(By.Id(id));
            //}


            //List<IWebElement> elements = new List<IWebElement>();


            //foreach (string xpXpath in xPaths)
            //{
            //    elements.Add(elementLocator.FindElement(By.XPath(xpXpath)));
            //}


            ////foreach (By by in bys)
            ////{
            ////    elements.Add(elementLocator.FindElement(by));
            ////}


            //foreach (IWebElement element in elements)
            //{
            //    actions.MoveToAndClick(element);
            //}
            //actions.Perform();

            ////Click filter button again to remove overlay
            //actions.MoveToAndClick(parameterButton).Perform();
        }


        //TODO Testing only
        private static readonly Dictionary<string, string> locationIDMap = getLocationIDMap();
        private static readonly Dictionary<string, string> experianceIDMap = getExperienceIDMap();

        private static Dictionary<string, string> getLocationIDMap()
        {
            Dictionary<string, string> locationIdMap = new Dictionary<string, string>();
            locationIdMap.Add("OnSite", "workplaceType-1");
            locationIdMap.Add("Remote", "workplaceType-2");
            locationIdMap.Add("Hybrid", "workplaceType-3");
            return locationIdMap;
        }

        private static Dictionary<string, string> getExperienceIDMap()
        {
            Dictionary<string, string> experianceIdMap = new Dictionary<string, string>();
            experianceIdMap.Add("Internship", "experience-1");
            experianceIdMap.Add("Entry Level", "experience-2");
            experianceIdMap.Add("Associate", "experience-3");
            experianceIdMap.Add("Mid-Senior Level", "experience-4");
            experianceIdMap.Add("Director", "experience-5");
            experianceIdMap.Add("Executive", "experience-6");
            return experianceIdMap;
        }
    }
}

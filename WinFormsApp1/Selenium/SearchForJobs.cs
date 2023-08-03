using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.CodeDom;
using System.Collections.Generic;
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


        public SearchForJobs(IWebDriver driver, string jobDescription, string jobLocation)
        {
            this.driver = driver;
            this.jobDescription = jobDescription;
            this.jobLocation = jobLocation;
            actions = new ActionsDelegate(driver);
        }

        public static void ExecuteSearch(IWebDriver driver, string jobDescription, string jobLocation)
        {
            new SearchForJobs(driver, jobDescription, jobLocation).Search();
        }

        private void Search()
        {
            //throw new NotImplementedException();

            //driver.Navigate().Refresh();
            //ClickJobsButton();

            Size originalSize = driver.Manage().Window.Size;

            driver.Manage().Window.Maximize();

            //TODO rework press this first -> press jobs button -> continue

            EnterJobDescriptionInSearchbar(jobDescription);
            //EnterJobLocationInSearchbar(jobLocation);
            //ClickEasyApplyButton();
            //SetUpExperienceFilters();
            //SetUpLocationFilters();

            //driver.Manage().Window.Size = originalSize;

        }

        private void EnterJobDescriptionInSearchbar(string jobDescription)
        {
            if (!string.IsNullOrEmpty(jobDescription))
            {

                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

                string jobTitleBarXpath = "//input[@aria-label=\"Search\"]";

                IWebElement webElement = wait.Until(condition => driver.FindElement(By.XPath(jobTitleBarXpath)));
                    
                   
                //string jobTitleBarXpath = "//input[starts-with(@id,'jobs-search-box-keyword-id-ember')]";
                SendKeysToSearchBar(webElement, jobDescription);
            };
        }

        private void EnterJobLocationInSearchbar(string jobLocation)
        {
            if (!string.IsNullOrEmpty(jobLocation))
            {
                string locationBarXpath = "//input[starts-with(@id,'jobs-search-box-location-id-ember')]";
                IWebElement webElement = driver.FindElement(By.XPath(locationBarXpath));
                SendKeysToSearchBar(webElement, jobLocation);
            }
        }


        private void SendKeysToSearchBar(IWebElement element, string searchText)
        {
            actions.MoveToAndClick(element)
                   .SendKeysAndPressEnter(searchText)
                   .Perform();
        }


        private void ClickJobsButton() =>
            ClickButton("//a[@href='https://www.linkedin.com/jobs/?']");

        private void ClickEasyApplyButton() =>
            ClickButton("//button[@aria-label=\"Easy Apply filter.\"]");



        private void ClickButton(string buttonXpath)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            IWebElement element = driver.FindElement(By.XPath(buttonXpath));
            actions.MoveToAndClick(element).Perform();
        }


        private void SetUpExperienceFilters()
        {
            string experienceParametersButtonXpath = "//button[contains(@aria-label,\"Experience level filter.\")]";
            SetSearchParams(experienceParametersButtonXpath,
                            new List<string>
                            {
                                experianceIDMap["Internship"],
                                experianceIDMap["Entry Level"]
                            });
        }

        private void SetUpLocationFilters()
        {
            string locationParametersButtonXpath = "//button[contains(@aria-label,\"On-site/remote filter.\")]";
            SetSearchParams(locationParametersButtonXpath,
                new List<string>
                {
                    locationIDMap["Remote"]
                });
        }

        private void SetSearchParams(string buttonXpath, List<string> locationIDMap)
        {

            IWebElement parameterButton = driver.FindElement(By.XPath(buttonXpath));
            actions.MoveToAndClick(parameterButton).Perform();

            List<string> xPaths = new List<string>();
            foreach (string xp in locationIDMap)
            {
                xPaths.Add($"//input[@id='{xp}']");
            }
            List<IWebElement> elements = new List<IWebElement>();
            foreach (string xpXpath in xPaths)
            {

                elements.Add(driver.FindElement(By.XPath(xpXpath)));
            }
            foreach (IWebElement element in elements)
            {
                actions.MoveToAndClick(element);
            }
            actions.Perform();

            //Click filter button again to remove overlay
            actions.MoveToAndClick(parameterButton).Perform();
        }


        //TODO Testing only
        private static readonly Dictionary<string, string> locationIDMap = getLocationIDMap();
        private static readonly Dictionary<string, string> experianceIDMap = getExperienceIDMap();

        private static Dictionary<string, string> getLocationIDMap()
        {
            Dictionary<string, string> onSiteRemoteIdMap = new Dictionary<string, string>();
            onSiteRemoteIdMap.Add("OnSite", "workplaceType-1");
            onSiteRemoteIdMap.Add("Remote", "workplaceType-2");
            onSiteRemoteIdMap.Add("Hybrid", "workplaceType-3");
            return onSiteRemoteIdMap;
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

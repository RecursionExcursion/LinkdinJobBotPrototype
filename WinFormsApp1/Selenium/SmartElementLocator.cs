using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace WinFormsApp1.Selenium
{
    public class SmartElementLocator
    {

        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        public SmartElementLocator(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5.0));
        }

        //Waits for TimeSpan or until Element is located
        public IWebElement FindElement(By by)
        {
            int attempts = 2;
            while (attempts-- > 0)
            {
                try
                {
                    return wait.Until(ExpectedConditions.ElementIsVisible(by));
                }
                catch (Exception) { }
            }
            throw new Exception($"Element {by} could not be found");
        }

        public IWebElement FindElement(IWebElement element, By by)
        {
            int attempts = 2;
            while (attempts-- > 0)
            {
                try
                {
                    return element.FindElement(by);
                }
                catch (Exception) { }
            }
            throw new Exception($"Element {by} could not be found");
        }

        public List<IWebElement> FindElements(By by)
        {
            int attempts = 2;
            while (attempts-- > 0)
            {
                try
                {
                    ReadOnlyCollection<IWebElement> webElements =
                        wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(by));
                    return webElements.ToList();
                }
                catch (Exception) { }
            }
            Debug.WriteLine($"Elements {by} could not be found");
            return new List<IWebElement>();
        }

        public List<IWebElement> FindElements(IWebElement element, By by)
        {
            int attempts = 2;
            while (attempts-- > 0)
            {
                try
                {
                    ReadOnlyCollection<IWebElement> webElements = element.FindElements(by);
                    return webElements.ToList();
                }
                catch (Exception) { }
            }
            Debug.WriteLine($"Elements {by} could not be found");
            return new List<IWebElement>();
        }

        //Waits entire TimeSpan until searching for element
        public IWebElement FindElementAfter(By by, double wait)
        {
            TimeSpan originalWait = driver.Manage().Timeouts().ImplicitWait;
            IWebElement element;
            try
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(wait);
                element = driver.FindElement(by);
            } finally
            {
                driver.Manage().Timeouts().ImplicitWait = originalWait;
            }
            return element;
        }


        //Waits for set interval while polling for reasource as specfied intervals
        public IWebElement FindElementFluently(By by, double waitSeconds, double pollIntervalMs)
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(waitSeconds);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(pollIntervalMs);
            return fluentWait.Until(drv => drv.FindElement(by));
        }

        public IWebElement FindElementFluently(By by) => FindElementFluently(by, 10, 500);
    }
}

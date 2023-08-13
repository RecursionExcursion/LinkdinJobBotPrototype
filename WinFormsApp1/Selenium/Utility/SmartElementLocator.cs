using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace WinFormsApp1.Selenium.Utility
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
					return wait.Until(ExpectedConditions.ElementExists(by));
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
					ReadOnlyCollection<IWebElement> webElements = wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(by));
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
		
		//Sleeps entire Thread before searching for element
		public IWebElement FindElementAfterSleep(By by, double wait)
		{
			Thread.Sleep(TimeSpan.FromSeconds(wait));
			return driver.FindElement(by);
		}


		//Waits for set interval while polling for resource as specified intervals
		public IWebElement FindElementFluently(By by, double waitSeconds, double pollIntervalMs)
		{
			DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
			fluentWait.Timeout = TimeSpan.FromSeconds(waitSeconds);
			fluentWait.PollingInterval = TimeSpan.FromMilliseconds(pollIntervalMs);
			return fluentWait.Until(drv => drv.FindElement(by));
		}

		public IWebElement FindElementFluently(By by) => FindElementFluently(by, 10, 500);

		public bool ElementExists(IWebElement questionDiv, By by) => FindElements(questionDiv, by).Count > 0;

		public void WaitForDOMUpdate(TimeSpan delay)
		{
			Thread.Sleep(delay);
		}
	}
}

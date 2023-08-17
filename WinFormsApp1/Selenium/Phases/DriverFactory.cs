using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace WinFormsApp1.Selenium.Phases
{
	public class DriverFactory
	{

		public static IWebDriver GetDriver(string url)
		{
			IWebDriver driver;
			int attemptLimit = 3;
			do
			{
				driver = InitializeDriverToUrl(url);
			} while (!CheckIfPageLoadSuccessFull(driver) && --attemptLimit > 0);


			return driver;
		}

		private static IWebDriver InitializeDriverToUrl(string url)
		{
			IWebDriver driver = GetRandomWebDriver();
			driver.Navigate().GoToUrl(url);
			return driver;
		}

		private static IWebDriver GetRandomWebDriver()
		{
			static IWebDriver createChromeDriver() => new ChromeDriver();
			static IWebDriver createFirefoxDriver() => new FirefoxDriver();
			static IWebDriver createEdgeDriver() => new EdgeDriver();


			List<Func<IWebDriver>> drivers = new List<Func<IWebDriver>>()
			{
				createChromeDriver, createFirefoxDriver
			};

			var rand = new Random().Next(drivers.Count);
			return drivers[rand]();
		}


		private static bool CheckIfPageLoadSuccessFull(IWebDriver driver)
		{
			int refreshAttempt = 0;
			bool pageIsLoaded = false;

			while (!pageIsLoaded)
			{
				By validation = By.Id("session_key");
				try
				{
					IWebElement webElement = driver.FindElement(validation);
					if (webElement.Displayed)
					{
						pageIsLoaded = true;
					}
				}
				catch (Exception)
				{
					if (++refreshAttempt >= 3)
					{
						Console.WriteLine($"Driver- {driver} could not find ID-{validation.ToString} in DOM");
						driver.Close();
						return false;
					}
					driver.Navigate().Refresh();
				}
			}
			return true;
		}
	}
}

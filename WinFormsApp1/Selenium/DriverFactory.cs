using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace WinFormsApp1.Selenium
{
    public class DriverFactory
    {

        public static IWebDriver GetDriver(String url)
        {
            IWebDriver driver;
            int attemptLimit = 3;
            do
            {
                driver = getRandomWebDriver();
                driver.Navigate().GoToUrl(url);
            } while (!CheckIfPageLoadSuccessFull(driver) && --attemptLimit > 0);


            return driver;
        }

        private static IWebDriver getRandomWebDriver()
        {
            static IWebDriver createChromeDriver() => new ChromeDriver();
            static IWebDriver createFirefoxDriver() => new FirefoxDriver();
            static IWebDriver createEdgeDriver() => new EdgeDriver();


            List<Func<IWebDriver>> drivers = new List<Func<IWebDriver>>()
            {
                createChromeDriver, createFirefoxDriver, createEdgeDriver
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
                String validation = "session_key";
                try
                {
                    WebDriverWait wait = new WebDriverWait(driver,
                        TimeSpan.FromMilliseconds(Get3to5SecondWait()));

                    wait.Until(drvr => drvr.FindElement(By.Id(validation)));
                    pageIsLoaded = true;
                }
                catch (Exception)
                {
                    if (++refreshAttempt >= 3)
                    {
                        Console.WriteLine(
                            $"Driver- {driver} could not find ID-{validation} in DOM"
                            );
                        driver.Close();
                        return false;
                    }
                    driver.Navigate().Refresh();
                }
            }
            return true;
        }

        private static int Get3to5SecondWait()
        {
            return new Random().Next(3000) + 2000;
        }

    }
}

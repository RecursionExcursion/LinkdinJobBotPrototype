using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Diagnostics;

namespace WinFormsApp1.Selenium
{
    public class SeleniumBot
    {
        public void Run()
        {
            String url = "https://www.linkedin.com";
            IWebDriver driver = DriverFactory.GetDriver(url);


            Login.Exectute(driver, "rloup7@gmail.com", "walruss7");
            SearchForJobs.ExecuteSearch(driver, "C# Developer", "");
        }
    }
}

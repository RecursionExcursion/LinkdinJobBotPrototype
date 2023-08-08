using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Diagnostics;
using WinFormsApp1.Data;
using WinFormsApp1.Selenium.Constants;
using WinFormsApp1.Selenium.Phases;

namespace WinFormsApp1.Selenium
{
	public class SeleniumBot
	{
		public void Run()
		{
			//string url = "https://www.linkedin.com";
			//IWebDriver driver = DriverFactory.GetDriver(url);

			//new Login(driver, new LoginByConstants(), "rloup7@gmail.com", "walruss7").Run();
			//new SearchForJobs(driver, new SearchForJobsByConstants(), "C# Developer", "").Run();
			//new ApplyForJob(driver, new ApplyByConstants(), 2).Run();



			DataManager.Save();


		}
	}
}

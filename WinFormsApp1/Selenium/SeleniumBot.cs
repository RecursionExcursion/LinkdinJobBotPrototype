using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Diagnostics;
using WinFormsApp1.Data;
using WinFormsApp1.Models;
using WinFormsApp1.Selenium.Constants;
using WinFormsApp1.Selenium.Phases;

namespace WinFormsApp1.Selenium
{
	public class SeleniumBot
	{

		private readonly UserProfile user;
		private readonly SearchQuery searchQuery;

		public SeleniumBot(UserProfile user, SearchQuery searchQuery)
		{
			this.user = user;
			this.searchQuery = searchQuery;
		}

		public void Run()
		{
			string url = "https://www.linkedin.com";
			IWebDriver driver = DriverFactory.GetDriver(url);

			new Login(driver, new LoginByConstants(), user).Run();
			new SearchForJobs(driver, new SearchForJobsByConstants(),searchQuery).Run();
			new ApplyForJob(driver, new ApplyByConstants(), user, 2).Run();
		}
	}
}

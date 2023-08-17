using OpenQA.Selenium;
using WinFormsApp1.Models;
using WinFormsApp1.Selenium.Phases;
using WinFormsApp1.Selenium.Utility;

namespace WinFormsApp1.Selenium
{
	public class SeleniumBot
	{
		private readonly string url = "https://www.linkedin.com";

		private readonly UserProfile user;
		private readonly SearchQuery searchQuery;

		public SeleniumBot(UserProfile user, SearchQuery searchQuery)
		{
			this.user = user;
			this.searchQuery = searchQuery;
		}

		public void Run()
		{
			IWebDriver driver = DriverFactory.GetDriver(url);

			CustomDriver mainDriver = new CustomDriver(driver, user);

			new Login(mainDriver).Run();
			new SearchForJobs(mainDriver, searchQuery).Run();
			new ApplyForJob(mainDriver, 2).Run();
		}
	}
}

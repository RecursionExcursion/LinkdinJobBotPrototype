using OpenQA.Selenium;
using static WinFormsApp1.Selenium.Constants.SearchForJobsByConstants;
using static WinFormsApp1.Selenium.Constants.SearchForJobsByConstants.ByKeys;

namespace WinFormsApp1.Selenium.Constants
{
	public class SearchForJobsByConstants : ByConstant<ByKeys>
	{
		public enum ByKeys
		{
			TitleBar,
			LocationBar,

			JobsButton,
			EasyApplyButton,

			ExperienceFiltersParent,
			ExperienceFiltersButton,

			LocationFiltersParent,
			LocationFiltersButton,

			InElementInput
		}

		protected override Dictionary<ByKeys, By> ByDict()
		{
			return new Dictionary<ByKeys, By>()
			{
				{ TitleBar, By.XPath("//input[starts-with(@id,'jobs-search-box-keyword-id-ember')]")},
				{ LocationBar, By.XPath("//input[starts-with(@id,'jobs-search-box-location-id-ember')]")},

				{ JobsButton, By.XPath("//a[@href='https://www.linkedin.com/jobs/?']")},
				{ EasyApplyButton, By.XPath("//button[@aria-label=\"Easy Apply filter.\"]")},

				{ ExperienceFiltersParent, By.XPath("//div[@id=\"hoverable-outlet-experience-level-filter-value\"]")},
				{ ExperienceFiltersButton, By.XPath("//button[contains(@aria-label,\"Experience level filter.\")]")},

				{ LocationFiltersParent, By.XPath("//div[@id=\"hoverable-outlet-on-site/remote-filter-value\"]")},
				{ LocationFiltersButton, By.XPath("//button[contains(@aria-label,\"On-site/remote filter.\")]")},

				{ InElementInput,By.XPath(".//input")}

			};
		}
	}
}
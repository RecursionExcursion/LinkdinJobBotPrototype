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

			InElementInput,

			AllFiltersButton,


			ExperianceSearchFilterButton,
			WorkplaceTypeSearchFilterButton,
		}

		protected override Dictionary<ByKeys, By> ByDict()
		{
			return new Dictionary<ByKeys, By>()
			{
				{ TitleBar, By.XPath("//input[starts-with(@id,'jobs-search-box-keyword-id-ember')]")},
				{ LocationBar, By.XPath("//input[starts-with(@id,'jobs-search-box-location-id-ember')]")},

				{ JobsButton, By.XPath("//a[@href='https://www.linkedin.com/jobs/?']")},
				{ EasyApplyButton, By.XPath("//button[@aria-label=\"Easy Apply filter.\"]")},

				{ InElementInput,By.XPath(".//input")},

				{ AllFiltersButton, By.XPath("//button[contains(@aria-label, \"Show all filters\")]")},

				{ExperianceSearchFilterButton,By.Id("searchFilter_experience") },
				{WorkplaceTypeSearchFilterButton, By.Id("searchFilter_workplaceType") }

			};
		}
	}
}
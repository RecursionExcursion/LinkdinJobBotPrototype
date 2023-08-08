using OpenQA.Selenium;
using static WinFormsApp1.Selenium.Constants.ApplyByConstants;
using static WinFormsApp1.Selenium.Constants.ApplyByConstants.ByKeys;


namespace WinFormsApp1.Selenium.Constants
{
	public class ApplyByConstants : ByConstant<ByKeys>
	{
		public enum ByKeys
		{
			SearchResultsDiv,
			SearchResutlsElements,

			EasyApplyButton,

			AppForm,
			Resume,
			Question,

			FieldSet,
			Select,
			Input,

			QuestionLabel,
			QuestionSpan,

			ResumeH3,

			ContinueNext,
			ContinueReview,
			ContinueSubmit,

			ReviewFollowLabel,
			ReviewBigDiv,

			PostApplyModal,
			PostApplyDismissButton
		}


		protected override Dictionary<ByKeys, By> ByDict()
		{
			return new Dictionary<ByKeys, By>()
			{
				{SearchResultsDiv,By.XPath("//ul[@class=\"scaffold-layout__list-container\"]") },
				{SearchResutlsElements,By.ClassName("jobs-search-results__list-item") },

				{EasyApplyButton,By.XPath("//span[text()='Easy Apply']//parent::button") },

				{ AppForm, By.XPath("//div[@class=\"ph5\"]//parent::form")},
				{ Resume , By.XPath(".//div[@class=\"mt2\"]")},
				{ Question, By.XPath(".//div[starts-with(@class,\"jobs-easy-apply-form-section__grouping\")]")},

				{ FieldSet, By.XPath(".//fieldset")},
				{ Select, By.XPath(".//select")},
				{ Input, By.XPath(".//input")},

				{ QuestionLabel ,By.XPath(".//label")},
				{ QuestionSpan, By.XPath(".//span")},

				{ ResumeH3, By.XPath(".//h3") },

				{ ContinueNext, By.XPath(".//button[@aria-label=\"Continue to next step\"]")},
				{ ContinueReview, By.XPath(".//button[@aria-label=\"Review your application\"]")},
				{ ContinueSubmit, By.XPath(".//button[@aria-label=\"Submit application\"]")},

				{ReviewFollowLabel, By.XPath("//label[@for=\"follow-company-checkbox\"]")},
				{ReviewBigDiv, By.XPath("//div[@class=\"jobs-easy-apply-content\"]")},

				{ PostApplyModal, By.XPath("//div[@aria-labelledby=\"post-apply-modal\"]") },
				{ PostApplyDismissButton, By.XPath(".//button[@aria-label=\"Dismiss\"]")}
			};
		}
	}
}

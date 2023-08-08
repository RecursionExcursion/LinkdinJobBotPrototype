using OpenQA.Selenium;
using static WinFormsApp1.Selenium.Constants.LoginByConstants;
using static WinFormsApp1.Selenium.Constants.LoginByConstants.ByKeys;

namespace WinFormsApp1.Selenium.Constants
{
	public class LoginByConstants : ByConstant<ByKeys>
	{
		public enum ByKeys
		{
			SessionKey,
			SessionPassword,
			SubmitButton,
			SecurityCheckElements
		}
		protected override Dictionary<ByKeys, By> ByDict()
		{
			return new Dictionary<ByKeys, By>()
			{
				{ SessionKey, By.Id("session_key") },
				{ SessionPassword, By.Id("session_password") },
				{ SubmitButton, By.XPath("//button[@data-tracking-control-name='homepage-basic_sign-in-submit-btn']") },
				{ SecurityCheckElements, By.XPath("//h1")
				}
			};
		}
	}
}
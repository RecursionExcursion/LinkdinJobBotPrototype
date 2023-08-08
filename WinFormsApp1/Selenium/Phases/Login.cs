using OpenQA.Selenium;
using WinFormsApp1.Forms;
using WinFormsApp1.Selenium.Constants;
using static WinFormsApp1.Selenium.Constants.LoginByConstants.ByKeys;
using static WinFormsApp1.Selenium.Constants.LoginByConstants;
using WinFormsApp1.Models;

namespace WinFormsApp1.Selenium.Phases
{
	public class Login : BotPhase<ByKeys>
	{
		private readonly string username;
		private readonly string password;

		public Login(IWebDriver driver, LoginByConstants constants, params object[] parameters) : base(driver, constants, parameters)
		{
			UserProfile user = (UserProfile) parameters[0];
			username = user.Email;
			password = user.Password;
		}

		public override void Run()
		{
			//TODO Sometimes fails to write in the email text box, create fall back
			IWebElement usernameTextBox = elementLocator.FindElement(by[SessionKey]);
			IWebElement passwordTextBox = elementLocator.FindElement(by[SessionPassword]);
			IWebElement submitButton = elementLocator.FindElement(by[SubmitButton]);

			actions.MoveToAndClick(usernameTextBox)
				   .SendKeys(username)
				   .MoveToAndClick(passwordTextBox)
				   .SendKeys(password)
				   .MoveToAndClick(submitButton)
				   .Perform();

			CheckForSecurityCheck();
		}

		private void CheckForSecurityCheck()
		{
			List<IWebElement> elements = elementLocator.FindElements(by[SecurityCheckElements]);
			if (elements.Count != 0)
			{
				string text = elements[0].Text;

				bool isPresent = text.Contains("security check");
				if (isPresent)
				{
					CaptchaByPassForm popUp = new();
					popUp.ShowDialog();
				}
			}
		}
	}
}

using OpenQA.Selenium;
using WinFormsApp1.Forms;
using WinFormsApp1.Models;
using WinFormsApp1.Selenium.Utility;

namespace WinFormsApp1.Selenium.Phases
{
	public class Login : BotPhase
	{
		private readonly string username;
		private readonly string password;

		public Login(CustomDriver driver) : base(driver)
		{
			username = driver.User.Email;
			password = driver.User.Password;
		}

		public override void Run()
		{
			InputLoginCreds();
			CheckForSecurityCheck();
		}

		private void InputLoginCreds()
		{
			//TODO Sometimes fails to write in the email text box, create fall back
			IWebElement usernameTextBox = elementLocator.FindElement(By.Id("session_key"));
			IWebElement passwordTextBox = elementLocator.FindElement(By.Id("session_password"));
			IWebElement submitButton = elementLocator.FindElement(
				By.XPath("//button[@data-tracking-control-name='homepage-basic_sign-in-submit-btn']")
				);

			actions.MoveToAndClick(usernameTextBox)
				   .SendKeys(username)
				   .MoveToAndClick(passwordTextBox)
				   .SendKeys(password)
				   .MoveToAndClick(submitButton)
				   .Perform();
		}

		private void CheckForSecurityCheck()
		{
			List<IWebElement> elements = elementLocator.FindElements(By.XPath("//h1"));
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

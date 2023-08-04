using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Linq;
using System;
using System.Diagnostics;
using WinFormsApp1.Forms;

namespace WinFormsApp1.Selenium
{
    public class Login
    {

        private IWebDriver driver;

        private readonly String username;
        private readonly String password;

        private Login(IWebDriver driver, string username, string password)
        {
            this.driver = driver;
            this.username = username;
            this.password = password;
        }

        public static void Exectute(IWebDriver driver, string username, string password)
        {
            new Login(driver, username, password).RunLogin();
        }

        private void RunLogin()
        {

            //TODO Sometimes fails to write in the email text box, create fall back


            /*
            
            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            //IWebElement usernameTextBox = wait.Until(condition =>
            //driver.FindElement(By.Id("session_key")));
            IWebElement usernameTextBox;
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
                usernameTextBox = wait.Until(condition => {
                    IWebElement e = driver.FindElement(By.Id("session_key"));
                    if (e.Displayed)
                    {
                        return e;
                    }
                    throw new ElementNotVisibleException();

                });
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Error: Element {0} could not be found", "usernameTextBox");
                throw;
            }
            catch (ElementNotVisibleException ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            

            //IWebElement passwordTextBox = driver.FindElement(By.Id("session_password"));


            //string submitButtonXpath = "//button[@data-tracking-control-name='homepage-basic_sign-in-submit-btn']";
            //IWebElement submitButton = driver.FindElement(By.XPath(submitButtonXpath));
            */


            SmartElementLocator elementLocator = new SmartElementLocator(driver);
            IWebElement usernameTextBox = elementLocator.FindElement(By.Id("session_key"));


            IWebElement passwordTextBox = elementLocator.FindElement(By.Id("session_password"));

            string submitButtonXpath = "//button[@data-tracking-control-name='homepage-basic_sign-in-submit-btn']";
            IWebElement submitButton = elementLocator.FindElement(By.XPath(submitButtonXpath));

            ActionsDelegate.BuildActionChain(driver)
                           .MoveToAndClick(usernameTextBox)
                           .SendKeys(username)
                           .MoveToAndClick(passwordTextBox)
                           .SendKeys(password)
                           .MoveToAndClick(submitButton)
                           .Perform();

            CheckForSecurityCheck();
        }

        private void CheckForSecurityCheck()
        {
            SmartElementLocator elementLocator = new SmartElementLocator(driver);
            List<IWebElement> elements = elementLocator.FindElements(By.XPath("//h1"));
            if (elements.Count != 0)
            {
                String text = elements[0].Text;

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

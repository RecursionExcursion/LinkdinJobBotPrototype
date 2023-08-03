using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace WinFormsApp1.Selenium
{
    public class Login
    {

        private IWebDriver driver;

        private String username;
        private String password;

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

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            IWebElement usernameTextBox = wait.Until(condition =>
            driver.FindElement(By.Id("session_key")));
            /*
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
            */

            IWebElement passwordTextBox = driver.FindElement(By.Id("session_password"));
            string submitButtonXpath = "//button[@data-tracking-control-name='homepage-basic_sign-in-submit-btn']";
            IWebElement submitButton = driver.FindElement(By.XPath(submitButtonXpath));


            ActionsDelegate actions = new ActionsDelegate(driver);

            actions.MoveToAndClick(usernameTextBox)
                .SendKeys(username)
                .MoveToAndClick(passwordTextBox)
                .SendKeys(password)
                .MoveToAndClick(submitButton)
                .Perform();
        }
    }
}

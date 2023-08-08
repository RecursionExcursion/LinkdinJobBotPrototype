using OpenQA.Selenium;
using WinFormsApp1.Selenium.Constants;
using WinFormsApp1.Selenium.Utility;

namespace WinFormsApp1.Selenium.Phases
{
    public abstract class BotPhase<TEnum> where TEnum : Enum
	{
        protected readonly IWebDriver driver;
        protected readonly SmartElementLocator elementLocator;
        protected readonly ActionsDelegate actions;
        protected readonly Dictionary<TEnum, By> by;

        protected BotPhase(IWebDriver driver, ByConstant<TEnum> constants, params object[] parameters)
        {
            this.driver = driver;
            by = constants.ByMap;
            elementLocator = new SmartElementLocator(driver);
            actions = new ActionsDelegate(driver);
        }

        public abstract void Run();
    }
}

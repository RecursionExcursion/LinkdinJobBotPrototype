using WinFormsApp1.Selenium.QA;
using WinFormsApp1.Selenium.Utility;

namespace WinFormsApp1.Selenium.Phases
{
	public abstract class BotPhase
	{
		protected readonly CustomDriver driver;
		protected readonly SmartElementLocator elementLocator;
		protected readonly ActionsDelegate actions;
		protected readonly QuestionDelegate questionDelegate;

		protected BotPhase(CustomDriver driver)
		{
			this.driver = driver;
			elementLocator = driver.ElementLocator;
			actions = driver.Actions;
			questionDelegate = driver.QuestionDelegate;
		}

		public abstract void Run();
	}
}

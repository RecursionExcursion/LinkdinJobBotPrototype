using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1.Models;
using WinFormsApp1.Selenium.QA;

namespace WinFormsApp1.Selenium.Utility
{
    public class CustomDriver
	{
		public IWebDriver Driver { get; private set; }

		public ActionsDelegate Actions { get; private set; }

		public SmartElementLocator ElementLocator { get; private set; }

		public QuestionDelegate QuestionDelegate { get;  private set; }

		public UserProfile User { get; private set; }

		public CustomDriver(IWebDriver driver, UserProfile user)
		{
			Driver = driver;
			User = user;
			ElementLocator = new SmartElementLocator(driver);
			Actions = new ActionsDelegate(driver);
			QuestionDelegate = new QuestionDelegate(user);
		}
	}
}

using OpenQA.Selenium;
using static WinFormsApp1.Selenium.ByConstants.DriverFactoryByKeys;

namespace WinFormsApp1.Selenium
{
	public static class ByConstants
	{

		/* */

		public enum DriverFactoryByKeys
		{
			Validation
		}

		public static Dictionary<DriverFactoryByKeys, By> DriverFactoryBy { get; } = new Dictionary<DriverFactoryByKeys, By>()
		{
			{ Validation, By.Id("session_key") }
		};

		/* */

		/* */

		public enum ApplyForJobKeys
		{
		}

		public static Dictionary<ApplyForJobKeys, By> ApplyForJobBy { get; } = new Dictionary<ApplyForJobKeys, By>()
		{
		};
	}


}

using OpenQA.Selenium;

namespace WinFormsApp1.Selenium.Constants
{
	public abstract class ByConstant<TEnum> where TEnum : Enum
	{

		protected Dictionary<TEnum, By> byMap;

		public Dictionary<TEnum, By> ByMap
		{
			get
			{
				if (byMap == null)
				{
					byMap = ByDict();
				}
				return byMap;
			}
		}

		protected abstract Dictionary<TEnum, By> ByDict();
	}
}

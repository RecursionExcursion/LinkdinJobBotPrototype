using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Keys = OpenQA.Selenium.Keys;

namespace WinFormsApp1.Selenium.Utility
{
    public class ActionsDelegate
    {
        private readonly Actions actions;

        public ActionsDelegate(IWebDriver driver)
        {
            actions = new Actions(driver);
        }

        public ActionsDelegate SendKeys(string s)
        {
            foreach (char c in s.ToCharArray())
            {
                actions.SendKeys(c.ToString())
                       .Pause(GetTypingPauseInt());
            }
            actions.Pause(GetMediumPauseInt());
            return this;
        }

        public ActionsDelegate ClearKeys()
        {
            actions.KeyDown(Keys.Control)
                   .Pause(GetTypingPauseInt())
                   .SendKeys("a")
                   .Pause(GetTypingPauseInt())
                   .KeyUp(Keys.Control)
                   .Pause(GetTypingPauseInt())
                   .SendKeys(Keys.Backspace)
                   .Pause(GetTypingPauseInt());
            return this;
        }

        public ActionsDelegate PressEnter()
        {
            //actions.SendKeys("\n");
            actions.SendKeys(Keys.Enter);
            actions.Pause(GetMediumPauseInt());
            return this;
        }

        public ActionsDelegate Click()
        {
            actions.Click()
                   .Pause(GetMediumPauseInt());
            return this;
        }

        public ActionsDelegate MoveToElement(IWebElement element)
        {
            actions.MoveToElement(element, RandomOffset(), RandomOffset())
                   .Pause(GetQuickPauseInt());
            return this;
        }

        public ActionsDelegate MoveToAndClick(IWebElement element)
        {
            MoveToElement(element).Click();
            return this;
        }

        public ActionsDelegate Build()
        {
            actions.Build();
            return this;
        }


        public void Perform() => actions.Perform();


        private static readonly Random RAND = new Random();

        private static TimeSpan GetTypingPauseInt() =>
            TimeSpan.FromMilliseconds(RAND.Next(1, 4) * 100);

        private static TimeSpan GetMediumPauseInt() =>
             TimeSpan.FromMilliseconds(RAND.Next(8, 10) * 100);

        private static TimeSpan GetQuickPauseInt() =>
            TimeSpan.FromMilliseconds(RAND.Next(25, 50) * 10);

        private static int RandomOffset() => RAND.Next(10) - 5;

    }
}

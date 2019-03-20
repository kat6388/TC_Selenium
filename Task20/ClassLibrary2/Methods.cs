using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Drivers
{
    public class Methods
    {
        public static IWebDriver NavigateTo(string url)
        {
            var chromeDriver = new ChromeDriver(@"D:\Automation");
            chromeDriver.Navigate().GoToUrl(url);
            return chromeDriver;
        }

        public static string GetUrl(IWebDriver chromeDriver)
        {
            return chromeDriver.Url;
        }

        public static void PopulateLoginForm(IWebDriver chromeDriver, string username, string password)
        {
            Actions builder = new Actions(chromeDriver);
            chromeDriver.FindElement(By.LinkText("Войти")).Click();
            chromeDriver.FindElement(By.Name("login")).SendKeys(username);
            builder.SendKeys(Keys.Tab).Perform();
            chromeDriver.FindElement(By.Name("password")).SendKeys(password);
        }

        public static bool IsLoginButtonEnabled(IWebDriver chromeDriver)
        {
            return chromeDriver.FindElement(By.ClassName("auth__enter")).Enabled;
        }

        public static void LoginUser(IWebDriver chromeDriver)
        {
            chromeDriver.FindElement(By.ClassName("auth__enter")).Click();
        }

        public static bool IsUserLogin(IWebDriver chromeDriver)
        {
            return chromeDriver.FindElement(By.ClassName("uname")).Displayed;
        }
    }
}

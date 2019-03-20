using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using System;
using OpenQA.Selenium.Firefox;


namespace SeleniumGrid
{
    public class Methods
    {

        public IWebDriver RemoteNavigationChrome(string url)
        {
            ChromeOptions options = new ChromeOptions();
            var driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), options);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
            return driver;
        }

        public IWebDriver NavigateTo(string url)
        {

            var chromeDriver = new ChromeDriver(@"D:\Automation");
            chromeDriver.Navigate().GoToUrl(url);
            return chromeDriver;
        }

        public  void LoginUser(IWebDriver chromeDriver, string username, string password)
        {
            Actions builder = new Actions(chromeDriver);
            chromeDriver.FindElement(By.LinkText("Войти")).Click();
            chromeDriver.FindElement(By.Name("login")).SendKeys(username);
            builder.SendKeys(Keys.Tab).Perform();
            chromeDriver.FindElement(By.Name("password")).SendKeys(password);
            chromeDriver.FindElement(By.ClassName("auth__enter")).Click();
        }

        public  bool IsUserLogin(IWebDriver chromeDriver)
        {
            return chromeDriver.FindElement(By.LinkText("Selenium Test")).Displayed;
        }
    }
}
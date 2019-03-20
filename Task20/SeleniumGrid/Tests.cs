using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;

namespace SeleniumGrid
{
    public class Tests
    {
        public const string url = "https://www.tut.by/";
        public const string username = "seleniumtests@tut.by";
        public const string password = "123456789zxcvbn";

        //[Test]
        
        //public void LoginUserTutBy()
        //{
        //    //Methods methods = new Methods();
        //    //var driver = methods.RemoteNavigation(url);
        //    Methods methods = new Methods();
        //    Firef options = new ChromeOptions();
        //    var driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), options);
        //    driver.Manage().Window.Maximize();            
        //    driver.Navigate().GoToUrl(url);
        //    //methods.LoginUser(driver, username, password);
        //    //methods.IsUserLogin(driver);
        //    //Assert.IsTrue(methods.IsUserLogin(driver));
        //}
        [Test]
        public void Navigate()
        {
            Methods methods = new Methods();
            methods.RemoteNavigationChrome(url);
        }
    }
}

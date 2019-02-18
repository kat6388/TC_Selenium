using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using OpenQA.Selenium.Chrome;

namespace Task70_POM
{
    [TestFixture]
    public class Tests
    {
        public IWebDriver Driver { get; set; }
        public WebDriverWait Wait { get; set; }

        [SetUp]
        public void SetupTest()
        {
            
            Driver = new ChromeDriver(@"D:\Automation");
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));
        }

        [Test]
        public void LoginUserTutBy()
        {
            PageObject tutby = new PageObject(Driver);
            tutby.Navigate();
            string username = "seleniumtests@tut.by";
            string password = "123456789zxcvbn";
            tutby.Login(username, password);

            var loginState = tutby.IsUserLogin();
            Assert.IsTrue(loginState);
        }

        [Test]
        public void LogoutUserTutBy()
        {
            PageObject tutby = new PageObject(Driver);
            tutby.Navigate();
            string username = "seleniumtests@tut.by";
            string password = "123456789zxcvbn";
            tutby.Login(username, password);
            tutby.Logout();

            var logoutState = tutby.IsUserLogout();
            Assert.IsTrue(logoutState);
        }


    }
}

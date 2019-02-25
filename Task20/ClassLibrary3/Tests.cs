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
        public const string username = "seleniumtests@tut.by";
        public const string password = "123456789zxcvbn";

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
            tutby.Login(username, password);
            tutby.TakeScreenshot();
            Assert.IsTrue(tutby.IsUserLogin());
        }

        [Test]
        public void LogoutUserTutBy()
        {
            PageObject tutby = new PageObject(Driver);
            tutby.Navigate();
            tutby.Login(username, password);
            tutby.Logout();
            tutby.TakeScreenshot();

            Assert.IsTrue(tutby.IsUserLogout());
        }
    }
}

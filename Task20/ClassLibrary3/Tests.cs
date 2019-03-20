using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;

using Allure.Commons;
using Allure.NUnit.Attributes;

namespace Task70_POM
{
    [TestFixture]
    public class Tests:AllureReport
    {
        public IWebDriver Driver { get; set; }
        public WebDriverWait Wait { get; set; }
        public const string username = "seleniumtests@tut.by";
        public const string password = "123456789zxcvbn";

        [SetUp]
        public void SetupTest()
        {
            Driver = new ChromeDriver(@"D:\Automation");
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(300));
        }

        [TearDown]
        public void TearDownTest()
        {
            AllureLifecycle.Instance.RunStep(() =>
            {
                TestContext.Error.WriteLine(
                    $"Test {TestExecutionContext.CurrentContext.CurrentTest.FullName}\" is stopping...");
                PageObject tutby = new PageObject(Driver);
                tutby.TakeScreenshot();
            });
        }

        [Test]
        [AllureSubSuite("Login")]
        [AllureSeverity(Allure.Commons.Model.SeverityLevel.Critical)]
        [AllureLink("ID-124")]
        [AllureTest]
        [AllureOwner("Katya Astakhova")]
        public void LoginUserTutBy()
        {
            PageObject tutby = new PageObject(Driver);
            tutby.Navigate();
            tutby.Login(username, password);
            tutby.TakeScreenshot();
            Assert.IsTrue(tutby.IsUserLogin());
        }

        [Test]
        [AllureSubSuite("Login")]
        [AllureSeverity(Allure.Commons.Model.SeverityLevel.Critical)]
        [AllureLink("ID-125")]
        [AllureTest]
        [AllureOwner("Katya Astakhova")]

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

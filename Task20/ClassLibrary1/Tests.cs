using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestFixture]
    public class Tests
    {
        public const string url = "https://www.tut.by/";
        public const string username = "seleniumtests@tut.by";
        public const string password = "123456789zxcvbn";

        [Test]
        public void Login()
        {

            var driver = Drivers.Methods.NavigateTo(url);
            var actualUrl = Drivers.Methods.GetUrl(driver);
            Assert.IsTrue(actualUrl.StartsWith(url), "invalid url)");

            Drivers.Methods.PopulateLoginForm(driver,username,password);

            Assert.IsTrue(Drivers.Methods.IsLoginButtonEnabled(driver));

            Drivers.Methods.LoginUser(driver);

            Assert.IsTrue(Drivers.Methods.IsUserLogin(driver));
        }
    }
}

﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace Task70_POM
{
   public class PageObject
    {
        private readonly IWebDriver driver;
        private readonly string url = @"https://www.tut.by/";

        public PageObject(IWebDriver browser)
        {
            driver = browser;
            driver.Manage().Window.Maximize();
            PageFactory.InitElements(browser, this);
        }

        [FindsBy(How = How.ClassName, Using = "enter")]
        public IWebElement LoginLink { get; set; }

        [FindsBy(How = How.Name, Using = "login")]
        public IWebElement UsernameInput { get; set; }

        [FindsBy(How = How.Name, Using = "password")]
        public IWebElement PasswordInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@value='Войти']")]
        public IWebElement LoginButton { get; set; }

        [FindsBy(How = How.ClassName, Using = "uname")]
        public IWebElement LoggedUser { get; set; }

        [FindsBy(How = How.LinkText, Using = "Выйти")]
        public IWebElement LogoutButton { get; set; }

        public void Navigate()
        {
            driver.Navigate().GoToUrl(this.url);
        }

        public void Login(string username, string password)
        {
            LoginLink.Click();
            UsernameInput.SendKeys(username);
            PasswordInput.SendKeys(password);
            LoginButton.Click();
        }
        public void Logout()
        {
            LoggedUser.Click();
            LogoutButton.Click();
        }
        public bool IsUserLogin()
        {
            return driver.FindElement(By.ClassName("uname")).Displayed;
        }
        public bool IsUserLogout()
        {
            return driver.FindElement(By.LinkText("Войти")).Displayed;
        }
        public void TakeScreenshot ()
        {
            ITakesScreenshot screenshotDriver = driver as ITakesScreenshot;
            Screenshot screenshot = screenshotDriver.GetScreenshot();
            String fp = "D:\\" + "snapshot" + "_" + DateTime.Now.ToString("dd_MMMM_hh_mm_ss_tt") + ".png";
            screenshot.SaveAsFile(fp, ScreenshotImageFormat.Png);
        }
    }
}

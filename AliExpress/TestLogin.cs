using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AliExpress
{
    [TestFixture]
    [Order(1)]
    class TestLogin : ChromeOpen
    {
        public TestLogin()
        {
            browser.Manage().Window.Maximize();
            browser.Url = "https://www.aliexpress.com/";

        }

        [Test]
        [Order(1)]
        public void Login()
        {
            IWebElement signIn = browser.FindElement(By.LinkText("Sign in"));
            signIn.Click();
            Thread.Sleep(2000);
            browser.SwitchTo().Frame("alibaba-login-box");
            
            IWebElement enterEmail = browser.FindElement(By.Id("fm-login-id"));
            enterEmail.SendKeys(data.Email);
            
            IWebElement enterPass = browser.FindElement(By.Id("fm-login-password"));
            enterPass.SendKeys(data.Password);
            IWebElement Submit = browser.FindElement(By.Id("fm-login-submit"));
            Submit.Click();

            Assert.Pass("User logged in");
        }
    }
}

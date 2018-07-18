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
    [Order(2)]
    class Search : ChromeOpen
    {
        public string productName = "Hindfield Designer Sunglasses Women Lunette De Soleil";
        //sa ovim je lako BINYEAE blue mirror sunglases women cat eye UV400
        //Hindfield Designer Sunglasses Women Lunette De Soleil

        [Test]
        [Order(2)]
        public void SearchProduct()
        {
            Thread.Sleep(4000);
            IWebElement searchTextBox = browser.FindElement(By.Id("search-key"));
            searchTextBox.SendKeys(productName);
            IWebElement searchButton = browser.FindElement(By.CssSelector("input.search-button"));
            searchButton.Click();


            IWebElement result = browser.FindElement(By.Id("hs-below-list-items"));
            //niz
            IWebElement[] resultArray = result.FindElements(By.TagName("li")).ToArray();

            for (int i = 0; i < resultArray.Count(); i++)
            {
                IWebElement naslov = resultArray[i].FindElement(By.CssSelector("div div:nth-child(2) h3 a"));

                if (productName.Contains(naslov.Text))
                {
                    naslov.Click();
                    Assert.Pass("Search works");
                    break;
                }
                else
                {
                    Assert.Fail("Search does not work");
                }
            }
        }

        [Test]
        [Order(3)]
        public void EnterProduct()
        {
            Thread.Sleep(4000);
            browser.SwitchTo().Window(browser.WindowHandles.Last());
            IWebElement Color = browser.FindElement(By.Id("sku-1-10"));
            Color.Click();
            /*IWebElement Quantity = browser.FindElement(By.Id("j-p-quantity-input"));
            Quantity.Clear();
            Quantity.SendKeys("5");*/
            IWebElement AddToCart = browser.FindElement(By.Id("j-add-cart-btn"));
            AddToCart.Click();
            Thread.Sleep(2000);
            IWebElement ViewCart = browser.FindElement(By.LinkText("View Shopping Cart"));
            ViewCart.Click();

            Assert.Pass("You have successfully purchased the product");
            


        }
    }
}

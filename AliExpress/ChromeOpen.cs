using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliExpress
{
    class ChromeOpen
    {
        public static IWebDriver browser = new ChromeDriver();
        public Data data;
        public ChromeOpen()
        {

            this.data = new Data();
        }
    }
}

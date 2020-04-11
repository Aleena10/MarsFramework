using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsFramework.Global
{
   public static class Methods
    {

        [Obsolete]

        public static void EnterText(this IWebElement element, string value)
        {
            GlobalDefinitions.Wait(20);
            element.SendKeys(value);
        }

        public static void Clicks(this IWebElement element)
        {
            GlobalDefinitions.Wait(20);
            element.Click();
        }

        public static void SelectFromDDL(this IWebElement element, string value)
        {
            GlobalDefinitions.Wait(20);
            new SelectElement(element).SelectByText(value);
        }





    }
}

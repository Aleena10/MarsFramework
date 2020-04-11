using MarsFramework.Config;
using MarsFramework.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Threading;

namespace MarsFramework.Pages
{
    internal class ManageListings
    {

        private string alertkey;

        [Obsolete]
        public ManageListings()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        //Click on Manage Listings Link
        [FindsBy(How = How.LinkText, Using = "Manage Listings")]
        private IWebElement manageListingsLink { get; set; }

        //View the listing
        [FindsBy(How = How.XPath, Using = "(//i[@class='eye icon'])[1]")]
        private IWebElement view { get; set; }

        //Delete the listing
        [FindsBy(How = How.XPath, Using = "//table[1]/tbody[1]")]
        private IWebElement delete { get; set; }

        //Edit the listing
        [FindsBy(How = How.XPath, Using = "(//i[@class='outline write icon'])[1]")]
        private IWebElement edit { get; set; }

        //Click on Yes or No
        [FindsBy(How = How.XPath, Using = "//div[@class='actions']")]
        private IWebElement clickActionsButton { get; set; }
        internal void Listings()
        {
            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(MarsResource.ExcelPath, "ManageListings");


        }
        [System.Obsolete]
        internal void EditManageListings()
        {
            manageListingsLink.Click();
            Thread.Sleep(3000);
            GlobalDefinitions.driver.FindElement(By.XPath("(//button[contains(@role,'button')])[2]")).Click();
            Thread.Sleep(3000);
            GlobalDefinitions.driver.FindElement(By.XPath("(//i[contains(@class,'outline write icon')])[1]")).Click();

            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ShareSkill");


            //Read data from excel
            string Title = GlobalDefinitions.ExcelLib.ReadData(2, "Title");
            string desc = GlobalDefinitions.ExcelLib.ReadData(2, "Description");
            string cat = GlobalDefinitions.ExcelLib.ReadData(2, "Category");
            string subCat = GlobalDefinitions.ExcelLib.ReadData(2, "SubCategory");
            string tag = GlobalDefinitions.ExcelLib.ReadData(2, "Tags");
            string location = GlobalDefinitions.ExcelLib.ReadData(2, "LocationType");
            string ServiceType = GlobalDefinitions.ExcelLib.ReadData(2, "ServiceType");
            //string SDate = GlobalDefinitions.ExcelLib.ReadData(2, "Startdate");
            //string Edate = GlobalDefinitions.ExcelLib.ReadData(2, "Enddate");
            //string StartTime = GlobalDefinitions.ExcelLib.ReadData(2, "Starttime");
            //string EndTime = GlobalDefinitions.ExcelLib.ReadData(2, "Endtime");
            string Skilltrade = GlobalDefinitions.ExcelLib.ReadData(2, "SkillTrade");
            string SkillExchange = GlobalDefinitions.ExcelLib.ReadData(2, "Skill-Exchange");
            string Credit = GlobalDefinitions.ExcelLib.ReadData(2, "Credit");
            string Active = GlobalDefinitions.ExcelLib.ReadData(2, "Active");

            ShareSkill es = new ShareSkill();
            es.EditShareSkill(Title, desc, cat, subCat, tag, ServiceType, location,
                //SDate,Edate,StartTime,EndTime,
                Skilltrade, SkillExchange, Credit, Active);
        }


        internal void DeleteShareSkill(string alertkey = "Yes")
        {
            manageListingsLink.Clicks();
            Thread.Sleep(3000);

            GlobalDefinitions.driver.FindElement(By.XPath("(//button[contains(@role,'button')])[3]")).Clicks();
            Thread.Sleep(3000);
            GlobalDefinitions.driver.FindElement(By.XPath("(//i[contains(@class,'remove icon')])[4]")).Clicks();
            Thread.Sleep(3000);
            int del = 0;
            //delete.Clicks();
            if (alertkey == "Yes")
            {
                IWebElement delete = GlobalDefinitions.driver.FindElement(By.XPath("//button[contains(.,'Yes')]"));
                delete.Clicks();
                del = 1;

            }
            else if (alertkey == "No")
            {
                GlobalDefinitions.driver.FindElement(By.XPath("//button[contains(.,'No')]")).Clicks();
                del = 1;

            }
            Thread.Sleep(1000);
            Assert.That(del == 1, "Test failed");
        }

    }

}








    
    
    
    
    
    











    
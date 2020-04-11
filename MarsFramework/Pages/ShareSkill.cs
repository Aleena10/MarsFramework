using MarsFramework.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace MarsFramework.Pages
{
    internal class ShareSkill
    {


        [System.Obsolete]
        public ShareSkill()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }


        #region  Initialize Web Elements 
        //Click on ShareSkill Button
        [FindsBy(How = How.LinkText, Using = "Share Skill")]
        private IWebElement ShareSkillButton { get; set; }

        //Enter the Title in textbox
        [FindsBy(How = How.Name, Using = "title")]
        private IWebElement Title { get; set; }

        //Enter the Description in textbox
        [FindsBy(How = How.Name, Using = "description")]
        private IWebElement Description { get; set; }

        //Click on Category Dropdown
        [FindsBy(How = How.Name, Using = "categoryId")]
        private IWebElement CategoryDropDown { get; set; }

        //Click on SubCategory Dropdown
        [FindsBy(How = How.Name, Using = "subcategoryId")]
        private IWebElement SubCategoryDropDown { get; set; }

        //Enter Tag names in textbox
        [FindsBy(How = How.XPath, Using = "//body/div/div/div[@id='service-listing-section']/div[contains(@class,'ui container')]/div[contains(@class,'listing')]/form[contains(@class,'ui form')]/div[contains(@class,'tooltip-target ui grid')]/div[contains(@class,'twelve wide column')]/div[contains(@class,'')]/div[contains(@class,'ReactTags__tags')]/div[contains(@class,'ReactTags__selected')]/div[contains(@class,'ReactTags__tagInput')]/input[1]")]
        private IWebElement Tags { get; set; }

        //Select the Service type
        [FindsBy(How = How.XPath, Using = "//form/div[5]/div[@class='twelve wide column']/div/div[@class='field']")]
        private IWebElement ServiceTypeOptions { get; set; }

        //Select the Location Type
        [FindsBy(How = How.XPath, Using = "//form/div[6]/div[@class='twelve wide column']/div/div[@class = 'field']")]
        private IWebElement LocationTypeOption { get; set; }

        //Fill Start Date
        private IWebElement StartDate => GlobalDefinitions.driver.FindElement(By.XPath(".//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[1]/div[2]/input"));

        //Fill End Date
        private IWebElement EndDate => GlobalDefinitions.driver.FindElement(By.XPath(".//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[1]/div[4]/input"));

        //Click on the available day Check Box
        private IWebElement Day => GlobalDefinitions.driver.FindElement(By.XPath(".//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[3]/div[1]/div/input"));

        //Fill the Starting time
        private IWebElement StartTime => GlobalDefinitions.driver.FindElement(By.XPath(".//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[3]/div[2]/input"));

        //Fill the Ending time
        private IWebElement EndTime => GlobalDefinitions.driver.FindElement(By.XPath(".//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[3]/div[3]/input"));

        //Skill Trade Option
        private IWebElement SkillTrade => GlobalDefinitions.driver.FindElement(By.XPath(".//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[2]/div/div[2]/div/input"));

        //Add Credit Amount
        private IWebElement AddCredit => GlobalDefinitions.driver.FindElement(By.XPath("//input[contains(@placeholder,'Amount')]"));

        //Select Active Status
        private IWebElement ActiveStatus => GlobalDefinitions.driver.FindElement(By.XPath(".//*[@id='service-listing-section']/div[2]/div/form/div[10]/div[2]/div/div[1]/div/input"));

        //Save Button
        private IWebElement SaveButton1 => GlobalDefinitions.driver.FindElement(By.XPath(".//*[@id='service-listing-section']/div[2]/div/form/div[11]/div/input"));

        //Locate table for AddedSkill
        private IWebElement tableElement => GlobalDefinitions.driver.FindElement(By.XPath(".//*[@id='listing-management-section']/div[2]/div[1]/table/tbody/tr[1]/td[3]"));
        #endregion



        [Obsolete]
        internal void EnterShareSkill()
        {
            //Extension custom method
            //Click on Share skill tab
            ShareSkillButton.Clicks();
            Title.EnterText("Selenium");

            Description.EnterText("Would you like to provide Selenium training?");

            //Select dropbox
            CategoryDropDown.SelectFromDDL("Programming & Tech");
            SubCategoryDropDown.SelectFromDDL("Databases");

            //Enter value in tag
            Tags.EnterText("Testing");
            //Enter Key
            Tags.SendKeys(Keys.Enter);
            Thread.Sleep(1000);

            //Select  Service Type
            ServiceTypeOptions.Click();

            //Select Location Type
            LocationTypeOption.Click();
            Thread.Sleep(1000);

            //Enter Skill Trade
            SkillTrade.Click();
            Thread.Sleep(1000);
            // GlobalDefinitions.driver.FindElement(By.XPath("//input[@name='skillTrades'][@tabindex='0'][@value='false']")).Clicks();

            //hidden credit
            AddCredit.Click();
            AddCredit.SendKeys(("10"));

            ActiveStatus.Click();
            Thread.Sleep(1000);


            //Save Button
            SaveButton1.Clicks();
        }

        [Obsolete]
        internal void EditShareSkill(string title, string desc, string cat, string subCat, string tag, string serviceType,
            string locType,
            //string Sdate, string Edate, 
            //string StartTime, string EndTime, 
            string Skilltrade,
            string SkillExchangeTag, string credit, string active)
        {
            Title.EnterText(title);

            Description.EnterText(desc);

            //Select dropbox
            CategoryDropDown.SelectFromDDL(cat);
            SubCategoryDropDown.SelectFromDDL(subCat);

            //Enter value in tag 
            Tags.EnterText(tag);
            //Enter Key
            Tags.SendKeys(Keys.Enter);

            //check Tag entered
            Assert.IsNotNull(Tags, "Test fail- Tag Empty");

            //Enter Service Type
            if (serviceType == "Hourly basis service")
            {
                GlobalDefinitions.driver.FindElement(By.XPath("//label[contains(.,'Hourly basis service')]")).Clicks();
            }
            else if (serviceType == "One-off service")
            {
                GlobalDefinitions.driver.FindElement(By.XPath("//input[@name='serviceType'][@type='radio'][@value='1']")).Clicks();
            }

            //Enter Location Type
            if (locType == "On-site")
            {

                GlobalDefinitions.driver.FindElement(By.XPath("//input[@name='locationType'][@value='0']")).Clicks();
            }
            else if (locType == "Online")
            {
                GlobalDefinitions.driver.FindElement(By.XPath("(//input[contains(@name,'locationType')])[1]")).Clicks();

            }
            //Enter Skill Trade
            if (Skilltrade == "Skill-Exchange")
            {

                GlobalDefinitions.driver.FindElement(By.XPath("//label[contains(.,'Skill-exchange')]")).Clicks();
            }
            else if (Skilltrade == "Credit")
            {
                GlobalDefinitions.driver.FindElement(By.XPath("//label[contains(.,'Credit')]")).Clicks();
            }

            //Click Hiddden Bullet
            if (active == "Active")
                GlobalDefinitions.driver.FindElement(By.XPath("//input[@name='isActive'][@value='false']")).Clicks();
            else
                GlobalDefinitions.driver.FindElement(By.XPath("(//input[contains(@name,'isActive')])[2]")).Clicks();

            //Save Button
            SaveButton1.Clicks();




        }







    }
    









}


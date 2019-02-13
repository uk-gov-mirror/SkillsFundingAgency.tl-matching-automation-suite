﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SFA.Tl.Matching.Automation.Tests.Project.Framework.Helpers;
using SFA.Tl.Matching.Automation.Tests.Project.Tests.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.Tl.Matching.Automation.Tests.Project.Tests.Pages
{
    public class WhoIsTheEmployerPage : BasePage
    {
        private static String PAGE_TITLE = "Who is the employer?";

        public WhoIsTheEmployerPage(IWebDriver webDriver) : base(webDriver)
        {
            SelfVerify();
        }

        protected override bool SelfVerify()
        {
            return PageInteractionHelper.VerifyPageHeading(this.GetPageHeading(), PAGE_TITLE);
        }

        
        private By BusinessNameField = By.Name("CompanyName");
        private By ContinueButton = By.Id("continue");
        private By EnterEmployerError = By.XPath("//*[@id='main-content']/div/div/div/div/ul/li/a");
        private String _expectedEnterEmployerError = "You must find and choose an employer";



        public void ClickContinue()
        {
            FormCompletionHelper.ClickElement(ContinueButton);
        }

        public void ClearBusinessField()
        {
            FormCompletionHelper.ClearText(BusinessNameField);
        }

        public void VerifyNullEmployerError(string ExpectedErrorMessage)
        {
            FormCompletionHelper.VerifyText(EnterEmployerError, _expectedEnterEmployerError);
        }

        public void AutoPopulateEmployer()
        {
            FormCompletionHelper.EnterText(BusinessNameField, "Abacus Childrens Nurseries");
            Thread.Sleep(2000);
            FormCompletionHelper.PressTabKey(BusinessNameField);
           
        }

        public void EnterEmployer(String employerName)
        {
            FormCompletionHelper.EnterText(BusinessNameField, employerName);
            Thread.Sleep(2000);
            FormCompletionHelper.PressTabKey(BusinessNameField);
            ScenarioContext.Current["_provisionGapEmployerName"] = employerName;
        }

       

    }
}

﻿using Day3_Homework.Tests.PageObjects;
using FluentAutomation;
using System;
using TechTalk.SpecFlow;

namespace Day3_Homework.Tests.Features
{
    [Binding]
    [Scope(Feature = "Login")]
    public class LoginSteps : FluentTest
    {
        private LoginPage _loginPage;
        private WelcomePage _welcomePage;

        [BeforeScenario]
        public void BeforeScenario()
        {
            this._loginPage = new LoginPage(this);
        }

        public LoginSteps()
        {
            SeleniumWebDriver.Bootstrap(SeleniumWebDriver.Browser.Firefox);
        }


        [Given(@"I go to Login Page")]
        public void GivenIGoToLoginPage()
        {
            this._loginPage.Go();
        }
        
        [Given(@"I Enter my account ""(.*)""")]
        public void GivenIEnterMyAccount(string account)
        {
            this._loginPage.Account(account);
        }
        
        [Given(@"I Enter my password ""(.*)""")]
        public void GivenIEnterMyPassword(int password)
        {
            this._loginPage.Password(password);
        }
        
        [When(@"I Login")]
        public void WhenILogin()
        {
            this._loginPage.Login();
        }
        
        [Then(@"it should be redirect to Welcome Page")]
        public void ThenItShouldBeRedirectToWelcomePage()
        {
            this._welcomePage = new WelcomePage(this);
            this._welcomePage.CheckAt();
        }
        
        [Then(@"it should be displayed ""(.*)"" on the screen")]
        public void ThenItShouldBeDisplayedOnTheScreen(string welcomeMessage)
        {
            this._welcomePage.WelcomeMessage(welcomeMessage);
        }

        [Then(@"it should show error message ""(.*)"" on the screen")]
        public void ThenItShouldShowErrorMessageOnTheScreen(string errorMessage)
        {
            this._loginPage.ShowMessage(errorMessage);
        }

    }
}

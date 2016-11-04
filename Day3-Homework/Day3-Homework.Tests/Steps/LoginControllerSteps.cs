using Day3_Homework.Controllers;
using Day3_Homework.Controllers.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Web.Mvc;
using TechTalk.SpecFlow;

namespace Day3_Homework.Tests.Steps
{
    [Binding]
    [Scope(Feature = "LoginController")]
    public class LoginControllerSteps
    {
        private LoginController _target;

        [BeforeScenario]
        public void BeforeScenario()
        {
            this._target = new LoginController();
        }

        [Given(@"login account is ""(.*)""")]
        public void GivenLoginAccountIs(string account)
        {
            ScenarioContext.Current.Set<string>(account, "account");
        }
        
        [Given(@"user's password is ""(.*)""")]
        public void GivenUserSPasswordIs(string password)
        {
            ScenarioContext.Current.Set<string>(password, "password");
        }

        [Given(@"AuthService is stub")]
        public void GivenAuthServiceIsStub()
        {
            var stubAuth = Substitute.For<IAuth>();
            this._target.AuthService = stubAuth;
        }

        [Given(@"AuthService\.Validate return isValid is (.*)")]
        public void GivenAuthService_ValidateReturnIsValidIs(bool isValid)
        {
            this._target.AuthService.Validate("", "").ReturnsForAnyArgs(isValid);
        }

        [When(@"I invoke Index with HttpPost")]
        public void WhenIInvokeIndexWithHttpPost()
        {
            var account = ScenarioContext.Current.Get<string>("account");
            var password = ScenarioContext.Current.Get<string>("password");

            var actual = this._target.Index(account, password);

            ScenarioContext.Current.Set<ActionResult>(actual);
        }
        
        [Then(@"result's Controller name should be ""(.*)""")]
        public void ThenResultSControllerNameShouldBe(string controllerName)
        {
            var actual = ScenarioContext.Current.Get<ActionResult>() as RedirectToRouteResult;

            Assert.IsNotNull(actual);
            Assert.AreEqual(controllerName, actual.RouteValues["Controller"]);
        }
        
        [Then(@"result's Action name should be ""(.*)""")]
        public void ThenResultSActionNameShouldBe(string actionName)
        {
            var actual = ScenarioContext.Current.Get<ActionResult>() as RedirectToRouteResult;

            Assert.IsNotNull(actual);
            Assert.AreEqual(actionName, actual.RouteValues["Action"]);
        }

        [Then(@"result's ViewBag Message should be ""(.*)""")]
        public void ThenResultSViewBagMessageShouldBe(string errorMessage)
        {
            var actual = ScenarioContext.Current.Get<ActionResult>() as ViewResult;

            Assert.IsNotNull(actual);
            Assert.AreEqual(errorMessage, actual.ViewBag.Message);
        }
    }
}

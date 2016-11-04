using Day3_Homework.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using TechTalk.SpecFlow;

namespace Day3_Homework.Tests.Steps
{
    [Binding]
    [Scope(Feature = "AuthService")]
    public class AuthServiceSteps
    {
        private AuthService _target;

        [BeforeScenario]
        public void BeforeScenario()
        {
            this._target = new AuthService();
        }

        [Given(@"id is (.*)")]
        public void GivenIdIs(string id)
        {
            ScenarioContext.Current.Set<string>(id, "id");
        }
        
        [Given(@"password is (.*)")]
        public void GivenPasswordIs(string password)
        {
            ScenarioContext.Current.Set<string>(password, "password");
        }

        [Given(@"ProfileDao is stub")]
        public void GivenProfileDaoIsStub()
        {
            var profileDao = Substitute.For<IProfileDao>();
            this._target.ProfileDao = profileDao;
        }

        [Given(@"ProfileDao's GetPassword will return (.*)")]
        public void GivenProfileDaoSGetPasswordWillReturn(string passwordFromDao)
        {
            var id = ScenarioContext.Current.Get<string>("id");
            this._target.ProfileDao.GetPassword(id).Returns(passwordFromDao);
        }

        [Given(@"Hash is stub")]
        public void GivenHashIsStub()
        {
            var hash = Substitute.For<IHash>();
            this._target.Hash = hash;
        }

        [Given(@"Hash's GetHash will return (.*)")]
        public void GivenHashSGetHashWillReturn(string hashResult)
        {
            var password = ScenarioContext.Current.Get<string>("password");
            this._target.Hash.GetHash(password).Returns(hashResult);
        }


        [When(@"I invoke Validate")]
        public void WhenIInvokeValidate()
        {
            var id = ScenarioContext.Current.Get<string>("id");
            var password = ScenarioContext.Current.Get<string>("password");

            bool actual = this._target.Validate(id, password);

            ScenarioContext.Current.Set<bool>(actual, "result");
        }
        
        [Then(@"the result should be (.*)")]
        public void ThenTheResultShouldBe(bool expectedResult)
        {
            var actual = ScenarioContext.Current.Get<bool>("result");
            Assert.AreEqual(expectedResult, actual);
        }
    }
}

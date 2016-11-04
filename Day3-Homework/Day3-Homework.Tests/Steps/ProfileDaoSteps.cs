using Day3_Homework.Models;
using Day3_Homework.Tests.ModelInTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Day3_Homework.Tests.Steps
{
    [Binding]
    [Scope(Feature = "ProfileDao")]
    public class ProfileDaoSteps
    {
        private ProfileDao target;
        private TestRickyDB dbContext;

        [BeforeScenario]
        public void BeforeScenario()
        {
            this.target = new ProfileDao();
            using (dbContext = new TestRickyDB())
            {
                dbContext.Database.ExecuteSqlCommand("Delete Users Where UserName = 'TestUser'");
            }
        }

        [AfterScenario]
        public void AfterScenario()
        {
            using (dbContext = new TestRickyDB())
            {
                dbContext.Database.ExecuteSqlCommand("Delete Users Where UserName = 'TestUser'");
            }
        }

        [Given(@"使用者帳是 ""(.*)""")]
        public void Given使用者帳是(string account)
        {
            ScenarioContext.Current.Set<string>(account);
        }

        [Given(@"預計Users資料應有")]
        public void Given預計Users資料應有(Table table)
        {
            var user = table.CreateInstance<Day3_Homework.Tests.ModelInTest.Users>();
            user.CreatedDate = DateTime.Now;

            using (dbContext = new TestRickyDB())
            {
                dbContext.Users.Add(user);
                dbContext.SaveChanges();
            }
        }

        [When(@"呼叫GetPassword方法")]
        public void When呼叫GetPassword方法()
        {
            var account = ScenarioContext.Current.Get<string>();

            var actual = this.target.GetPassword(account);
            ScenarioContext.Current.Set<string>(actual, "result");
        }

        [Then(@"查詢結果應為 ""(.*)""")]
        public void Then查詢結果應為(string password)
        {
            var actual = ScenarioContext.Current.Get<string>("result");
            Assert.AreEqual(password, actual);
        }
    }
}

using System;
using FluentAutomation;
using Day3_Homework.Tests.Util;

namespace Day3_Homework.Tests.PageObjects
{
    internal class WelcomePage : PageObject<WelcomePage>
    {
        private const string welcomeMessageContainer = "#message";

        public WelcomePage(FluentTest test)
            : base(test)
        {
            Url = string.Format("{0}/{1}", MyTestContext.Domain, "Welcome");
        }

        internal void CheckAt()
        {
            I.Assert.Url(this.Url);
        }

        internal void WelcomeMessage(string welcomeMessage)
        {
            I.Assert.Text(welcomeMessage).In(welcomeMessageContainer);
        }
    }
}
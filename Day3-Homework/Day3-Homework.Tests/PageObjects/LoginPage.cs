using FluentAutomation;
using Day3_Homework.Tests.Util;

namespace Day3_Homework.Tests.PageObjects
{
    internal class LoginPage : PageObject<LoginPage>
    {
        private const string AccountContainer = "#account";
        private const string PasswordContainer = "#password";

        public LoginPage(FluentTest test)
            : base(test)
        {
            Url = string.Format("{0}/{1}", MyTestContext.Domain, "Login");
        }

        internal void Account(string account)
        {
            I.Enter(account).In(AccountContainer);
        }

        internal void Password(int password)
        {
            I.Enter(password).In(PasswordContainer);
        }

        internal void Login()
        {
            I.Press("{ENTER}");
        }
    }
}
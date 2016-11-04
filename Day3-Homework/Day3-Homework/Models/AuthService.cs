using System;
using Day3_Homework.Controllers.Models;

namespace Day3_Homework.Models
{
    public class AuthService : IAuth
    {
        public bool Validate(string account, string password)
        {
            return (account == "rickyho" && password == "1234");
            throw new NotImplementedException();
        }
    }
}
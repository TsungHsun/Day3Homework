namespace Day3_Homework.Controllers.Models
{
    public interface IAuth
    {
        bool Validate(string account, string password);
    }
}
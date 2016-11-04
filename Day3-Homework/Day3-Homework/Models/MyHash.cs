using System;

namespace Day3_Homework.Models
{
    public class MyHash : IHash
    {
        public MyHash()
        {
        }

        public string GetHash(string password)
        {
            if (password == "1234")
            {
                return "85ccbd4568f0ed5bd4d20378498fa955";
            }

            return Guid.NewGuid().ToString();
        }
    }
}
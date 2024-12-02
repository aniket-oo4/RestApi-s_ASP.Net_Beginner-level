using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BusinessLayer
{
    class Validator
    {

        public bool ValidateName(string name)
        {
            if (name.Length < 0 || name.Length > 8)
                return false;
            return true;
        }

        public bool validateAge(int age)
        {
            if (age < 18 || age > 59)
                return false;
            return true;
        }
        public bool validateEmail(string email)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            if (match.Success)
                return true;
            else
                return false;
        }


    }
}

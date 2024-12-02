using CountryDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryDLL
{
    class Validator
    {
        public bool validateCountryName(CountryDTO country)
        {
            if (country.Name.Length > 8 || country.Name.Length <= 0)
                return false;
           
           return true;
        }

    }
}

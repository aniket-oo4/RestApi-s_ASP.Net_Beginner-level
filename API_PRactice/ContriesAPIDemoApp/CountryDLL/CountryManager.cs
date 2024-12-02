using CountryDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryDLL
{
     public class CountryManager
    {

        private CountryDataAccess.CountryRepository countryRepo;
        ResultDTO result = new ResultDTO();
        public CountryManager(string connectionString)
        {
            countryRepo = new CountryDataAccess.CountryRepository(connectionString);
        }


        public Object GetAllCountries()
        {
            IEnumerable<CountryDTO> countries = countryRepo.GetAllCountries();

            if (countries == null)
            {
                result.ResultMesssage = "DataBase does not contain any Data about countries";
                result.ResultCode = 000;
                result.ResultStatus = "unsuccessfull";
                return  result;
            }
            
            return countries;


        }

        public void GetCountry(int id)
        {
            CountryDTO country = countryRepo.GetCountry(id);
            if (country == null)
            {

            }

        }


        private Validator validator = new Validator();
        public ResultDTO addNewCountry(CountryDTO country)
        {
            
            if (validator.validateCountryName(country))
            {
                countryRepo.CreateCountry(country);
                result.ResultCode = 555;
                result.ResultStatus = "successfull";
                result.ResultMesssage = "Country added Successfully";

            }
            else
            {
                result.ResultCode = 555;
                result.ResultStatus = "unsuccessfull";
                result.ResultMesssage = " Name must be smaller than 8 chars and greater than 0chars ";
            }
            return result;
        }


        
    }
}

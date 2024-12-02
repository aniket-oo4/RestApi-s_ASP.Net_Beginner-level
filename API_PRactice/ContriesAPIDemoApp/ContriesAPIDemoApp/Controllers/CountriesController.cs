using CountryDataAccess;
using CountryDLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace ContriesAPIDemoApp.Controllers
{
   
    public class CountriesController : ApiController
    {
        //
        // GET: /Countries/


        //private readonly string _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
        CountryRepository countryRepo = new CountryRepository(System.Configuration.ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
      public  CountryManager manager = new CountryManager(System.Configuration.ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
        // GET countries/allcountries
        //[Route("allCountries")]
        public IEnumerable<CountryDTO> Get()
        {
            return countryRepo.GetAllCountries();
        }


        // GET countries/id
        //[Route("getCountry/{id}")]
        public CountryDTO Get(int id)
        {
            return countryRepo.GetCountry(id);  // calling method
        }

        // POST countries/
         //[Route("create")]
        //public HttpResponseMessage Post([FromBody]CountryDTO country)
        public ResultDTO Post([FromBody]CountryDTO country)
        {
            //Ok(countryRepo.CreateCountry(country));
           // return Request.CreateResponse(HttpStatusCode.OK, countryRepo.CreateCountry(country) > 0 ? "Created" : "Not Created");
            ResultDTO result= manager.addNewCountry(country);
            return result;

        }

        // PUT countries/update/id
        public HttpResponseMessage Put(int id, [FromBody] CountryDTO country)
        {
            //Ok(countryRepo.UpdateCountry(id: id, country: country));
            return Request.CreateResponse(HttpStatusCode.OK, countryRepo.UpdateCountry(id, country) > 0 ? "Updated" : "Not Updated");
        }

          // DELETE countries/Delete/id
                //[Route("delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            //Ok( countryRepo.DeleteCountry(id));
            return Request.CreateResponse(HttpStatusCode.OK, countryRepo.DeleteCountry(id) == true ? "Deleted Successfuly" : "Not Deleted");
        }

    }
}

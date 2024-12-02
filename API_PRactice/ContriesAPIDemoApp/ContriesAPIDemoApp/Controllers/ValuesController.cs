using CountryDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ContriesAPIDemoApp.Controllers
{


    public class ValuesController : ApiController
    {


        //private readonly string _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
        CountryRepository countryRepo = new CountryRepository(System.Configuration.ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
        // GET api/values 
        //[Route("GetAll")]
        public IEnumerable<CountryDTO> Get()        
        {            
            return countryRepo.GetAllCountries();
        }


        // GET api/values/5
        
        public CountryDTO Get(int id)
        {            
            return countryRepo.GetCountry(id);  // calling method
        }

        // POST api/values
        public HttpResponseMessage Post([FromBody]CountryDTO country)
        { 
            //Ok(countryRepo.CreateCountry(country));
            return Request.CreateResponse(HttpStatusCode.OK, countryRepo.CreateCountry( country) > 0 ? "Created" : "Not Created");


        }

        // PUT api/values/5
        public HttpResponseMessage Put(int id, [FromBody] CountryDTO country)
        {
           //Ok(countryRepo.UpdateCountry(id: id, country: country));
            return Request.CreateResponse(HttpStatusCode.OK, countryRepo.UpdateCountry(id, country) > 0 ? "Updated" : "Not Updated");
        }

        // DELETE api/values/5
        public HttpResponseMessage Delete(int id)
        {
           //Ok( countryRepo.DeleteCountry(id));
            return Request.CreateResponse(HttpStatusCode.OK, countryRepo.DeleteCountry(id) == true ? "Deleted Successfuly" : "Not Deleted");
        }
    }
}
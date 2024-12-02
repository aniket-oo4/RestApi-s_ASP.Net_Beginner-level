using Cities.core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Cities.core;
namespace CityApi.Controllers
{
    public class CityController : ApiController
    {
        public ActionResult<List<City>> Get()
        {
            CityManager manager = new CityManager();
            
            return  manager.GetAllCities();
         
            //return "get method called ";
        }


        public ActionResult<City> Get(int id)
        {
            CityManager manager = new CityManager();
            City city = new City();

            return  manager.GetCityBYID(id);
           
        }

        public ActionResult<City> Post([FromBody]City city)
        {
            CityManager manager = new CityManager();

            return manager.Add(city);

        }

        public ActionResult<City> Put([FromBody]City city)
        {
            CityManager manager = new CityManager();

            return manager.Update(city);
        }
    }
}

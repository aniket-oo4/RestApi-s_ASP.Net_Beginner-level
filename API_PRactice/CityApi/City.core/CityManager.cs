using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cities.Data;
using System.Data.SqlClient;

namespace Cities.core
{
    public class CityManager
    {
        public ActionResult<List<City>> GetAllCities()
        {
            List<City> cities = new List<City>();
            CityDataManager datamanager = new CityDataManager();
            List<CityModel> cityModels=  datamanager.GetAllCities();



            foreach (var cityModel in cityModels)
            {

                cities.Add(cityModel.ToEntity());
            }

            ActionResult<List<City>> result = new ActionResult<List<City>>();

            if (cities != null)
            {
                result.Data = cities;
                result.IsSuccess = true;
                result.Message = "OK";

            }
            else
            {
                result.IsSuccess = false;
                result.Message = "Failed";
            }
 
            return result;


        }

        public ActionResult<City> GetCityBYID(int id)
        {
            
            CityDataManager datamanager = new CityDataManager();
            CityModel citymodel = datamanager.GetCityBYID(id);

            

            ActionResult<City> result = new ActionResult<City>();

            if (citymodel != null)
            {
                result.Data = citymodel.ToEntity();
                result.IsSuccess = true;
                result.Message = "OK";

            }
            else
            {
                result.IsSuccess = false;
                result.Message = "Failed";
            }

            return result;
            
        }


        public ActionResult<City> Add(City city)
        {
            ActionResult<City> result = new ActionResult<City>();
            CityDataManager datamanager = new CityDataManager();
            //datamanager.CityCodeExist(city.Citycode);
            if (datamanager.CityCodeExist(city.Citycode))
            {
                result.IsSuccess = false;
                result.Message = "Failed";
                result.Errors.Add(" city with code " + city.Citycode + " already exist");
                return result;
            }


            CityModel citymodel = datamanager.Add(city.ToModel());

            if (citymodel != null)
            {
                result.Data = citymodel.ToEntity();
                result.IsSuccess = true;
                result.Message = "OK";

            }
            else
            {
                result.IsSuccess = false;
                result.Message = "Failed";
            }

            return result;
        }

        public ActionResult<City> Update(City city)
        {
            ActionResult<City> result = new ActionResult<City>();
            CityDataManager datamanager = new CityDataManager();
            //datamanager.CityCodeExist(city.Citycode);
            if (datamanager.CityCodeExist(city.Citycode,city.Id))
            {

                result.IsSuccess = false;
                result.Message = "Failed";
                result.Errors.Add(" city with code " + city.Citycode + " already exist");
                return result;
            }
            CityModel citymodel = datamanager.Update(city.ToModel());

            if (citymodel != null)
            {
                result.Data = citymodel.ToEntity();
                result.IsSuccess = true;
                result.Message = "OK";

            }
            else
            {
                result.IsSuccess = false;
                result.Message = "Failed";
            }

            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cities.Data;
namespace Cities.core
{
    public static class CityMapper
    {
        public static CityModel ToModel(this City city)
        {
            CityModel citymodel = new CityModel();
            citymodel.Id = city.Id;
            citymodel.Cityname = city.Cityname;
            citymodel.Citycode = city.Citycode;
            return citymodel;
        }

        public static City ToEntity(this CityModel citymodel)
        {
            City city = new City();
            city.Id = citymodel.Id;
            city.Cityname = citymodel.Cityname;
            city.Citycode = citymodel.Citycode;
            return city;
        }

    }
}

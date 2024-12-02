using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Cities.Data
{
    public class CityDataManager
    {
        private string _connectionstring;
        public CityDataManager()
        {
            _connectionstring = ConfigurationManager.ConnectionStrings["sqlconnection"].ConnectionString;
        }
        public List<CityModel> GetAllCities()
        {
            List<CityModel> cities = new List<CityModel>();
            using (SqlConnection sqlconn = new SqlConnection(_connectionstring))
            {
                sqlconn.Open();
                string query= "select id,cityName,cityCode from city ";
                SqlCommand command = new SqlCommand(query,sqlconn);
                SqlDataReader dataReader= command.ExecuteReader();

                
                while (dataReader.Read())
                {
                    CityModel city = new CityModel();
                    city.Id = int.Parse(dataReader["id"].ToString());
                    city.Cityname = dataReader["cityname"].ToString();
                    city.Citycode = dataReader["cityCode"].ToString();

                    cities.Add(city);

                }

            }
            return cities;
        }

        public CityModel GetCityBYID(int id )
        {
            CityModel city = new CityModel();
            using (SqlConnection sqlconn = new SqlConnection(_connectionstring))
            {
                sqlconn.Open();
                string query = "select id,cityName,cityCode from city where id= @id ";

                SqlCommand command = new SqlCommand(query, sqlconn);
                command.Parameters.Add("@id", id);
                SqlDataReader dataReader = command.ExecuteReader();


                while (dataReader.Read())
                {
                   
                    city.Id = int.Parse(dataReader["id"].ToString());
                    city.Cityname = dataReader["cityname"].ToString();
                    city.Citycode = dataReader["cityCode"].ToString();

                    

                }

            }
            return city;
        }

        public CityModel Add(CityModel citymodel)
        {
            using (SqlConnection sqlconn = new SqlConnection(_connectionstring))
            {
                sqlconn.Open();
                string query = "insert into city(cityname,citycode) values(@cityname,@citycode);select scope_identity()  ";

                SqlCommand command = new SqlCommand(query, sqlconn);
              
                command.Parameters.Add("@cityname", citymodel.Cityname);
                command.Parameters.Add("@citycode", citymodel.Citycode);
                citymodel.Id = int.Parse(command.ExecuteScalar().ToString());

                
            }

            return citymodel;
        }


        public bool CityCodeExist(string citycode,int id=0)
        {
            int returnvalue;
            CityModel city = new CityModel();
            using (SqlConnection sqlconn = new SqlConnection(_connectionstring))
            {
                sqlconn.Open();
                string query = "select count(*) from city where citycode= @citycode ";
                SqlCommand command = new SqlCommand(query, sqlconn);
                command.Parameters.Add("@citycode", citycode);
                if (id > 0)
                {
                    query = query + "  and id<> @id";
                    command.Parameters.Add("@id", id);
                }
                command.CommandText = query;

                returnvalue = int.Parse(command.ExecuteScalar().ToString());
                
            }
            
            return returnvalue>0?true:false;
        }



        public CityModel Update( CityModel citymodel)
        {
            using (SqlConnection sqlconn = new SqlConnection(_connectionstring))
            {
                sqlconn.Open();
                string query = "update city set cityname=@cityname,citycode=@citycode where id=@id; ";

                SqlCommand command = new SqlCommand(query, sqlconn);

                command.Parameters.Add("@id", citymodel.Id);
                command.Parameters.Add("@cityname", citymodel.Cityname);
                command.Parameters.Add("@citycode", citymodel.Citycode);
                command.ExecuteNonQuery();


            }

            return citymodel;
        }

    }
}

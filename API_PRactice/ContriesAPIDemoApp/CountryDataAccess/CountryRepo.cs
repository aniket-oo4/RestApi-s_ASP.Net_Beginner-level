using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryDataAccess
{
    public interface ICountryRepository
    {
        IEnumerable<CountryDTO> GetAllCountries();
        CountryDTO GetCountry(int id);
        int CreateCountry(CountryDTO country);
        int UpdateCountry(int id, CountryDTO country);
        bool DeleteCountry(int id);
    }

    public class CountryRepository : ICountryRepository
    {
        private readonly string _connectionString;

        public CountryRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<CountryDTO> GetAllCountries()
        {
            var countries = new List<CountryDTO>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT Id, Name, Capital, Population FROM Countries", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            countries.Add(new CountryDTO
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Capital = reader.GetString(2),
                                Population = reader.GetInt32(3)

                            });
                        }
                    }
                }
            }
            return countries;
        }

        // 
        public CountryDTO GetCountry(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT Id, Name, Capital, Population FROM Countries WHERE Id = @Id", connection))
                {
                    command.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new CountryDTO
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Capital = reader.GetString(2),
                                Population = reader.GetInt32(3)
                            };
                        }
                    }
                }
            }
            return null;
        }

        public int CreateCountry(CountryDTO country)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("INSERT INTO Countries (Name, Capital, Population) VALUES (@Name, @Capital, @Population); SELECT SCOPE_IDENTITY()", connection))
                {
                    command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = country.Name;
                    command.Parameters.Add("@Capital", SqlDbType.NVarChar).Value = country.Capital;
                    command.Parameters.Add("@Population", SqlDbType.Int).Value = country.Population;

                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }

        public int UpdateCountry(int id, CountryDTO country) // modified data type from void  to int 
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("UPDATE Countries SET Name = @Name, Capital = @Capital, Population = @Population WHERE Id = @Id", connection))
                {
                    command.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                    command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = country.Name;
                    command.Parameters.Add("@Capital", SqlDbType.NVarChar).Value = country.Capital;
                    command.Parameters.Add("@Population", SqlDbType.Int).Value = country.Population;

                    return (command.ExecuteNonQuery());
                }
            }
        }



        public bool DeleteCountry(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("DELETE FROM Countries WHERE Id = @Id", connection))
                {
                    command.Parameters.Add("@Id", SqlDbType.Int).Value = id;  // comand is a object of SqlCommand class 
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

    }

}

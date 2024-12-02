using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace DataAccessLayer
{
  public  class DataManager
    {
        public  string _connectionString {get;set;}

        public DataManager(string connectionString)
        {
            this._connectionString = connectionString;
        }

        public IEnumerable<EmployeeEntity> GetAllEmployees()
        {
            List<EmployeeEntity> employees = new List<EmployeeEntity>();             
             using (SqlConnection con=new SqlConnection(_connectionString))
             {
                 con.Open();
                 SqlCommand cmd = new SqlCommand("Select emp_id,emp_name,emp_age,emp_email from Employee", con);                
                 using (SqlDataReader reader = cmd.ExecuteReader())
                 {
                     while (reader.Read())
                     {
                         employees.Add(new EmployeeEntity
                         {
                             emp_id=reader.GetInt32(0),
                             emp_name= reader.GetString(1),
                             emp_age=reader.GetInt32(2),
                             emp_email = reader.GetString(3)
                         });
                     }
                 }//inner using
             }// outer using
             return employees;
        }// methode GetAllEmployees

        public EmployeeEntity GetEmployee(int id)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select emp_id,emp_name,emp_age,emp_email from Employee Where emp_id=@emp_id", con);
                
                    cmd.Parameters.Add("@emp_id", SqlDbType.Int).Value = id;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new EmployeeEntity
                            {
                                emp_id = reader.GetInt32(0),
                                emp_name = reader.GetString(1),
                                emp_age = reader.GetInt32(2),
                                emp_email = reader.GetString(3)
                            };                       
                        }
                    }//inner using
            }//outer using
            return null;
        }//method getEmployee

        public int CreateNewEmployee(int id, string name, int age, string email)
      {
           using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Employee (emp_id,emp_name,emp_age,emp_email) VALUES (@emp_id,@emp_name,@emp_age,@emp_email);", con))
                {
                    cmd.Parameters.Add("@emp_id",SqlDbType.Int).Value = id;
                    cmd.Parameters.Add("@emp_name", SqlDbType.NVarChar).Value =name;
                    cmd.Parameters.Add("@emp_age", SqlDbType.Int).Value = age;
                    cmd.Parameters.Add("@emp_email", SqlDbType.NVarChar).Value = email;
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
      }

      public int updateEmployee(int id ,string name,int age,string email)
      {
          using (SqlConnection connection = new SqlConnection(_connectionString))
          {
              connection.Open();
              using (SqlCommand cmd = new SqlCommand("UPDATE Employee SET emp_name=@emp_name,emp_age=@emp_age,emp_email=@emp_email WHERE emp_id = @emp_id", connection))
              {
                  cmd.Parameters.Add("@emp_id", SqlDbType.Int).Value = id;
                  cmd.Parameters.Add("@emp_name", SqlDbType.NVarChar).Value = name;
                  cmd.Parameters.Add("@emp_age", SqlDbType.Int).Value = age;
                  cmd.Parameters.Add("@emp_email", SqlDbType.NVarChar).Value = email;
                  return (cmd.ExecuteNonQuery());
              }
          }
      }


      public bool DeleteCountry(int id)
      {
          using (SqlConnection connection = new SqlConnection(_connectionString))
          {
              connection.Open();
              using (SqlCommand command = new SqlCommand("DELETE FROM Employee WHERE emp_id = @emp_id", connection))
              {
                  command.Parameters.Add("@emp_id", SqlDbType.Int).Value = id;  // comand is a object of SqlCommand class 
                  return command.ExecuteNonQuery() > 0;
              }
          }
      }
     

  }
}

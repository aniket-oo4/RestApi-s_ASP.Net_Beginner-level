using DataAccessLayer;
using EmployeeApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BusinessLayer
{

    public class myException : Exception
    {
        public ResultDTO result;
        public myException(ResultDTO result)            
        {
            this.result = result;              
        }
    }

    public class BusinessEmployee
    {
        public int emp_id { get; set; }
        public string emp_name { get; set; }
        public int emp_age { get; set; }
        public string emp_email { get; set; }
        public BusinessEmployee(int id, string name, int age, string email)
        {
            ResultDTO result = new ResultDTO();
            //if (id == null)
            //    result.ErrorList.Add("Employee id cannot be null");
            if (!this.ValidateName(name))
                result.ErrorList.Add("Name is invalid");
            if (!this.validateAge(age))
                result.ErrorList.Add("Age Must Be within a range 18 to 59");
            if (!this.validateEmail(email))
                result.ErrorList.Add("Email should contain one '@' symbol and  before end '.' symbol");

            if (result.ErrorList.Count > 0)
            {
                result.ResultCode = 555;
                result.ResultMessage = "UnSuccessFull";
                throw new myException(result);                
            }
            else
            {
                this.emp_id = id;
                this.emp_name = name;
                this.emp_age = age;
                this.emp_email = email;
            }
        }

        public bool ValidateName(string name)
        {
            if (name.Length < 0 || name.Length > 8)
                return false;
            return true;
        }

        public bool validateAge(int age)
        {
            if (age < 18 || age > 59)
                return false;
            return true;
        }
        public bool validateEmail(string email)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            if (match.Success)
                return true;
            else
                return false;
        }

    }

    public class BusinessManager
    {

        private readonly DataManager dataManager;
        public BusinessManager(string connectionString)
        {
            dataManager = new DataManager(connectionString);
        }


        //private readonly DataManager dataManager=new DataManager(System.Configuration.ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString));

        public IEnumerable<BusinessEmployee> GetValidatedAllEmployees()
        {
            var  emp=dataManager.GetAllEmployees();
            List<BusinessEmployee> businessEmp=new List<BusinessEmployee>();
                foreach(var bEmp in emp){
                    businessEmp.Add(new BusinessEmployee(bEmp.emp_id,bEmp.emp_name,bEmp.emp_age,bEmp.emp_email));
                }
                return businessEmp;
        }
//________________________________________________________________________________________________________________________       
        public BusinessEmployee GetValidatedEmployee(int id)
        {
            if (dataManager.GetEmployee(id) == null)
            {
                ResultDTO result=new ResultDTO();
                result.ResultCode = 444;
                //result.ResultMessage = "Employee Data Not fetched!!!";
                //result.ErrorList.Add("Employee not found for id :" + id);
                throw new myException(result);
            }
            EmployeeDTO emp = dataManager.GetEmployee(id);
            BusinessEmployee businessEmp = new BusinessEmployee(emp.emp_id,emp.emp_name,emp.emp_age,emp.emp_email);
            return businessEmp ;
        }
//________________________________________________________________________________________________________________________   
        //Validator validator = new Validator();
        //public ResultDTO AddNewEmp(EmployeeDTO emp)
        //{
        //    ResultDTO result = new ResultDTO();
        //    if (emp.emp_id == null)
        //        result.ErrorList.Add("Employee id cannot be null");
        //    if (!validator.ValidateName(emp.emp_name))
        //        result.ErrorList.Add("Name is invalid");
        //    if (!validator.validateAge(emp.emp_age))
        //        result.ErrorList.Add("Age Must Be within a range 18 to 59");
        //    if (!validator.validateEmail(emp.emp_email))
        //        result.ErrorList.Add("Email should contain one '@' symbol and  before end '.' symbol");
        //    if (result.ErrorList.Count == 0)
        //    {
        //        dataManager.CreateNewEmployee(emp);
        //    }
        //    return result;
        //    //return dataManager.CreateNewEmployee(emp)<0?false:true;
        //}


        public bool AddNewEmp(int id,string  name,int age ,string email)
        {
            BusinessEmployee businessEmp=new BusinessEmployee(id,name,age,email);
            if (dataManager.GetEmployee(id) != null)
                return false;
            int res = dataManager.CreateNewEmployee(id, name, age, email);
            return res <=0 ? false : true;
        }
//________________________________________________________________________________________________________________________   

        public bool UpdateValidatedEmployee(int id, string name, int age, string email)
        {
            if (dataManager.GetEmployee(id) == null)
            {
                ResultDTO result = new ResultDTO();
                result.ResultCode = 333;
                result.ErrorList.Add("Employee not found for id :" + id);
                throw new myException(result);
               // return false;
            }                         
            BusinessEmployee businessEmp = new BusinessEmployee(id, name, age, email);
            int res =  dataManager.updateEmployee(id, name, age, email);
            return res <= 0 ? false : true;

        }
        //ResultDTO result = new ResultDTO();
        //if (dataManager.GetEmployee(id) == null)
        //    result.ErrorList.Add("Employee with such id cannot be Found");
        //if (!validator.ValidateName(emp.emp_name))
        //    result.ErrorList.Add("Name is invalid");
        //if (!validator.validateAge(emp.emp_age))
        //    result.ErrorList.Add("Age Must Be within a range 18 to 59");
        //if (!validator.validateEmail(emp.emp_email))
        //    result.ErrorList.Add("Email should contain one '@' symbol and  before end '.' symbol");
        //if (result.ErrorList.Count == 0)
        //{
        //    dataManager.updateEmployee(id, emp);
        //}
        //return result;
 //________________________________________________________________________________________________________________________   

        public ResultDTO DeleteEmployee(int id )
        {
            ResultDTO result = new ResultDTO();
            if (dataManager.GetEmployee(id)==null)
            {
                result.ResultCode = 404;
                return result;
            }
            else if (!dataManager.DeleteCountry(id))
            {
                result.ResultCode = 777;
                return result;
            }
            result.ResultCode=200;
            return result;          

        }


    }
}

using BusinessLayer;
using EmployeeApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace EmployeeApi.Controllers
{
    public class EmployeesController : ApiController
    {
        private BusinessManager businessManager = new BusinessManager(System.Configuration.ConfigurationManager.ConnectionStrings["EmployeeConnection"].ConnectionString);

        // GET api/Employees
        public HttpResponseMessage Get()
        {
            if (businessManager.GetValidatedAllEmployees() != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, businessManager.GetValidatedAllEmployees());
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Employees Data not Found");
            }

            //return Request.CreateResponse(HttpStatusCode.OK, "Employees Data not Found");

        }

        // GET api/Employees/5
        public HttpResponseMessage Get(int id)
        {
            try
            {
                BusinessEmployee emp = businessManager.GetValidatedEmployee(id);

                return Request.CreateResponse(HttpStatusCode.OK, new ClientEmployeeDTO {emp_id=emp.emp_id,emp_name=emp.emp_name,emp_age=emp.emp_age,emp_email=emp.emp_email });
            }
            catch (myException e)
            {
                if (e.result.ResultCode == 444)
                {
                    e.result.ResultMessage = "Employee Data Not fetched!!!";
                    e.result.ErrorList.Add("Employee not found for id :" + id);
                }
                return Request.CreateResponse(HttpStatusCode.NotFound, e.result);
            }
            //if (businessManager.GetValidatedEmployee(id) != null)
            //{
            //    return Request.CreateResponse(HttpStatusCode.OK, businessManager.GetValidatedEmployee(id));
            //}
            //else
            //{
            //    return Request.CreateResponse(HttpStatusCode.OK,"Such employee not Found");
            //}


        }

        // POST api/Employees
  //      public HttpResponseMessage Post([FromBody]EmployeeDTO emp)
  //      {
  ////CreateResponse<T>(this HttpRequestMessage request, HttpStatusCode statusCode, T value);
  //          ResultDTO result = businessManager.AddNewEmp(emp);
  //          if (result.ErrorList.Count==0)
  //          {
  //              return Request.CreateResponse(HttpStatusCode.OK, "Employee Profile Successfully Created");
  //          }
  //          else
  //          {
  //              result.ResultCode = 555;
  //              result.ResultMessage = "Employee Profile not Created!!!";
  //              return Request.CreateResponse(HttpStatusCode.OK, result);
  //          }
  //      }


        public HttpResponseMessage Post([FromBody]ClientEmployeeDTO emp)
        {
            try
            {
                if (businessManager.AddNewEmp(emp.emp_id,emp.emp_name,emp.emp_age,emp.emp_email))
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Employee Profile Successfully Created");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Employee Profile not Created!!!");
                }
            }
            catch (myException e)
            {
                return Request.CreateResponse(HttpStatusCode.OK, e.result);
            }
        }          
            //CreateResponse<T>(this HttpRequestMessage request, HttpStatusCode statusCode, T value);
            //ResultDTO result = businessManager.AddNewEmp(emp);
            //if (result.ErrorList.Count == 0)
            //{
            //    return Request.CreateResponse(HttpStatusCode.OK, "Employee Profile Successfully Created");
            //}
            //else
            //{
            //    result.ResultCode = 555;
            //    result.ResultMessage = "Employee Profile not Created!!!";
            //    return Request.CreateResponse(HttpStatusCode.OK, result);
            //}
        //}


        // PUT api/Employees/5
        
        public HttpResponseMessage Put(int id, [FromBody]ClientEmployeeDTO emp)
        {
            try
            {
                if (businessManager.UpdateValidatedEmployee(id, emp.emp_name, emp.emp_age, emp.emp_email))
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Employee Profile Successfully Updated");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Employee Profile not Updated!!!");
                }

            }
            catch (myException e)
            {
                if (e.result.ResultCode == 333)
                    e.result.ResultMessage = "Not Found Exception";
                return Request.CreateResponse(HttpStatusCode.OK, e.result);
            }


            //ResultDTO result = businessManager.UpdateValidatedEmployee(id,emp);
            //if (result.ErrorList.Count == 0)
            //{
            //    return Request.CreateResponse(HttpStatusCode.OK, "Employee Profile Successfully Updated");
            //}
            //else
            //{
            //    result.ResultCode = 555;
            //    result.ResultMessage = "Employee Profile not Updated!!!";
            //    return Request.CreateResponse(HttpStatusCode.OK, result);
            //}
        }

        // DELETE api/Employees/5
        public HttpResponseMessage Delete(int id)
        {
            ResultDTO result = businessManager.DeleteEmployee(id);
            if(result.ResultCode==404)
                return Request.CreateResponse(HttpStatusCode.NotFound, "Employee with id :"+id+" : not Found!!!");
            else if(result.ResultCode==777)
                return Request.CreateResponse(HttpStatusCode.NotModified, "Employee with id :" + id + " : not Removed !!!");
            return Request.CreateResponse(HttpStatusCode.OK, "Employee with id :" + id + " : Deleted from DataBase!!!");
           
        }


    }
}

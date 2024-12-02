using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using EmployeeDataAccess;
namespace Demo1.Controllers
{
    public class EmployeesController : ApiController
    {
        // GET api/values
        public IEnumerable<Employee> Get()
        {
            using (APIPracticeEntities entities =new APIPracticeEntities())
            {
                return entities.Employees.ToList();

            }
        }

        // GET api/values/5
        // GET api/values
        public Employee Get(int id)
        {
            using (APIPracticeEntities entities = new APIPracticeEntities())
            {
                return entities.Employees.FirstOrDefault(e=>e.emp_id==id);

            }
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
       

    }
}

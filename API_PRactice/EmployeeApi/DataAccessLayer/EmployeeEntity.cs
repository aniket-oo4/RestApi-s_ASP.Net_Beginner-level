using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
   public  class EmployeeEntity
    {
        public int emp_id { get; set; }
        public string emp_name { get; set; }
        public int emp_age { get; set; }
        public string emp_email { get; set; }
    }
}

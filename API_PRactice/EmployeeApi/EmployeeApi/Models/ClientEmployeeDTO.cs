using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeApi.Models
{
    public class ClientEmployeeDTO
    {       
            public int emp_id { get; set; }
            public string emp_name { get; set; }
            public int emp_age { get; set; }
            public string emp_email { get; set; }        
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeApi.Controllers
{
    public class ResultObj
    {
        public int ResultCode{get;set;}
        public string ResultMessage {get;set;}
        public List<string> ErrorList = new List<string>();
    }
}
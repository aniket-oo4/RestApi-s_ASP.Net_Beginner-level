using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveCore_BL
{
    public class ActionResult<T>
    {
        public ActionResult()
        {
            ErrorList = new List<string>();
        }
        public Boolean IsSuccess { get; set; }

        public List<string> ErrorList { get; set; }

        public T Data { get; set; }  // for getting result into that 

        public string Message { get; set; }  // any message code Ok/Failed

    }
}

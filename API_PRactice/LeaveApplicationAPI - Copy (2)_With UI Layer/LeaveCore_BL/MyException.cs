using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveCore_BL
{
    public class MyException<T> : Exception
    {
        public ActionResult<T> result;
        public MyException(ActionResult<T> result)
        {
            this.result = result;
        }
    }
}

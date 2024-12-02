using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cities.core
{
    public class ActionResult<T>
    {
        public ActionResult()
        {
            Errors = new List<string>();

        }
        public Boolean IsSuccess { get; set; }

        public List<string> Errors { get; set; }

        public T Data { get; set; }

        public string Message { get; set; }

    }
}

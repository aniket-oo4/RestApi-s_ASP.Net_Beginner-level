using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeaveAppMainAPI.App_Code
{
    public class LeaveDTO
    {
        public int leaveId { get; set; }
        public int empId { get; set; }
        public string empName { get; set; }
        public string leaveType { get; set; }
        public DateTime leaveDateFrom { get; set; }
        public DateTime leaveDateTo { get; set; }
        public string remark { get; set; }
        public string status { get; set; }

    }
}
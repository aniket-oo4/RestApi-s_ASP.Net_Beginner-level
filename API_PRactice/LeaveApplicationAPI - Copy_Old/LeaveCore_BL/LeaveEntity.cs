using LeaveData_DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveCore_BL
{
    public class LeaveEntity
    {
        public int leaveId { get; set; }
        public int empId { get; set; }
        public string leaveType { get; set; }
        public DateTime applicationDate { get; set; }
        public DateTime leaveDateFrom { get; set; }
        public DateTime leaveDateTo { get; set; }
        public string remark { get; set; }
        public string status { get; set; }
        public int totalLeaves { get; set; }

        //constructor for post
        public LeaveEntity(int empId, string leaveType, DateTime leaveDateFrom, DateTime leaveDateTo, string remark, string status, int totalLeaves = 0, int leaveId = -1)
        {
            ActionResult<LeaveEntity> result = new ActionResult<LeaveEntity>();
            DataManager dataManager = new DataManager();
            if (leaveId == -1)
            {
                if (IsPastDated(leaveDateFrom) || IsPastDated(leaveDateTo))
                    result.ErrorList.Add("leaves cannot be applied for past dates !!");
                if (IsNotInLimit(leaveDateFrom, leaveDateTo))
                    result.ErrorList.Add("leave application cannot be for more than 5 days Your Application Is For :" + (leaveDateTo - leaveDateFrom).TotalDays + " Days ");
                if (IsValidFormat(leaveDateFrom, leaveDateTo) == false)
                    result.ErrorList.Add("Leave from date must be equal to or less than leave to date !!");

              
                if (dataManager.IsOverlap(empId, leaveDateFrom))
                    result.ErrorList.Add("leaves cannot overlap.!!");
                if (dataManager.GetLB(empId) < (leaveDateTo - leaveDateFrom).TotalDays)
                {
                    result.ErrorList.Add("Your  Current Leave is Less Than YOur Applied Leave Period  | Leave Balance :" + dataManager.GetLB(empId) + "days  Applied Leave:" + (leaveDateTo - leaveDateFrom).TotalDays + "days");
                }

            }

            if (result.ErrorList.Count > 0)
            {
                result.IsSuccess = false;
                result.Message = "InValid";
                throw new MyException<LeaveEntity>(result);
            }
            else
            {
                if (leaveId != -1)
                    this.leaveId = leaveId;
                this.empId = empId;
                this.leaveType = leaveType;
                this.leaveDateFrom = leaveDateFrom;
                this.leaveDateTo = leaveDateTo;
                this.remark = remark;
                this.status = status;
                this.totalLeaves = Convert.ToInt32((leaveDateTo - leaveDateFrom).TotalDays);
            }
        }
        protected bool IsPastDated(DateTime leaveDateFrom)
        {
            if (leaveDateFrom.Date < DateTime.Now.Date)
                return true;
            return false;
        }
        protected bool IsValidFormat(DateTime leaveDateFrom, DateTime leaveDateTo)
        {
            if (leaveDateFrom <= leaveDateTo)
                return true;
            return false;
        }
        protected bool IsNotInLimit(DateTime leaveDateFrom, DateTime leaveDateTo)
        {
            if ((leaveDateTo - leaveDateFrom).TotalDays > 5) // .TotalDays Returns the Number of days 
                return true;
            return false;
        }
    }
}

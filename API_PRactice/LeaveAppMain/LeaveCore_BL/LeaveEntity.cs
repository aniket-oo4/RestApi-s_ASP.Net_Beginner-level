using LeaveData_DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveCore_BL
{
   public  class LeaveEntity
    {
        public int leaveId { get; set; }
        public int empId { get; set; }
        public string empName { get; set; }
        public string leaveType { get; set; }
        public DateTime applicationDate { get; set; }
        public DateTime leaveDateFrom { get; set; }
        public DateTime leaveDateTo { get; set; }
        public string remark { get; set; }
        public string status { get; set; }
        public int totalLeaves { get; set; }

       // constructor for get 
     public   LeaveEntity(int id)
        {
            this.leaveId = id;
        }
        //constructor for post
        public LeaveEntity(int empId, string leaveType, DateTime leaveDateFrom, DateTime leaveDateTo, string remark, string status, int totalLeaves = 0, int leaveId = -1)
        {
            ActionResult<LeaveEntity> result = new ActionResult<LeaveEntity>();
            DateTime dt = new DateTime();
            DataManager dataManager = new DataManager();
            if (leaveId == -1)
            {
                if (leaveDateFrom == new DateTime(0001, 1, 1, 0, 0, 0) || leaveDateTo == new DateTime(0001, 1, 1, 0, 0, 0))
                {
                    result.ErrorList.Add("LeaveApplication Start DAte Or End Date Cannot be null ");
                }
                else
                {
                    if (IsPastDated(leaveDateFrom) || IsPastDated(leaveDateTo))
                        result.ErrorList.Add("leaves cannot be applied for past dates !!");
                    if (IsNotInLimit(leaveDateFrom, leaveDateTo))
                        result.ErrorList.Add("leave application cannot be for more than 5 days Your Application Is For :" + (leaveDateTo - leaveDateFrom).TotalDays + " Days ");
                    if (IsValidFormat(leaveDateFrom, leaveDateTo) == false)
                        result.ErrorList.Add("Leave from date must be equal to or less than leave to date !!");
                }

                //check any data is not null || not provided by user 
                if (empId == 0)
                {
                    result.ErrorList.Add("Emp_id cannot be a null  value !!");
                }
                else
                {
                    if (dataManager.IsEmpExist(empId))
                    {
                        if (dataManager.IsOverlap(empId, leaveDateFrom, leaveDateTo))
                            result.ErrorList.Add("leaves cannot overlap.!!");

                        if (dataManager.GetLB(empId) < (leaveDateTo - leaveDateFrom).TotalDays)
                            result.ErrorList.Add("Your  Current Leave is Less Than YOur Applied Leave Period  | Leave Balance :" + dataManager.GetLB(empId) + "days  Applied Leave:" + (leaveDateTo - leaveDateFrom).TotalDays + "days");
                    }
                    else
                    {
                        result.ErrorList.Add("Employee for id " + empId + " Does not Exist .!!");
                    }
                }

                if (string.IsNullOrEmpty(leaveType))
                {
                    result.ErrorList.Add("leaveType cannot be a null  value !!");
                }
                if (string.IsNullOrEmpty(remark))
                {
                    result.ErrorList.Add("remark cannot be a null  value !!");
                }
                if (string.IsNullOrEmpty(status))
                {
                    result.ErrorList.Add("status cannot be a null  value !!");
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

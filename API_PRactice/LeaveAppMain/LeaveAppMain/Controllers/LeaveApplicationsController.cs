using LeaveCore_BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;


namespace LeaveAppMainAPI.Controllers
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
    
    public class LeaveApplicationsController : ApiController
    {
         private LeaveManager _leaveManager;
         LeaveApplicationsController()
        {
            this._leaveManager = new LeaveManager();
        }

        // GET api/LeaveApi
        public ActionResult<List<LeaveEntity>> Get()
        {
            return _leaveManager.GetAllLeaves();
        }

         //GET api/LeaveApi  withEmp


        // GET api/LeaveApi/id
        public ActionResult<LeaveEntity> Get(int id)
        {
            return _leaveManager.GetLeaveBYID(id);
        }

        //POST api/LeaveApi/id
        public ActionResult<LeaveEntity> Post([FromBody]LeaveDTO leave)
        {
            try
            {
                if (leave == null)
                {
                    ActionResult<LeaveEntity> result = new ActionResult<LeaveEntity>();
                    result.IsSuccess = false; result.ErrorList.Add("You AreTrying to insert  null Values !! Null Values are not allowed");
                    result.Message = "Failed";
                    return result;
                }
                return _leaveManager.Create(new LeaveEntity(leave.empId, leave.leaveType, leave.leaveDateFrom, leave.leaveDateTo, leave.remark, leave.status));
            }
            catch (MyException<LeaveEntity> e)
            {
                return e.result;
            }
        }

        public ActionResult<LeaveEntity> Put([FromBody] LeaveDTO leave, int id)
        {
            try
            {
                if (leave == null)
                {
                    ActionResult<LeaveEntity> result = new ActionResult<LeaveEntity>();
                    result.IsSuccess = false; result.ErrorList.Add("You AreTrying to insert  null Values !! Null Values are not allowed");
                    result.Message = "Failed";
                    return result;
                }
                return _leaveManager.Update(new LeaveEntity(leave.empId, leave.leaveType, leave.leaveDateFrom, leave.leaveDateTo, leave.remark, leave.status), id);
            }
            catch (MyException<LeaveEntity> e)
            {
                return e.result;
            }
        }

        public ActionResult<string> Delete(int id)
        {
            return _leaveManager.Delete(id);
        }
 

    }
}

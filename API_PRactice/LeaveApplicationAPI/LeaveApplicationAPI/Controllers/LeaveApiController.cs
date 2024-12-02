using LeaveApplicationAPI.Models;
using LeaveCore_BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;


namespace LeaveApplicationAPI.Controllers
{
    [Authorize ]
    public class LeaveApiController : ApiController
    {
        private LeaveManager _leaveManager;
        LeaveApiController()
        {
            this._leaveManager = new LeaveManager();
        }

        // GET api/LeaveApi
        public ActionResult<List<LeaveEntity>> Get()
        {
            return _leaveManager.GetAllLeaves();
        }

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

        public ActionResult<LeaveEntity> Put([FromBody]LeaveDTO leave,int id)
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
                return _leaveManager.Update(new LeaveEntity(leave.empId, leave.leaveType, leave.leaveDateFrom, leave.leaveDateTo, leave.remark, leave.status),id);
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

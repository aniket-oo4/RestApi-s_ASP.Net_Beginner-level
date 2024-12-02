using LeaveApplicationAPI.Models;
using LeaveCore_BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

// this  APi is used for multiple  javascript /jQuery ui  
namespace LeaveApplicationAPI.Controllers
{

    [Authorize(Roles = "aniket")]
    public class LeaveApiController : ApiController
    {
        private LeaveManager _leaveManager;
        LeaveApiController()
        {
            this._leaveManager = new LeaveManager();
        }

        // GET api/LeaveApi
        [HttpGet]
        public ActionResult<List<LeaveEntity>> Get()
        {
 var result = _leaveManager.GetAllLeaves();
            result.resultCount = _leaveManager.GetAllLeaves().Data.Count;
            return result;
           

        }

        //api/leaves?start=1&size=10
        public ActionResult<List<LeaveEntity>> Get([FromUri]int start, [FromUri]int size)
        {
            ActionResult<List<LeaveEntity>> ans = _leaveManager.GetAllLeaves();
            ActionResult<List<LeaveEntity>> groupedData = new ActionResult<List<LeaveEntity>>();

            groupedData.Data = new List<LeaveEntity>();
            if (start!=0)
            {
                start *= 10;
            }
            else 
            {
                start = 0;
            }
            size = start + size;
            if (size > ans.Data.Count)
            {
                size -= (start + size) - ans.Data.Count;
                size = start + size;
            }
            for (int i = start; i < size; i++)
            {
                groupedData.Data.Add(ans.Data[i]);
            }

            groupedData.resultCount = groupedData.Data.Count;
            groupedData.totalRecords = ans.Data.Count;
            return groupedData;
        }

        // GET api/leaves/id
        [HttpGet]
        public ActionResult<LeaveEntity> Get(int id)
        {
            return _leaveManager.GetLeaveBYID(id);
        }

        //POST api/leaves/id
        [HttpPost]
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

      
        [HttpPut]
        public ActionResult<LeaveEntity> Put([FromBody]LeaveDTO leave, int id)
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

        [HttpDelete]
        public ActionResult<string> Delete(int id)
        {
            return _leaveManager.Delete(id);
        }
    }
}

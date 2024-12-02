using LeaveData_DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveCore_BL
{
  public   class LeaveManager
    {
      private readonly DataManager _datamanager;
   public   LeaveManager()
      {
          this._datamanager = new DataManager();
      }


      public ActionResult<List<LeaveEntity>> GetAllLeaves()
      {
          List<LeaveEntity> leaveEntities = new List<LeaveEntity>();
          List<LeaveModel> leaveModels = _datamanager.GetAllLeaves();
          foreach (var leaveModel in leaveModels)
          {
              leaveEntities.Add(leaveModel.ToEntity());
          }
          ActionResult<List<LeaveEntity>> result = new ActionResult<List<LeaveEntity>>();
          if (leaveEntities != null)
          {
              result.Data = leaveEntities;
              result.IsSuccess = true;
              result.Message = "OK";
          }
          else
          {
              result.IsSuccess = false;
              result.Message = "Failed";
          }
          return result;
      }

      public ActionResult<LeaveEntity> GetLeaveBYID(int id)
      {
          LeaveModel leavemodel = _datamanager.GetLeaveBYID(id);
          ActionResult<LeaveEntity> result = new ActionResult<LeaveEntity>();
          if (leavemodel != null)
          {
              result.Data = leavemodel.ToEntity();
              result.IsSuccess = true;
              result.Message = "OK";
          }
          else
          {
              result.IsSuccess = false;
              result.Message = "Failed";
              result.ErrorList.Add("Not any  Leave record Found  for Id:" + id+"!!");
          }
          return result;
      }

      public ActionResult<LeaveEntity> Create(LeaveEntity leave)
      {
          ActionResult<LeaveEntity> result = new ActionResult<LeaveEntity>();
          LeaveModel leavemodel = _datamanager.Create(leave.ToModel());
          if (leavemodel != null)
          {
              result.Data = leavemodel.ToEntity();
              result.IsSuccess = true;
              result.Message = "OK";
          }
          else
          {
              result.IsSuccess = false;
              result.Message = "Failed";
          }
          return result;
      }

      public ActionResult<LeaveEntity> Update(LeaveEntity leave)
      {
          ActionResult<LeaveEntity> result = new ActionResult<LeaveEntity>();
          if (!_datamanager.LeaveExist(leave.leaveId))
          {
              result.IsSuccess = false;
              result.Message = "Failed";
              result.ErrorList.Add(" leave Application with id " + leave.leaveId + " not exist");
              return result;
          }
          LeaveModel leavemodel = _datamanager.Update(leave.ToModel());
          if (leavemodel != null)
          {
              result.Data = leavemodel.ToEntity();
              result.IsSuccess = true;
              result.Message = "OK";
          }
          else
          {
              result.IsSuccess = false;
              result.Message = "Failed";
          }
          return result;
      }

      public ActionResult<string> Delete(int id)
      {
          ActionResult<string> result = new ActionResult<string>();
          if (!_datamanager.LeaveExist(id))
          {
              result.IsSuccess = false;
              result.Message = "Failed";
              result.ErrorList.Add(" leave Application with id " + id+ " not exist");
              return result;
          }         
          if (_datamanager.Delete(id))
          {
              result.Data ="Leave Application with Id:"+id+" Deleted from DAtaBase ";
              result.IsSuccess = true;
              result.Message = "OK";
          }
          else
          {
              result.IsSuccess = false;
              result.Message = "Failed";
          }
          return result;
      } 

    }
}

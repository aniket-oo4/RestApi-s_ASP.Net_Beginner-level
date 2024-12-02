using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeaveData_DL;
namespace LeaveCore_BL
{
    public static class DataMapper
    {

        public static LeaveModel ToModel(this LeaveEntity leaveEntity)
        {
            LeaveModel leaveModel = new LeaveModel();
            leaveModel.leaveId = leaveEntity.leaveId;
            leaveModel.empId = leaveEntity.empId;
            leaveModel.leaveType = leaveEntity.leaveType;
            leaveModel.leaveDateFrom = leaveEntity.leaveDateFrom;
            leaveModel.leaveDateTo = leaveEntity.leaveDateTo;
            leaveModel.remark = leaveEntity.remark;
            leaveModel.status = leaveEntity.status;
            leaveModel.totalLeaves = leaveEntity.totalLeaves;
            return leaveModel;
        }

        public static LeaveEntity ToEntity(this LeaveModel leaveModel)
        {
            LeaveEntity leaveEntity;
            if (leaveModel.applicationDate != DateTime.MinValue)
            {
                leaveEntity = new LeaveEntity(); 
                leaveEntity.applicationDate = leaveModel.applicationDate;

                leaveEntity.leaveId = leaveModel.leaveId;
                leaveEntity.empId = leaveModel.empId;
                leaveEntity.empName = leaveModel.empName;
                leaveEntity.leaveType = leaveModel.leaveType;
                leaveEntity.leaveDateFrom = leaveModel.leaveDateFrom;
                leaveEntity.leaveDateTo = leaveModel.leaveDateTo;
                leaveEntity.remark = leaveModel.remark;
                leaveEntity.status = leaveModel.status;
                leaveEntity.totalLeaves = leaveModel.totalLeaves;
            }
            else
            {
              leaveEntity = new LeaveEntity(leaveModel.empId, leaveModel.leaveType, leaveModel.leaveDateFrom, leaveModel.leaveDateTo, leaveModel.remark, leaveModel.status, leaveModel.totalLeaves, leaveModel.leaveId);
            }
            
            return leaveEntity;
        }


    }
}

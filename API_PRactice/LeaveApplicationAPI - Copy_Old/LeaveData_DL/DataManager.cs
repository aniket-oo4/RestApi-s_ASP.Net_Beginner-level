using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
namespace LeaveData_DL
{
    public class DataManager
    {
        private string _connectionstring;

        public DataManager()
        {
            _connectionstring = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
        }

        public List<LeaveModel> GetAllLeaves()
        {
            List<LeaveModel> leaves = new List<LeaveModel>();
            using (SqlConnection conn=new SqlConnection(_connectionstring))
            {
                conn.Open();
                string query = "select leave_id,emp_id,leave_type,ApplicationDate,leave_dateFrom,leave_dateTo,remark,status,totalLeaves from leaves";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    LeaveModel leave = new LeaveModel();
                    leave.leaveId = int.Parse(dataReader["leave_id"].ToString());
                    leave.empId = int.Parse(dataReader["emp_id"].ToString());
                    leave.leaveType = dataReader["leave_type"].ToString();
                    leave.applicationDate = dataReader.GetDateTime(3);
                    leave.leaveDateFrom = dataReader.GetDateTime(4);
                    leave.leaveDateTo = dataReader.GetDateTime(5);
                    leave.remark = dataReader["remark"].ToString();
                    leave.status = dataReader["status"].ToString();
                    leave.totalLeaves = int.Parse(dataReader["totalLeaves"].ToString());

                    leaves.Add(leave);
                }
            }
            return leaves;
        }


        public LeaveModel GetLeaveBYID(int id)
        {
            LeaveModel leave = new LeaveModel();
            using (SqlConnection conn =new SqlConnection(this._connectionstring))
            {
                conn.Open();
                string query = "select leave_id,emp_id,leave_type,ApplicationDate,leave_dateFrom,leave_dateTo,remark,status,totalLeaves from leaves where leave_id=" + id;
                SqlCommand cmd  = new SqlCommand(query, conn);
                //cmd.Parameters.Add("@leave_id", id);
                SqlDataReader dataReader = cmd.ExecuteReader();
                if (dataReader.Read())
                {
                    leave.leaveId = int.Parse(dataReader["leave_id"].ToString());
                    leave.empId = int.Parse(dataReader["emp_id"].ToString());
                    leave.leaveType = dataReader["leave_type"].ToString();
                    leave.applicationDate = dataReader.GetDateTime(3);
                    leave.leaveDateFrom = dataReader.GetDateTime(4);
                    leave.leaveDateTo = dataReader.GetDateTime(5);
                    leave.remark = dataReader["remark"].ToString();
                    leave.status = dataReader["status"].ToString();
                    leave.totalLeaves = int.Parse(dataReader["totalLeaves"].ToString());
                    return leave;
                }

            }
            return null;
        }

        public LeaveModel Create(LeaveModel leavemodel)
        {
            using (SqlConnection sqlconn = new SqlConnection(_connectionstring))
            {
                sqlconn.Open();
                string query = "insert into leaves(emp_id,leave_type,ApplicationDate,leave_dateFrom,leave_dateTo,remark,status,totalLeaves) values(@emp_id,@leave_type,GETDATE(),@leave_dateFrom,@leave_dateTo,@remark,@status,@totalLeaves);select scope_identity()";
                SqlCommand command = new SqlCommand(query, sqlconn);
                command.Parameters.Add("@emp_id", leavemodel.empId);
                command.Parameters.Add("@leave_type", leavemodel.leaveType);
                command.Parameters.Add("@leave_dateFrom", leavemodel.leaveDateFrom);
                command.Parameters.Add("@leave_dateTo", leavemodel.leaveDateTo);
                command.Parameters.Add("@remark", leavemodel.remark);
                command.Parameters.Add("@status", leavemodel.status);
                command.Parameters.Add("@totalLeaves", leavemodel.totalLeaves);
                leavemodel.leaveId = int.Parse(command.ExecuteScalar().ToString());
            }
            return leavemodel;
        }

        public bool LeaveExist(int leave_id)
        {
            int returnvalue;
            using (SqlConnection conn=new SqlConnection(_connectionstring))
            {
                conn.Open();
                string query = "select count(*) from leaves where leave_id= @leave_id ";
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.Add("@leave_id", leave_id);
                returnvalue = int.Parse(command.ExecuteScalar().ToString());
            }
            return returnvalue > 0 ? true : false;
        }

        public bool IsOverlap(int emp_id,DateTime fromDate)
        {
            int returnvalue;
            using (SqlConnection conn= new SqlConnection (_connectionstring))
            {
                conn.Open();
                string query = "select count(*) from leaves where emp_id= @emp_id and leave_dateTo >@leave_dateFrom";
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.Add("@leave_dateFrom", fromDate);
                command.Parameters.Add("@emp_id", emp_id);
                returnvalue = int.Parse(command.ExecuteScalar().ToString());              
            }
            return returnvalue > 0 ? true : false;
        }

        public int GetLB(int emp_id)
        {
            int LB;
            using (SqlConnection conn = new SqlConnection(_connectionstring))
            {
                conn.Open();
                string query = "select leaveBalance from Employee where emp_id= @emp_id ";
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.Add("@emp_id", emp_id);
                LB = int.Parse(command.ExecuteScalar().ToString());
            }
            return LB ;
        }
        public LeaveModel Update(LeaveModel leavemodel)
        {
            using (SqlConnection conn = new SqlConnection(this._connectionstring))
            {
                conn.Open();
                string query = "update leaves set leave_type=@leave_type,leave_dateFrom=@leave_dateFrom,leave_dateTo=@leave_dateTo,remark=@remark,status=@status,totalLeaves=@totalLeaves where leave_id=@leave_id;";
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.Add("@leave_id", leavemodel.leaveId);
                command.Parameters.Add("@leave_type", leavemodel.leaveType);
                command.Parameters.Add("@leave_dateFrom", leavemodel.leaveDateFrom);
                command.Parameters.Add("@leave_dateTo", leavemodel.leaveDateTo);
                command.Parameters.Add("@remark", leavemodel.remark);
                command.Parameters.Add("@status", leavemodel.status);
                command.Parameters.Add("@totalLeaves", leavemodel.totalLeaves);
                int res = command.ExecuteNonQuery();
            }
            return leavemodel;
        }

        public bool Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(this._connectionstring))
            {
                conn.Open();
                string query = "Delete from leaves where leave_id=@leave_id;";
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.Add("@leave_id", id);
                return command.ExecuteNonQuery() > 0;
            }
        }
    }
}

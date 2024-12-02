using ApiHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LeaveAppServerSideUIApp.SecuredFolders
{
    public partial class GetById : System.Web.UI.Page
    {
        private string _token;

        protected void Page_Load(object sender, EventArgs e)
        {
            Panel1.Visible = false;
            //Panel1.Visible = true;

            if (!String.IsNullOrEmpty(Session["token"].ToString()))
            {
                _token = Session["token"].ToString();
                ltrMessage.Text = "TOken Successfully Settled";
                btnSearchById.Enabled=true;
         
            }
            else
            {
                btnSearchById.Enabled = false;
                ltrMessage.Text = "Token Was Not Set hence You are  not Allowed to access Data";
            }
        }

        protected async void btnSearchById_Click(object sender, EventArgs e)
        {
            //await ApiCaller.FetchAllData(token: _token);
            //await FetchAndBindData();
            //var leaves = await ApiCaller.FetchDataById(_token, Convert.ToInt16(txtLeaveId.Text));
           ActionResult<LeaveDTO> result=await ApiCaller.FetchDataById(_token, Convert.ToInt16(txtLeaveId.Text));
            if (result.Data != null)
            {
                object data=result.Data;
                var demo=(LeaveDTO) data;
                txtEmpId.Text = demo.empId.ToString();
                txtEmpName.Text = demo.empName.ToString();
                txtApplicationDate.Text = demo.applicationDate.ToString();
                txtLeaveDateFrom.Text = demo.leaveDateFrom.ToString();
                txtleaveDateTo.Text = demo.leaveDateTo.ToString();
                txtRemark.Text = demo.remark;
                ddlStatus.SelectedItem.Value = demo.status;
                lblTotalLeaves.Text = demo.totalLeaves.ToString();
                Panel1.Visible = true;
            }
            else if (result.ErrorList.Count>0)
            {
                string errors = "";
                foreach (var error in result.ErrorList)
                {
                    errors +=  error+ " |";
                }
                Response.Write("<script>alert('" + " Errors:" + errors + "Message:" + result.Message + "')</script>");
                

            }
            else
            {
                if (result.Message == "NOT OK")
                {
                    Response.Write("<script>alert('" + result.IsSuccess + " Errors:" + result.ErrorList[0] + "Message:" + result.Message + "')</script>");
                }
            }
            

        }
    }
}
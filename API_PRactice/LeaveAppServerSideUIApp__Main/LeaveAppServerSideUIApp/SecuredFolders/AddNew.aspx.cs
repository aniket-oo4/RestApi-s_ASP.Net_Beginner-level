using ApiHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LeaveAppServerSideUIApp.SecuredFolders
{
    public partial class AddNew : System.Web.UI.Page
    {
        private string _token;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Panel1.Visible = true;

            if (!String.IsNullOrEmpty(Session["token"].ToString()))
            {
                _token = Session["token"].ToString();
                ltrMessage.Text = "TOken Successfully Settled";
                btnAddLeave.Enabled = true;
              

            }
            else
            {
                btnAddLeave.Enabled = false;
                ltrMessage.Text = "Token Was Not Set hence You are  not Allowed to Post Data";
            }
        }

        protected async void btnAddLeave_Click(object sender, EventArgs e)
        {
            LeaveDTO leave=new LeaveDTO();
            leave.empId=Convert.ToInt16(txtEmpId.Text);
            leave.leaveType=txtLeaveType.Text;
            leave.leaveDateFrom=Convert.ToDateTime( txtLeaveDateFrom.Text);
            leave.leaveDateTo=Convert.ToDateTime(txtleaveDateTo.Text);
            leave.remark=txtRemark.Text;
            leave.status=ddlStatus.SelectedValue;

            ActionResult<LeaveDTO> result = await ApiCaller.PostNewData(_token,leave );
            if (result.Data != null)
            {
                ltrMessage.Text = "DAta Successfully inserted ";
            }
            else if (result.ErrorList.Count > 0)
            {
                string errors = "";
                foreach (var error in result.ErrorList)
                {
                    errors += error + " |";
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
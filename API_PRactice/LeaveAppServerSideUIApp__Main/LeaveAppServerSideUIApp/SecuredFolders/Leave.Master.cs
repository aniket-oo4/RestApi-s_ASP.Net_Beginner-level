using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LeaveAppServerSideUIApp.SecuredFolders
{
    public partial class Leave : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Session["token"].ToString()))
            {
                Session["token"] = "";
            }
            Request.Cookies["username"].Expires = DateTime.Now.AddDays(-1);
            Response.Redirect("~/Default.aspx");
        }
    }
}
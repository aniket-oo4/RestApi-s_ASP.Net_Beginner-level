using ApiHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ApiHandler;
namespace LeaveAppServerSideUIApp.SecuredFolders
{
    public partial class GetAll : System.Web.UI.Page
    {
        private string _token="" ;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Session["token"].ToString()))
            {
                _token = Session["token"].ToString();
                ltrMessage.Text = "TOken Successfully Settled";
                btnDisplayAll.Enabled = true;
            }
            else
            {
                btnDisplayAll.Enabled=false;
                ltrMessage.Text = "Token Was Not Set hence You are  not Allowed to access Data";
               
            }
     
        }


        protected async void btnDisplayAll_Click(object sender, EventArgs e)
        {
              await ApiCaller.FetchAllData(token: _token);
            //await FetchAndBindData();
              var leaves = await ApiCaller.FetchAllData(token: _token);
              if (leaves.Data!=null)
              {
                  grdvLeaveApplications.DataSource = leaves.Data;
                  grdvLeaveApplications.DataBind();
              }
              else
              {
                  if (leaves.Message=="NOT OK")
                  {
                      Response.Write("<script>alert('" + leaves.IsSuccess + " Errors:" + leaves.ErrorList[0] + "Message:" + leaves.Message + "')</script>");   
                  }
                  //Response.Write("not Any Data Comes From the Api ");
              }
            
        }
    }
}
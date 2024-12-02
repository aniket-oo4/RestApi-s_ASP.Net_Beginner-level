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

namespace FinalApp.SecuredFolder
{
     public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        
        }
        private async Task FetchAndBindData()
        {
            try
            {

                string apiUrl = "http://localhost:53842/api/LeaveApi";
                using (HttpClient client = new HttpClient())
                {
                    string bearerToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJhbmlrZXQiLCJyb2xlIjoiYW5pa2V0IiwiZXhwIjoiMjAyNC0wOC0yOVQxMDoyMjo1NS4yMTkyNDA2KzAwOjAwIn0.OgHfwamznSVGq4qV9HRWq6tg9E4XlClkaSRW5749bIA";
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);

                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        var leaves = await response.Content.ReadAsAsync<ApiHandler.ActionResult<List<LeaveDTO>>>();
                        grdvLeaveApplications.DataSource = leaves.Data;
                        grdvLeaveApplications.DataBind();
                        //ddlEmp.DataSource = employees;
                        //ddlEmp.DataTextField = "emp_name";
                        //ddlEmp.DataValueField = "emp_id";
                        //ddlEmp.DataBind();
                    }
                    else
                    {
                        throw new Exception("Error fetching data: " + response.StatusCode);
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<pre>" + ex.ToString() + "</pre>");
            }
        }

        protected async void btnDisplayAll_Click(object sender, EventArgs e)
        {
            await FetchAndBindData();
        }

        protected async void btnMyDisplay_Click(object sender, EventArgs e)
        {
            await FetchAndBindData();
        }



    }
}
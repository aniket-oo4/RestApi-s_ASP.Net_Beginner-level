
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyUI
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //private async Task FetchAndBindData()
        //{
        //    try
        //    {

        //        string apiUrl = "http://localhost:53842/api/LeaveApi";
        //        using (HttpClient client = new HttpClient())
        //        {
        //            //string bearerToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJhbmlrZXQiLCJyb2xlIjoiYW5pa2V0IiwiZXhwIjoiMjAyNC0wOC0yOFQwODoxMDoyOC4yNjg2Njg4KzAwOjAwIn0.3oLWGAqdKzCcqGs4JJeAKSRUFTt3HgmzeMdtG6mByKg";
        //            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);

        //            HttpResponseMessage response = await client.GetAsync(apiUrl);
        //            if (response.IsSuccessStatusCode)
        //            {
        //                var leaves = await response.Content.ReadAsAsync<ActionResult<List<LeaveEntity>>>();
        //                grdvLeaveApplications.DataSource = leaves.Data;
        //                grdvLeaveApplications.DataBind();
        //                //ddlEmp.DataSource = employees;
        //                //ddlEmp.DataTextField = "emp_name";
        //                //ddlEmp.DataValueField = "emp_id";
        //                //ddlEmp.DataBind();
        //            }
        //            else
        //            {
        //                throw new Exception("Error fetching data: " + response.StatusCode);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Response.Write("<pre>" + ex.ToString() + "</pre>");
        //    }
        //}


        protected void btnDisplayGrid_Click(object sender, EventArgs e)
        {

        }


    }
}
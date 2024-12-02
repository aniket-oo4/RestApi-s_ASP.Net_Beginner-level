using LeaveCore_BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LeaveApplicationAPI.DemoUI
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            grdvLeaveApplications.DataBind();
        }



        private async Task FetchAndBindData()
        {
            try
            {

                string apiUrl = "http://localhost:53842/api/LeaveApi";
                using (HttpClient client = new HttpClient())
                {
                    string bearerToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJhbmlrZXQiLCJyb2xlIjoiYW5pa2V0IiwiZXhwIjoiMjAyNC0wOS0wMlQwNjoxMjoyMi4zNzA3ODUrMDA6MDAifQ.0MwYCdJIgnLxnsAK1lPVAsMTCZAk8V0HAIGGmFfXzRI";
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",bearerToken);

                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        var leaves = await response.Content.ReadAsAsync<ActionResult<List<LeaveEntity>>>();
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

        protected async void btnDisplayAllApplications_Click(object sender, EventArgs e)
        {
            await FetchAndBindData();
        }



    }


}



//**********************************
/*
 * 
 * 
 * 
 * 
 * 
 *using LeaveCore_BL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LeaveApplicationAPI.DemoUI
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            grdvLeaveApplications.DataBind();
        }



        private async Task FetchAndBindData()
        {
            try
            {
                string apiUrl = "http://localhost:53842/api/LeaveApi";
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));             
                //HttpResponseMessage response = await client.GetAsync(apiUrl);
                    var response = client.GetAsync(string.Format("http://localhost:53842/api/LeaveApi")).Result;
                    string responseBody = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        lblDemo.Text = responseBody;
                        //lblDemo.Text = response.Content.Headers.ToString();
                        //var leaves = await response.Content.ReadAsAsync<List<LeaveCore_BL.LeaveEntity>>();
                        ActionResult<List<LeaveEntity>> leaves = JsonConvert.DeserializeObject<ActionResult<List<LeaveEntity>>>(responseBody);
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
            catch (Exception ex)
            {
                Response.Write("<pre>" + ex.ToString() + "</pre>");
            }
        }

        protected async void btnDisplayAllApplications_Click(object sender, EventArgs e)
        {
            await FetchAndBindData();
        }



    }


}
 * 
 * */


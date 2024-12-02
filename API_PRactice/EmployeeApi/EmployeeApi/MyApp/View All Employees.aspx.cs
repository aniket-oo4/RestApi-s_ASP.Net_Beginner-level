using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading.Tasks;
using System.Net.Http;
using EmployeeApi.Models;
namespace EmployeeApi.MyApp
{
    public partial class View_All_Employees : System.Web.UI.Page
    {
        protected async void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                await FetchAndBindData();
            }
        }
        private async Task FetchAndBindData()
        {
            try
            {
                string apiUrl = "http://localhost:52585/api/Employees";
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        var employees = await response.Content.ReadAsAsync<List<ClientEmployeeDTO>>();
                        grdvEmp.DataSource = employees;
                        grdvEmp.DataBind();
                        ddlEmp.DataSource = employees;
                        ddlEmp.DataTextField = "emp_name";
                        ddlEmp.DataValueField = "emp_id";
                        ddlEmp.DataBind();
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



    }
}
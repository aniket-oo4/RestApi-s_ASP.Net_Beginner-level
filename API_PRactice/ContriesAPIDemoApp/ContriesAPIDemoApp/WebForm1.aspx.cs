using CountryDataAccess;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace ContriesAPIDemoApp
{
    public partial class WebForm1 : System.Web.UI.Page
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

                string apiUrl = "http://localhost:58683/api/Countries";

                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        var countries = await response.Content.ReadAsAsync<List<CountryDTO>>();
                        grdvCountries.DataSource = countries;
                        grdvCountries.DataBind();

                        ddlCountries.DataSource = countries;
                        ddlCountries.DataTextField = "Name";
                        ddlCountries.DataValueField = "Id";
                        ddlCountries.DataBind();
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




        //public class CityDTO
        //{
        //    public int City_Id { get; set; }
        //    public string City_Name { get; set; }
        //    public int City_Code { get; set; }
        //    public string City_State { get; set; }
        //    public string City_Country { get; set; }
        //}
    }
}

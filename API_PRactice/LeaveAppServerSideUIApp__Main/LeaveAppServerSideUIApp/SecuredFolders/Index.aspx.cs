using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Http;
using System.Net.Http.Headers;
using ApiHandler;
using Newtonsoft.Json;
using System.Text;

namespace LeaveAppServerSideUIApp.SecuredFolders
{
    public partial class Index : System.Web.UI.Page
    {
        protected async void Page_Load(object sender, EventArgs e)
        {


            lblUsername.Text = Request.Cookies["username"].Value;
            string token = "", url;
            url = "http://localhost/leaveApi/api/TokenGenerator/";

            if (!IsPostBack)
            {

                if (lblUsername.Text == "aniket")
                {
                    LoginDTO requestDTO = new LoginDTO();
                    requestDTO.username = lblUsername.Text;
                    requestDTO.password = lblUsername.Text;
                    requestDTO.role = lblUsername.Text;
                    token = await GetToken(url, requestDTO);
                }
                if (!string.IsNullOrEmpty(token))
                {
                    Session["token"] = token;
                }
                else
                {
                    Session["token"] = "";
                }
                
            }

        }
        private static readonly HttpClient _httpClient = new HttpClient();

        public async Task<string> GetToken(string url, LoginDTO requestDto)
        {
            string responseString,token="";
            try
            {

                // Serialize request DTO to JSON
                string jsonPayload = JsonConvert.SerializeObject(requestDto);
                HttpContent content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                // Create HTTP POST request
                HttpResponseMessage response = await _httpClient.PostAsync(url, content); // POstAsync

                // Ensure the request was successful
                response.EnsureSuccessStatusCode();

                // Read the response content
                responseString = await response.Content.ReadAsStringAsync();
                token = JsonConvert.DeserializeObject<string>(responseString);
            }
            catch (Exception ex)
            {
                Response.Write("<script>" + "alert(Api Call is Failed  )" + "</script>");
                //Response.Write("<pre>" + ex.ToString() + "</pre>");
                Log.LogMsg(ex.ToString());
               
                
            }
            // Deserialize the response into ResponseDTO
           


            return token;



        }

    }
}
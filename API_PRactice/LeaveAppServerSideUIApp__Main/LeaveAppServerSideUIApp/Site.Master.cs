using ApiHandler;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LeaveAppServerSideUIApp
{
    public partial class SiteMaster : MasterPage
    {
        private const string AntiXsrfTokenKey = "__AntiXsrfToken";
        private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
        private string _antiXsrfTokenValue;

        protected void Page_Init(object sender, EventArgs e)
        {
            // The code below helps to protect against XSRF attacks
            var requestCookie = Request.Cookies[AntiXsrfTokenKey];
            Guid requestCookieGuidValue;
            if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
            {
                // Use the Anti-XSRF token from the cookie
                _antiXsrfTokenValue = requestCookie.Value;
                Page.ViewStateUserKey = _antiXsrfTokenValue;
            }
            else
            {
                // Generate a new Anti-XSRF token and save to the cookie
                _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
                Page.ViewStateUserKey = _antiXsrfTokenValue;

                var responseCookie = new HttpCookie(AntiXsrfTokenKey)
                {
                    HttpOnly = true,
                    Value = _antiXsrfTokenValue
                };
                if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
                {
                    responseCookie.Secure = true;
                }
                Response.Cookies.Set(responseCookie);
            }

            Page.PreLoad += master_Page_PreLoad;
        }

        protected void master_Page_PreLoad(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Set Anti-XSRF token
                ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
                ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
             
            }
            else
            {
                // Validate the Anti-XSRF token
                if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
                    || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
                {
                    throw new InvalidOperationException("Validation of Anti-XSRF token failed.");
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }


        //private static readonly HttpClient _httpClient = new HttpClient();

        //public async Task<string> GetToken( LoginDTO requestDto)
        //{
        //    string responseString, token = "", url = "http://localhost:53842/api/TokenGenerator/"; 
        //    try
        //    {

        //        // Serialize request DTO to JSON
        //        string jsonPayload = JsonConvert.SerializeObject(requestDto);
        //        HttpContent content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

        //        // Create HTTP POST request
        //        HttpResponseMessage response = await _httpClient.PostAsync(url, content); // POstAsync

        //        // Ensure the request was successful
        //        response.EnsureSuccessStatusCode();

        //        // Read the response content
        //        responseString = await response.Content.ReadAsStringAsync();
        //        token = JsonConvert.DeserializeObject<string>(responseString);
        //    }
        //    catch (Exception ex)
        //    {
        //        Response.Write("<script>" + "alert(Api Call is Failed  )" + "</script>");
        //        //Response.Write("<pre>" + ex.ToString() + "</pre>");
        //        Log.LogMsg(ex.ToString());


        //    }
        //    // Deserialize the response into ResponseDTO



        //    return token;



        //}



        protected  void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Write("<script>alert(We are Here) </script>"+txtUserName.Text+txtPassword.Text);
            if (txtUserName.Text==txtPassword.Text)
            {
                //string token = "";
                //if (txtUserName.Text == "aniket")
                //{
                //    LoginDTO requestDTO = new LoginDTO();
                //    requestDTO.username = txtUserName.Text;
                //    requestDTO.password = txtUserName.Text;
                //    requestDTO.role = txtUserName.Text;
                //    token = await GetToken( requestDTO);
                //}
                //if (!string.IsNullOrEmpty(token))
                //{
                //    Session["token"] = token;
                //}


                HttpCookie c = new HttpCookie("username");
                c.Value = txtUserName.Text;
                c.Expires = DateTime.MaxValue;
                c.Secure = true;
                Response.Cookies.Add(c);
                //Response.SetCookie(c);
                Response.Write("<script> var status='yes'</script>");
                
                Response.Redirect("SecuredFolders/Index.aspx");
                
           
            }
            else
            {
                Response.Write("Login UnsuccessFull");
                Response.Write("<script src=https://cdn.jsdelivr.net/npm/sweetalert2@11></script>  <script> var status='no'</script>");
            }
        }
    }
}
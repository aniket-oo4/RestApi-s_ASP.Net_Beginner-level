using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ApiHandler
{
    public class ApiCaller
    {

        public static async Task<ActionResult<List<LeaveDTO>>> FetchAllData(string token)
        {
            try
            {

                string apiUrl = "http://localhost/leaveApi/api/LeaveApi";
                using (HttpClient client = new HttpClient())
                {
                    //string bearerToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJhbmlrZXQiLCJyb2xlIjoiYW5pa2V0IiwiZXhwIjoiMjAyNC0wOC0yOVQxMToyMzo0OC41OTE0NTU2KzAwOjAwIn0.lQuJ_A5WgQku2teM7y2-CgeIGOgV_0H1JG307ZLV7ZA";
                    string bearerToken = token;
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);

                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsAsync<ApiHandler.ActionResult<List<LeaveDTO>>>(); // Json will be converted inot ActionResult<T> in T there is a List of Leave Application DTO's 
                        return result;
                    }
                    else if (response.StatusCode.ToString()=="Unauthorized" )
                    {
                       var result= new ActionResult<List<LeaveDTO>>();
                        result.Data=null;
                        result.IsSuccess=false;
                        result.ErrorList.Add("UnAuthorrize Access Attempt");
                        result.Message="NOT OK";
                        return result;
                    }
                    else
                    {
                        throw new Exception("Error fetching data: " + response.StatusCode);
                    }
                    
                }
            }
            catch (Exception ex)
            {
                //Response.Write("<pre>" + ex.ToString() + "</pre>");
                Log.LogMsg(ex.ToString());
                Console.WriteLine("Exception occured and logged into the file ");
            }
            return null;
        }
        public static async Task<ActionResult<LeaveDTO>> FetchDataById(string token,int id)
        {
            try
            {

                string apiUrl = "http://localhost/leaveApi/api/LeaveApi/"+id;
                using (HttpClient client = new HttpClient())
                {
                    //string bearerToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJhbmlrZXQiLCJyb2xlIjoiYW5pa2V0IiwiZXhwIjoiMjAyNC0wOC0yOVQxMToyMzo0OC41OTE0NTU2KzAwOjAwIn0.lQuJ_A5WgQku2teM7y2-CgeIGOgV_0H1JG307ZLV7ZA";
                    string bearerToken = token;
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);

                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsAsync<ApiHandler.ActionResult<LeaveDTO>>(); // Json will be  read from api and converted into ActionResult<T> in T there is a List of Leave Application DTO's 
                        return result;
                    }
                    else if (response.StatusCode.ToString() == "Unauthorized")
                    {
                        var result = new ActionResult<LeaveDTO>();
                        result.Data = null;
                        result.IsSuccess = false;
                        result.ErrorList.Add("UnAuthorrize Access Attempt");
                        result.Message = "NOT OK";
                        return result;
                    }
                    else
                    {
                        throw new Exception("Error fetching data: " + response.StatusCode);
                    }

                }
            }
            catch (Exception ex)
            {
                //Response.Write("<pre>" + ex.ToString() + "</pre>");
                Log.LogMsg(ex.ToString());
                Console.WriteLine("Exception occured and logged into the file ");
            }
            return null;
        }
        public static async Task<ActionResult<LeaveDTO>> PostNewData(string token, LeaveDTO leave)
        {

            try
            {

                string apiUrl = "http://localhost/leaveApi/api/LeaveApi";
                using (HttpClient client = new HttpClient())
                {
                    //string bearerToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJhbmlrZXQiLCJyb2xlIjoiYW5pa2V0IiwiZXhwIjoiMjAyNC0wOC0yOVQxMToyMzo0OC41OTE0NTU2KzAwOjAwIn0.lQuJ_A5WgQku2teM7y2-CgeIGOgV_0H1JG307ZLV7ZA";
                    string bearerToken = token;
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);
                    var json = JsonConvert.SerializeObject(leave); // converting object to json
                    var content = new StringContent(json, Encoding.UTF8, "application/json");


                    HttpResponseMessage response = await client.PostAsync(apiUrl,content);
                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsAsync<ApiHandler.ActionResult<LeaveDTO>>(); // Json will be  read from api and converted into ActionResult<T> in T there is a List of Leave Application DTO's 
                        return result;
                    }
                    else if (response.StatusCode.ToString() == "Unauthorized")
                    {
                        var result = new ActionResult<LeaveDTO>();
                        result.Data = null;
                        result.IsSuccess = false;
                        result.ErrorList.Add("UnAuthorrize Access Attempt");
                        result.Message = "NOT OK";
                        return result;
                    }
                    else
                    {
                        throw new Exception("Error fetching data: " + response.StatusCode);
                    }

                }
            }
            catch (Exception ex)
            {
                //Response.Write("<pre>" + ex.ToString() + "</pre>");
                Log.LogMsg(ex.ToString());
                Console.WriteLine("Exception occured and logged into the file ");
            }
            return null;

        }
    
    }
}

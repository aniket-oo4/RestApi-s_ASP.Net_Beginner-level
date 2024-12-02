using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace WeatherApi.Controllers
{

    public class HourlyDTO
    {
        public string hour { get; set; }
        public float temp { get; set; }
        public float rain { get; set; }
        public float wind { get; set; }
        public string clouds { get; set; }
        //      const hourlyData = [
        //  { hour: '6am', temp: 14, rain: 0, wind: 3.8, clouds: 'few clouds' },
        //  { hour: '7am', temp: 14, rain: 0, wind: 3.8, clouds: 'scattered clouds' },
        //  { hour: '8am', temp: 15, rain: 0.27, wind: 3.9, clouds: 'light rain' },
        //  { hour: '9am', temp: 16, rain: 0.13, wind: 3.6, clouds: 'light rain' },
        //  { hour: '10am', temp: 17, rain: 0.27, wind: 2.9, clouds: 'light rain' },
        //  { hour: '11am', temp: 18, rain: 1.23, wind: 3.6, clouds: 'moderate rain' },
        //  { hour: '12pm', temp: 19, rain: 0.3, wind: 5.7, clouds: 'light rain' },
        //  { hour: '1pm', temp: 20, rain: 0, wind: 5.6, clouds: 'overcast clouds' },
        //  { hour: '2pm', temp: 21, rain: 0, wind: 6.2, clouds: 'overcast clouds' }
        //];


    }
    public class WeatherReportController : ApiController
    {
        //
        // GET: /WeatherReport/

        // GET api/values
        public List<HourlyDTO> Get()
        {
            return WeatherReportController.GetHourlyData(); 
        }

        public static List<HourlyDTO> GetHourlyData()
        {
            List<HourlyDTO> data = new List<HourlyDTO>(){
                new HourlyDTO() { hour = "6am", temp = 28, rain = 0, wind = 3.8f, clouds = "few clouds" },
           new HourlyDTO(){ hour= "7am", temp= 14, rain= 0, wind= 3.8f, clouds= "scattered clouds" },
           new HourlyDTO(){ hour= "8am", temp= 10, rain= 0.27f, wind= 3.9f, clouds= "light rain" },
           new HourlyDTO(){ hour= "9am", temp= 16, rain= 0.13f, wind= 3.6f, clouds= "light rain" },
           new HourlyDTO(){ hour= "10am", temp= 25, rain= 0.27f, wind= 2.9f, clouds= "light rain"},
           new HourlyDTO(){ hour= "11am", temp= 8, rain= 1.23f, wind= 3.6f, clouds= "moderate rain" },
           new HourlyDTO(){ hour= "12pm", temp= 19, rain= 0.3f, wind= 5.7f, clouds= "light rain" },
           new HourlyDTO(){ hour= "1pm", temp= 15, rain= 0, wind= 5.6f, clouds= "overcast clouds" },
           new HourlyDTO(){ hour= "2pm", temp= 17, rain= 0, wind= 6.2f, clouds= "overcast clouds" } ,
            new HourlyDTO(){ hour= "3pm", temp= 21, rain= 1.65f, wind= 2.2f, clouds= "light clouds" }
            };
         
           data.Add(new HourlyDTO() { hour = "4pm", temp = 5, rain = 33, wind = 10.2f, clouds = "super clouds" });
            return data;
        }
    }
}
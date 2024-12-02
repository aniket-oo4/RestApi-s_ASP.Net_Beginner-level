using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiHandler
{
    public static class Log
    {

        const string filePath = @"C:\Users\Aniket.Varkhade\Desktop\aniket\4ASP_WebAPI\PrasadSirSessions\API_PRactice\LeaveAppServerSideUIApp\ErrorLogs.txt"; // path for passing to the StreamWriter Object 
        static StreamWriter streamWriter;
        public static void LogMsg(string txt) 
        {
            
            
                streamWriter = File.AppendText(filePath);
                streamWriter.WriteLine(DateTime.Now.ToShortDateString() + ": message: " + txt);
                streamWriter.Close();       
        }  
    }
}


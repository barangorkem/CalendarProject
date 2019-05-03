using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CalendarAPI.Log
{
    public class LogWrite
    {
        //private static string m_exePath = @"D:\Projelerim\CalendarProject-NetCore\CalendarAPI\Log";

        private static string m_exePath = string.Empty;
        public static void LogMessage(string logMessage)
        {
            m_exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            if (!System.IO.File.Exists(m_exePath + "\\" + "log.txt"))
                System.IO.File.Create(m_exePath + "\\" + "log.txt");

            try
            {
                using (StreamWriter w = System.IO.File.AppendText(m_exePath + "\\" + "log.txt"))
                    AppendLog(logMessage, w);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        private static void AppendLog(string logMessage, TextWriter txtWriter)
        {
            try
            {
                txtWriter.Write("\r\nLog Entry : ");
                txtWriter.WriteLine("{0} {1}:{2}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString(), logMessage);
            
                txtWriter.WriteLine("-------------------------------");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_7.controller_services
{
    class LogController
    {
        public static void WriteExceptionLog(string message)
        {
            using (StreamWriter writer = File.AppendText(@"log.txt"))
            {
                writer.WriteLine(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + "\t" + message);
            }
        }
    }
}

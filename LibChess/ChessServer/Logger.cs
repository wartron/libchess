using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server
{
    static class Logger
    {
        static public void LogEvent(string Message)
        {
            Console.WriteLine(DateTime.Now + ": " + Message);
        }
    }
}

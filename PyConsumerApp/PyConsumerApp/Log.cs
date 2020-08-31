using System;
using System.Collections.Generic;
using System.Text;

namespace PyConsumerApp
{
    public class Log
    {
        public static void Debug(string tag, string message)
        {
            string message1 = string.Format("{0}-{1}-{2}-{3}", "PYCONSUMER", "DEBUG", tag, message);
            System.Console.WriteLine(message1);
            System.Diagnostics.Debug.WriteLine("",message1);
        }
    }
}

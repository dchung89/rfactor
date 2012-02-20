using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SampleApplication
{
    class Driver
    {
        static void Main(string[] args)
        {
            string message = "Hello, World!";
            Program prog = new Program(message);
            prog.Rename(message);
            prog.Message("HELLO!");
        }
    }
}

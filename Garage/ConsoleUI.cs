using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    public class ConsoleUI : IUI
    {
        public string GetInput(string message)
        {
            Console.Write(message + " ");
            return Console.ReadLine();
         }
        public void DisplayOutput(string message)
        {
            Console.WriteLine(message);
        }
    }
}

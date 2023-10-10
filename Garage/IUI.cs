using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    public interface IUI
    {
        string GetInput(string message);
        void DisplayOutput(string message);
    }
}

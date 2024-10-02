using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace @if
{
    class Program
    {
        static void Main(string[] args)
        {
            bool b = true;
            if (b) Console.WriteLine("Ez az igaz ág");
            else Console.WriteLine("Ez a hamis ág");


            b = false;
            if (b) Console.WriteLine("Ez az igaz ág");
            else Console.WriteLine("Ez a hamis ág");


        }
    }
}

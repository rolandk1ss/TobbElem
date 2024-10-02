using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prefix
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 10,
                y = 20;
            Console.WriteLine($"Az x eredeti értéke {x}");
            Console.WriteLine($"Az értéke '++x'iratással{++x} ");
            Console.WriteLine($"az x értéke kiíratás után: {x}");
            Console.WriteLine($"\nAz y eredeti értéke {y}");
            Console.WriteLine($"Az értéke '++y'iratással{++y} ");
            Console.WriteLine($"az y értéke kiíratás után: {y}");


            Console.ReadKey();
        }
    }
}

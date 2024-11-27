using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaromszogTipusaOOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Add meg a háromszög három oldalát:");
            Console.Write("a: ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("b: ");
            int b = int.Parse(Console.ReadLine());
            Console.Write("c: ");
            int c = int.Parse(Console.ReadLine());

            HTipus haromszog = new HTipus(a, b, c);
            Console.WriteLine($"Érvényes háromszög: {haromszog.ErvenyesHaromszog()}");
            Console.WriteLine($"Derékszögű háromszög: {haromszog.DerekszoguHaromszog()}");
            Console.WriteLine($"Egyenlő szárú háromszög: {haromszog.EgyenloSzaruHaromszog()}");
            Console.WriteLine($"Egyenlő oldalú háromszög: {haromszog.EgyenloOldaluHaromszog()}");
            Console.WriteLine($"Terület: {haromszog.Terulet()}");

            Console.ReadLine(); // Hozzáadva, hogy a konzolablak nyitva maradjon
        }
    }
}



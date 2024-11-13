using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tegla
{
    class Program
    {
        static void Main(string[] args)
        {
            Teglalapszamitasok teglaszam = new Teglalapszamitasok();
            teglaszam.ReadAoldal(15);
            teglaszam.ReadBoldal(25);
            teglaszam.TeruletSzam();
            teglaszam.KeruletSzam();
            Console.WriteLine($"A kerület az : {teglaszam.GetKerulet()} A terület: {teglaszam.GetTerulet()}");
            Console.ReadKey();



            Console.WriteLine("Az a oldal: 8cm,A b oldal: 18cm és A c oldal: 18cm");
            Téglatest teglatest = new Téglatest();
            teglatest.ReadAoldal(8);
            teglatest.ReadBoldal(18);
            teglatest.SetMagassag(18);
            teglatest.TerfogatSzamit();
            teglatest.FelszinSzamit();

            Console.WriteLine("A téglatest felszíne:  "+teglatest.ReturnFelszin()+"cm2");
            Console.WriteLine("A téglatest térfogata:  " + teglatest.ReturnTerfogat() + "cm3");
            Console.ReadKey();


        }
    }
}

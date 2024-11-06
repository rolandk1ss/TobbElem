using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace korhasab
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 1. objektum
            kor k1 = new kor();
            k1.readSugar(15.0);
            k1.SetKerulet();
            k1.SetTerulet();
            Console.WriteLine($"{k1.GetSugar()}sugarú kör kerülete: {k1.GetKerulet()},Területe: {k1.GetTerulet()}") ;
            #endregion EOf 1. objektum
            #region 2.objektum
            kor k2 = new kor(28.7);
            k2.SetKerulet();
            k2.SetTerulet();
            Console.WriteLine($"{k2.GetSugar()}sugarú kör kerülete: {k2.GetKerulet()},Területe: {k2.GetTerulet()}");
            #endregion Eof 2. objektum
            Console.ReadKey();

            #region kor2 hasznalata
            kor2 k21 = new kor2(24.5);
            Console.WriteLine($"A kör adaitai: Sugár={k21.getsugar()},\n Kerülete= {k21.getkerulet()},\n Területe= {k21.getterulet()} ");
            #endregion kor2
            Console.ReadKey();

            #region henger szamitas
            henger h1 = new henger(15, 30);
            Console.WriteLine($"\n A henger adatai: Sugara=  {h1.GetSugar()},\n Magassága= {h1.gettmagassag()},\n Alapterülete= {h1.GetTerulet()},\n Térfogata= {h1.getterfogat()}");
            #endregion henger
            Console.ReadKey();

        }
    }
}

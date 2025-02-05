using System;

namespace MyApplication
{
    class Program
    {
        struct Adat
        {
            public int helyezes;
            public string nev;
            public string orszag;
            public int nyeremeny;



        }
        static void Main(string[] args)
        {
            string[] kategoriak = File.ReadAllLines("snooker.txt");

            int i;

            for (i = 0; i < kategoriak.Length; i++)
            {
                Console.WriteLine(kategoriak[i]);
            }

            Adat[] adatok = new Adat[kategoriak.Length];

            for (i = 0; i < kategoriak.Length; i++)
            {
                string[] sorok = kategoriak[i].Split(';');
                adatok[i].helyezes = int.Parse(sorok[0]);
                adatok[i].nev = sorok[1];
                adatok[i].orszag = sorok[2];
                adatok[i].nyeremeny = int.Parse(sorok[3]);



            }



            Console.WriteLine("Az adatok tömb elemei:");

            for (i = 0; i < kategoriak.Length; i++)
            {
                Console.WriteLine("{0}   {1}   {2}  {3}  ", adatok[i].helyezes, adatok[i].nev, adatok[i].orszag, adatok[i].nyeremeny);
            }
            Console.WriteLine(kategoriak.Length);

            double atlag;
            int osszeg = 0;
            for(i=0;i<kategoriak.Length;i++)
            {
                osszeg += adatok[i].nyeremeny;
            }
            atlag = osszeg;
                
                    





            Console.ReadKey();
        }
    }
}

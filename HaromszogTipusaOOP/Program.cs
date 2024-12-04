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

            try

            {

                Console.WriteLine("Adja meg az első oldalt:");

                int a = int.Parse(Console.ReadLine());

                Console.WriteLine("Adja meg a második oldalt:");

                int b = int.Parse(Console.ReadLine());

                Console.WriteLine("Adja meg a harmadik oldalt:");

                int c = int.Parse(Console.ReadLine());
                HTipus haromszog = new HTipus(a, b, c);

                Console.WriteLine($"Érvényes háromszög: {haromszog.ErvenyesHaromszog()}");

                Console.WriteLine($"Derékszögű háromszög: {haromszog.DerekszoguHaromszog()}");

                Console.WriteLine($"Egyenlő szárú háromszög: {haromszog.EgyenloSzaruHaromszog()}");

                Console.WriteLine($"Egyenlő oldalú háromszög: {haromszog.EgyenloOldaluHaromszog()}");

                Console.WriteLine($"Terület: {haromszog.Terulet()}");

            }

            catch (FormatException)

            {

                Console.WriteLine("Hibás adatbevitel! Kérjük, számokat adjon meg.");

            }

            catch (Exception ex)

            {

                Console.WriteLine($"Hiba történt: {ex.Message}");

            }
            Console.WriteLine("Nyomjon meg egy billentyűt a kilépéshez...");

            Console.ReadLine();

        }

    }

}



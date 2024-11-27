using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kivetel
{
    class Kivetel
    {
        public void KivKezNincs()
        {
            Console.WriteLine("Nincs kivetelkezeles");
            int szam = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("A beírt szám: {0}",szam);

           
        }
        public void KivKezAlt()
        {
            Console.WriteLine("Hiba");
            try
            {
                int szam = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(("A beírt szám: {0}");

            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString();
            }
            Console.ReadKey();
        }
    }
}

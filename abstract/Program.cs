using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace @abstract
{



    abstract class Shape
    {
        //Abstract metódus -nincs implementáció
        //Ennek a kódját a leszármazottban kötelező megírni!!!!!!!!!!!!

        public abstract double GetArea();

        //Normál metódus - van implementáció

        public void DisplayShape()
        {
            Console.WriteLine("Ez egy alakzat");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            /*Ez a példa az abstract kulcsszó használatát mutatjabe
             * Az abstract olyan osztályokat és metódusokat jelölünk, amelyeket nem lehet közvetlenül példányosítani,
             * illetve végrehajtani. Az abstract osztályokat alapként használják más osztályok számára, míg az absztakt metódusok
             * deklarációkat tartalmaznak, de nem adnak meg implementációkat.
             * 
             * Fontos jellemzők:
             * Absztrakt osztály: Csak a származtatott osztályokon keresztül használható. Tartalmazhat abstract és nem abstract (működő) metódusokat is.
             * Absztrakt metódus: Csak abstract osztályban lehet, és a származtatott osztálynak kötelező megvalósítania.
             */
        }
    }


    class Circle : Shape
    {
        private double sugar;

        public Circle(double r)
        {
            this.sugar = r;
        }

        // Abstract metódus implementálása
        public override double GetArea()
        {
            return Math.PI * sugar * sugar;
        }
    }
}

helyi menü tartozik hozzá
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace korhasab
{
    class kor
    {
        //Az osztály feladata a sugárból kiszámitja a kör területét és kerületét

        //Osztályváltozók

        //A Konstruktor objektum példát hoz létre
        //metódus, van visszatérési értékük
        //formális paraméter és akutális paraméter


        protected double sugar,
        kerulet,
        terulet;


        public kor() { }
        public kor(double r) {

            this.sugar = r;
        }
        public void readSugar(double r)
        {
            this.sugar = r;
        }

        public void SetKerulet()
        {
            this.kerulet = 2 * this.sugar * Math.PI;
        }
        public void SetTerulet()
        {

            double eredmeny1,eredmeny2 = 0.0;
            
           eredmeny1 = this.terulet = this.sugar  * this.sugar * Math.PI;

            eredmeny2 = Math.Pow(this.sugar, 2) * Math.PI;
            if(eredmeny1 == eredmeny2)
            {
                this.terulet = eredmeny2;
            }
            else
            {
                Console.WriteLine($"Eredmény: {eredmeny1}!= Eredmény2 {eredmeny2}");
            }
        }
        public double GetKerulet() { return this.kerulet; }

        public double GetTerulet() { return this.terulet; }

        public double GetSugar() { return this.sugar; }
    }
}

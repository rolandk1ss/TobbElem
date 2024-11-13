using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tegla
{
    class Teglalapszamitasok
    {
        protected double aoldal,
            boldal,
            terulet,
            kerulet;

        public Teglalapszamitasok()
        {

        }
        public Teglalapszamitasok(double a, double b)
        {
            this.aoldal = a;
            this.boldal = b;
        }
       
        public void ReadAoldal(double aoldal)
        {
            this.aoldal = aoldal;
        }
        public void ReadBoldal(double boldal)
        {
            this.boldal = boldal;
        }
        
        public void TeruletSzam()
        {
            this.terulet = this.aoldal * this.boldal;
        }
        public void KeruletSzam()
        {
            this.kerulet = (this.aoldal + this.boldal) * 2;
        }
        public double GetKerulet() { return kerulet; }
        public double GetTerulet() { return terulet; }


    }

}

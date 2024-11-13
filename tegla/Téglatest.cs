using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tegla
{
    class Téglatest : Teglalapszamitasok
    {
        private double
            magassag,
            terfogat,
            felszin;

        public Téglatest()
        {

        }
        public Téglatest(double magas)
        {
            this.magassag = magas;
        }
        public void SetMagassag(double m)
        {
            this.magassag = m;
        }
            

        public double ReturnMagassag()
        {
            return this.magassag;
        }
        public double ReturnTerfogat()
        {
            return this.terfogat;
        }
        public double ReturnFelszin()
        {
            return this.felszin;
        }

        public void TerfogatSzamit()
        {
            this.terfogat = this.aoldal * this.boldal * this.magassag;
        }

        public void FelszinSzamit()
        {
            this.felszin = 2 * (this.aoldal * this.boldal + this.aoldal * this.magassag + this.boldal * this.magassag);
        }


    }
}

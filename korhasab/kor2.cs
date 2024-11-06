using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace korhasab
{
    class kor2
    {
        //osztályípus
        private double sugar, kerulet, terulet;

        //konstruktor
        public kor2() { }

        public kor2(double r)
        {
            this.sugar = r;
            szamitasok();
        }

        //metódusok
        public void SetSugar(double r)
        {
            this.sugar = r;
            szamitasok();
        }

        private void kalkerulet()
        {
            this.kerulet = 2 *this.sugar * Math.PI;
        }

        private double kalkerulet(double r)
        {
            return Math.Pow(r, 2) * Math.PI;
        }
        
        private void szamitasok()
        {
            kalkerulet();
            this.terulet = kalkerulet(this.sugar);

        }
        public double getkerulet()
        {
            return this.kerulet;
        }
        public double getterulet()
        {
            return this.terulet;
        }
        public double getsugar()
        {
            return this.sugar;
        }
    }

}

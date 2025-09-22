using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autok
{
    class Auto
    {
        public string Rendszam;
        public string Tipus;
        public string Szin;
        public int Evjarat;
        public int Ar;
        public string Hasznalo;

        public Auto(string rendszam, string tipus, string szin, int evjarat, int ar, string hasznalo)
        {
            Rendszam = rendszam;
            Tipus = tipus;
            Szin = szin;
            Evjarat = evjarat;
            Ar = ar;
            Hasznalo = hasznalo;
        }
    }
}
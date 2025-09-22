using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autokHadarM
{
    class Auto
    {
        public string Rendszam;
        public string Tipus;
        public string Szin;
        public int Evjarat;
        public int Ar;
        public string Hasznalo;
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Auto> autok = new List<Auto>();

            try
            {
                string[] sorok = File.ReadAllLines("autok.txt");

                foreach (var sor in sorok)
                {
                    string[] adatok = sor.Split('\t');
                    Auto auto = new Auto
                    {
                        Rendszam = adatok[0],
                        Tipus = adatok[1],
                        Szin = adatok[2],
                        Evjarat = Convert.ToInt32(adatok[3]),
                        Ar = Convert.ToInt32(adatok[4]),
                        Hasznalo = adatok[5]
                    };
                    autok.Add(auto);
                }

                Console.WriteLine($"Az állomány {autok.Count} autó adatait tartalmazza.");

                List<string> kulonbozoTipusok = new List<string>();
                foreach (var auto in autok)
                {
                    if (!kulonbozoTipusok.Contains(auto.Tipus))
                    {
                        kulonbozoTipusok.Add(auto.Tipus);
                    }
                }

                Console.WriteLine("\nTípusonkénti statisztika:");
                foreach (var tipus in kulonbozoTipusok)
                {
                    int db = 0;
                    int osszErtek = 0;
                    foreach (var auto in autok)
                    {
                        if (auto.Tipus == tipus)
                        {
                            db++;
                            osszErtek += auto.Ar;
                        }
                    }
                    Console.WriteLine($"{tipus} - {db} db, összérték: {osszErtek} Ft");
                }

                Auto legdragabbAuto = autok[0];
                foreach (var aktualisAuto in autok)
                {
                    if (aktualisAuto.Ar > legdragabbAuto.Ar)
                    {
                        legdragabbAuto = aktualisAuto;
                    }
                }

                Console.WriteLine("\nLegdrágább autó adatai:");
                Console.WriteLine($"{legdragabbAuto.Rendszam}, {legdragabbAuto.Tipus}, {legdragabbAuto.Szin}, {legdragabbAuto.Evjarat}, {legdragabbAuto.Ar} Ft, {legdragabbAuto.Hasznalo}");

                using (StreamWriter sw = new StreamWriter("kiFajl.txt"))
                {
                    foreach (var auto in autok)
                    {
                        sw.WriteLine($"{auto.Tipus}\t{auto.Szin}\t{auto.Hasznalo}");
                    }
                }

                Console.WriteLine("\nA kiírás sikeresen megtörtént a kiFajl.txt állományba.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hiba történt a feldolgozás során: " + ex.Message);
            }
        }
    }
}
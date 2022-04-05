using System;
using System.Collections;
using System.Collections.Generic;

namespace App5._4._2022
{
    abstract class DopravniProstredek
    {
        public string Pohon { get; set; }
        public double Dojezd { get; set; }
        public double MaximalniRychlost {get; set;}
        public DopravniProstredek(string pohon, double dojezd, double maxrychlost)
        {
            Pohon = pohon;
            Dojezd = dojezd;
            MaximalniRychlost = maxrychlost;
        }

    }
    public interface ILokalizovatele
    {
        public double X { get; set; }
        public double Y { get; set; }
    }
    public interface IProdejne
    {
        public int OdhadniCena { get; set; }
        public DateTime TK { get; set; }
    }

    class Auto : DopravniProstredek, ILokalizovatele, IProdejne, IComparable
    {
        public double X { get; set; }
        public double Y { get; set; }
        public int OdhadniCena { get; set; }
        public DateTime TK { get; set; }

        public int CompareTo(Auto other) //https://www.codeproject.com/Articles/42839/Sorting-Lists-using-IComparable-and-IComparer-Inte odkaz na webovku na CompareTo
        {
            if (this.MaximalniRychlost < other.MaximalniRychlost)
            {
                return -1;
            }
            else if (this.MaximalniRychlost == other.MaximalniRychlost)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
        public Auto(string pohon, double dojezd, double maxrychlost, double x, double y, int odhadnicena, DateTime tk) : base(pohon, dojezd, maxrychlost)
        {
            X = x;
            Y = y;
            OdhadniCena = odhadnicena;
            TK = tk;
        }
        public override string ToString()   
        {
            return $"Auto má {Pohon} pohon, dojezd {Dojezd} km, maximílní rychlost {MaximalniRychlost} km/h," + 
                   $"navigační souřadnice {X},{Y}, odhadní cenu {OdhadniCena},- a TK do dne {TK.ToString("d")}";
        }
    }
    class Kolo : DopravniProstredek, ILokalizovatele
    {
        public double X { get; set; }
        public double Y { get; set; }
        public Kolo (string pohon, double dojezd, double maxrychlost, double x, double y) : base (pohon, dojezd, maxrychlost)
        {
            X = x;
            Y = y;
        }
        public override string ToString()
        {
            return $"Kolo má {Pohon} pohon, dojezd {Dojezd} km, maximílní rychlost {MaximalniRychlost} km/h a navigační souřadnice {X},{Y}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Auto a1 = new Auto ("přední", 400.0, 210.0, 1.0, 2.0, 500000, new DateTime(2022, 6, 5));
            Auto a2 = new Auto("4x4", 500.0, 250.0, 3.0, 4.0, 750000, new DateTime(2025, 7, 9));
            Kolo k1 = new Kolo("zadní", 50.0, 50.0, 5.0, 6.0);

            List<ILokalizovatele> seznam = new List<ILokalizovatele>();
            seznam.Add(a1);
            seznam.Add(a2);
            seznam.Add(k1);

            foreach (var item in seznam)
            {
                Console.WriteLine(item);
            }
        }
    }
}


using System.Collections.Generic;

namespace CarCatalog
{
    class Car
    {
        public string Marka { get; set; }
        public string Model { get; set; }
        public string Skrzynia { get; set; }
        public int Rocznik { get; set; }
        public int Przebieg { get; set; }
        public double Pojemnosc { get; set; }

        public Car(string marka, string model, string skrzynia, int rocznik, int przebieg, double pojemnosc)
        {
            Marka = marka;
            Model = model;
            Skrzynia = skrzynia;
            Rocznik = rocznik;
            Przebieg = przebieg;
            Pojemnosc = pojemnosc;
        }


        public override string ToString()
        {
            string opis = "Marka - " + Marka + " Model - " + Model + " Pojemnosc - " + Pojemnosc + " Przebieg - " + Przebieg + " Rocznik - " + Rocznik + " Skrzynia - " + Skrzynia + " ";
            return opis;
        }


        public static bool operator <(Car c1, Car c2)
        {
            return c1.Pojemnosc < c2.Pojemnosc;
        }

        public static bool operator >(Car c1, Car c2)
        {
            return c1.Pojemnosc > c2.Pojemnosc;
        }


        public static bool operator <=(Car c1, Car c2)
        {
            return c1.Przebieg < c2.Przebieg;
        }

        public static bool operator >=(Car c1, Car c2)
        {
            return c1.Przebieg > c2.Przebieg;
        }
    }
}

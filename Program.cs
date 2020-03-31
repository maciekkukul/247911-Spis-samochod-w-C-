using System;
using System.Collections.Generic;
using static System.Console;

namespace CarCatalog
{
    class Catalog
    {
        List<Car> catalog = new List<Car>();

        static void Main(string[] args)
        {
            bool dziala = true;
            Catalog myCatalog = new Catalog();

            while (dziala)
            {
                int operacja = myCatalog.ReadIntInstruction();

                switch (operacja)
                {
                    case 1:
                        myCatalog.catalog.Add(myCatalog.ReadCar());
                        break;
                    case 2:
                        myCatalog.WriteCars();
                        break;
                    case 3:
                        myCatalog.WriteCarsIf();
                        break;
                    case 4:
                        myCatalog.WriteExCar();
                        break;
                    case 5:
                        myCatalog.RemoveCar();
                        break;
                    case 6:
                        myCatalog.SortCatalog();
                        break;
                    case 7:
                        myCatalog.catalog = FileManager.ReadFromFile();
                        break;
                    case 8:
                        FileManager.WriteToFile(myCatalog.catalog);
                        break;
                    case 9:
                        dziala = false;
                        break;


                    default:
                        dziala = true;
                        break;
                }
            }

            ReadLine();
        }

        private Car ReadCar()
        {
            string marka = ReadString("Podaj markę:");
            string model = ReadString("Podaj model:");
            string skrzynia = ReadString("Podaj skrzynię:");

            int rocznik = ReadInt("Podaj rocznik:");
            int przebieg = ReadInt("Podaj przebieg:");

            double pojemnosc = ReadDouble("Podaj pojemnosc");

            return new Car(marka, model, skrzynia, rocznik, przebieg, pojemnosc);
        }

        private void WriteCars()
        {
            foreach(Car car in catalog)
            {
                WriteLine(car.ToString());
            }
            WriteLine();
        }

        private void WriteCarsIf()
        {
            WriteLine("Filtr wg:\n1 - Pojemnosci\n2 - Przebiegu");
            int rodzaj = ReadInt("Rodzaj");
            while (rodzaj < 0 || rodzaj > 2)
            {
                rodzaj = ReadInt("Rodzaj");
            }

            WriteLine("Wyswietlaj\n1 - Wieksze od wartosci zadanej\n2 - Mniejsze od wartosci zadanej");
            int wieksze = ReadInt("Rodzaj");
            while (wieksze < 0 || wieksze > 2)
            {
                wieksze = ReadInt("Rodzaj");
            }

            int wartosc = ReadInt("Zadana większa od zera");
            while (wieksze < 0)
            {
                wartosc = ReadInt("Zadana większa od zera");
            }

            if(rodzaj == 1) //Po pojemnosci
            {
                if(wieksze == 1) //Wieksze od
                {
                    foreach(Car car in catalog)
                    {
                        if(car.Pojemnosc > wartosc)
                        {
                            WriteLine(car.ToString());
                        }
                    }
                }
                else //Mniejsze od
                {
                    foreach (Car car in catalog)
                    {
                        if (car.Pojemnosc < wartosc)
                        {
                            WriteLine(car.ToString());
                        }
                    }
                }
            }
            else //Po przebiegu
            {
                if (wieksze == 1) //Wieksze od
                {
                    foreach (Car car in catalog)
                    {
                        if (car.Przebieg > wartosc)
                        {
                            WriteLine(car.ToString());
                        }
                    }
                }
                else //Mniejsze od
                {
                    foreach (Car car in catalog)
                    {
                        if (car.Przebieg < wartosc)
                        {
                            WriteLine(car.ToString());
                        }
                    }
                }
            }

        }

        private void WriteExCar()
        {
            int carNumber = ReadInt("Podaj numer auta");
            while(carNumber<0 || catalog.Count < carNumber)
            {
                carNumber = ReadInt("Podaj numer auta");
            }
            WriteLine(catalog[carNumber-1].ToString());
            WriteLine();
        }

        private void RemoveCar()
        {
            int carNumber = ReadInt("Podaj numer auta");
            while (carNumber < 0 || catalog.Count < carNumber)
            {
                carNumber = ReadInt("Podaj numer auta");
            }
            catalog.RemoveAt(carNumber - 1);
            WriteLine();
        }

        private void SortCatalog()
        {
            WriteLine("Posortuj wg:\n1 - Pojemnosci\n2 - Przebiegu");
            int operacja = ReadInt("Rodzaj");
            while (operacja < 0 || operacja > 2)
            {
                operacja = ReadInt("Rodzaj");
            }
            WriteLine();
            if(operacja == 1)
            {
                SortPojemnosc();
            }
            else
            {
                SortPrzebieg();
            }

        }

        private void SortPojemnosc()
        {
            catalog.Sort(delegate (Car c1, Car c2)
            {
                if (c1 < c2) return -1;
                else return 1;
            });
        }

        private void SortPrzebieg()
        {
            catalog.Sort(delegate (Car c1, Car c2)
            {
                if (c1 <= c2) return -1;
                else return 1;
            });
        }

        private string ReadString(string kom)
        {
            WriteLine(kom);
            string wejscie = ReadLine(); 
            while (wejscie == null)
            {
                WriteLine(kom);
                wejscie = ReadLine();
            }

            return wejscie;
        }

        private double ReadDouble(string kom)
        {
            double liczba = 0;
            WriteLine(kom);
            string wejscie = ReadLine(); ;
            double.TryParse(wejscie, out liczba);
            while (liczba == 0)
            {
                WriteLine(kom);
                wejscie = ReadLine();
                double.TryParse(wejscie, out liczba);

            }

            return liczba;
        }

        private int ReadInt(string kom)
        {
            int liczba = 0;
            WriteLine(kom);
            string wejscie = ReadLine(); ;
            int.TryParse(wejscie, out liczba);
            while (liczba == 0)
            {
                WriteLine(kom);
                wejscie = ReadLine();
                int.TryParse(wejscie, out liczba);

            }

            return liczba;
        }

        private int ReadIntInstruction()
        {
            WriteLine("Podaj operację:\n");
            WriteLine("1 - Dodaj auto");
            WriteLine("2 - Wyswietl auta");
            WriteLine("3 - Wyswietl warunkowo");
            WriteLine("4 - Wyswietl konkretne auto");
            WriteLine("5 - Usun auto");
            WriteLine("6 - Posortuj liste aut");
            WriteLine("7 - Wczytaj auta z pliku");
            WriteLine("8 - Zapisz auta do pliku");
            WriteLine("9 - Zakoncz");
            WriteLine();

            int operacja = -1;
            string wejscie = ReadLine(); ;
            int.TryParse(wejscie, out operacja);
            while (operacja == -1 || operacja < 1 || operacja>9)
            {
                WriteLine("Podaj poprawną operację!");
                wejscie = ReadLine();
                int.TryParse(wejscie, out operacja);

            }

            return operacja;
        }
    }
}

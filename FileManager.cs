using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CarCatalog
{
    class FileManager
    {
        private static string FileName = "..\\dane.txt";

        public static List<Car> ReadFromFile()
        {
            List<Car> zwrot = new List<Car>();
            try
            {

                using (StreamReader sr = new StreamReader(FileName))
                {
                    string linia = sr.ReadLine();
                    while (linia != null)
                    {
                        string[] tab = linia.Split(";");

                        Car c = new Car(tab[0],tab[1],tab[2],int.Parse(tab[3]),int.Parse(tab[4]),double.Parse(tab[5]));
                        zwrot.Add(c);
                        linia = sr.ReadLine();
                    }

                    return zwrot;
                }

            }
            catch (IOException)
            {
                Console.WriteLine("Brak pliku z którego można by czytać!");
                return null;
            }

        }

        public static void WriteToFile (List<Car> catalog)
        {

            try
            {

                using (StreamWriter sr = new StreamWriter(FileName))
                {
                    foreach (Car car in catalog)
                    {
                        sr.Write(car.Marka+";");
                        sr.Write(car.Model + ";");
                        sr.Write(car.Skrzynia + ";");
                        sr.Write(car.Rocznik + ";");
                        sr.Write(car.Przebieg + ";");
                        sr.Write(car.Pojemnosc + ";");
                        sr.WriteLine();
                    }

                }

            }
            catch (IOException e)
            {
                Console.WriteLine("Brak pliku!");
            }

        }
    }

}


using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Lab_2
{
    class Algoritm
    {
        public static void printData()
        {
            data[] elements = new data[4];

            string path = @"C:\Users\Petro\Desktop\Algoritm\TPR\Lab_2\Lab_2\elements.dat";

            try
            {
                using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
                {
                    // Зчитування в масив
                    // поки не дійде до кінця файлу зчитує кожне значення
                    int i =0;
                    while (reader.PeekChar() > -1)
                    {
                        string variant = reader.ReadString();
                        int factoryWorth = reader.ReadInt32();
                        int income = reader.ReadInt32();
                        int loss = reader.ReadInt32();
                        double incomeProbability = reader.ReadDouble();
                        double lossProbability = reader.ReadDouble();
                        int years = reader.ReadInt32();

                        elements[i] = new data(variant, factoryWorth, income, loss, incomeProbability, lossProbability, years);
                        i++;
                    }
                   
                }
                using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
                {
                    // Вивід даних на консоль
                    // поки не дійде до кінця файлу зчитує кожне значення
                    Console.WriteLine("     Вхідні дані, зчитані з файлу: ");
                    while (reader.PeekChar() > -1)
                    {
                        string variant = reader.ReadString();
                        int factoryWorth = reader.ReadInt32();
                        int income = reader.ReadInt32();
                        int loss = reader.ReadInt32();
                        double incomeProbability = reader.ReadDouble();
                        double lossProbability = reader.ReadDouble();
                        int years = reader.ReadInt32();

                        Console.WriteLine("Варіант: {0}  Ціна: {1}  Прибуток(в рік) {2} Ймовірність: {3} Витрати: {4} Ймовірність: {5} К-ть років: {6} ",
                            variant, factoryWorth, income, incomeProbability, loss, lossProbability, years);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            findBestSolution(elements);


            
            //foreach(var e in elements)
            //{
            //    Console.WriteLine(e.variant);
            //}
            
        }

        public static void findBestSolution(data[] elements)
        {
            double[] mat = new double[4];


            int i = 0;
            Console.WriteLine();
            
            foreach (var e in elements)
            {
                Console.Write("Для варіанту: "+e.variant);
                mat[i]= Math.Round(((((e.income*e.incomeProbability)+(e.loss*e.lossProbability))*e.years)/e.factoryWorth),2);
                Console.WriteLine(" оціночне значення рівне = " + mat[i]);
                i++;
            }

            Console.WriteLine();

            double bestResult = mat.Max();

            for(int j = 0; j < mat.Length; j++)
            {
                if (mat[j] == bestResult)
                {
                    Console.WriteLine("Найкращий варіант: " + elements[j].variant);
                }
            }
        }
    }
}

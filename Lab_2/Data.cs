using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.VisualBasic;


namespace Lab_2
{
    public struct data
    {
        public string variant;
        public int factoryWorth;
        public int income;
        public int loss;
        public double incomeProbability;
        public double lossProbability;
        public int years;

        public data(string v, int fW, int i, int l, double iP, double lP, int y)
        {
            variant = v;
            factoryWorth = fW;
            income = i;
            loss = l;
            incomeProbability = iP;
            lossProbability = lP;
            years = y;
        }
    }
    class Data
    {
        

        public static void WriteData()
        {
            data[] elements = new data[]{
                new data(){variant="A",factoryWorth=750, income=270,loss=-70,incomeProbability=0.8,lossProbability=0.2, years=5},
                new data(){variant="B",factoryWorth=250, income=170,loss=-50,incomeProbability=0.8,lossProbability=0.2, years=5},
                new data(){variant="CA",factoryWorth=750, income=270,loss=-70,incomeProbability=0.9,lossProbability=0.1, years=5},
                new data(){variant="CB",factoryWorth=250, income=170,loss=-50,incomeProbability=0.7,lossProbability=0.3, years=5}
            };

            string path = @"C:\Users\Petro\Desktop\Algoritm\TPR\Lab_2\Lab_2\elements.dat";

            try
            {
                // створення бінарного файлу
                //using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate)))
                //{
                //    // записуєм у файл кожне поле структури
                //    foreach (data e in elements)
                //    {
                //        writer.Write(e.variant);
                //        writer.Write(e.factoryWorth);
                //        writer.Write(e.income);
                //        writer.Write(e.loss);
                //        writer.Write(e.incomeProbability);
                //        writer.Write(e.lossProbability);
                //        writer.Write(e.years);
                //    }
                //}
                // створення бінарного файлу
                using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
                {
                    // поки не дійде до кінця файлу зчитує кожне значення
                    while (reader.PeekChar() > -1)
                    {
                        string variant = reader.ReadString();
                        int factoryWorth= reader.ReadInt32();
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
            

        }
    }
}

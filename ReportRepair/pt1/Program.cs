using System;
using System.IO;

namespace Day1ReportRepair
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Directory.GetCurrentDirectory() + "/numbers.txt";

            string[] GetFile = File.ReadAllLines(path);

            int[] ints = Array.ConvertAll(GetFile, int.Parse);

            bool b = true;

            int[] res = new int[2];

            while(b)
            {
                for (int i = 0; i < ints.Length; i++)
                {
                    for (int n = 1; n < ints.Length; n++)
                    {
                        if(ints[i] + ints[n] == 2020)
                        {
                            res[0] = ints[i];
                            res[1] = ints[n];
                            b = false;
                        }
                    }
                }
            }

            int fin = res[0] * res[1];

            Console.WriteLine(fin);
        }
    }
}
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

            var res = new int[2];
            var b = true;

            while(b)
            {
                for (var i = 0; i < ints.Length; i++)
                {
                    for (var n = 1; n < ints.Length; n++)
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

            var fin = res[0] * res[1];

            Console.WriteLine(fin);
        }
    }
}
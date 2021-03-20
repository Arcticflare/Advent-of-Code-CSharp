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

            var res = new int[3];
            var b = true;

            while(b)
            {
                int len = ints.Length;
                for (var i = 0; i < len; i++)
                {
                    for (var n = 1; n < len; n++)
                    {
                        for (var x = 0; x < len; x++)
                        {
                            if(ints[i] + ints[n] + ints[x]== 2020)
                            {
                                res[0] = ints[i];
                                res[1] = ints[n];
                                res[2] = ints[x];
                                b = false;
                            }    
                        }
                        
                    }
                }
            }

            var fin = res[0] * res[1] * res[2];

            Console.WriteLine(fin);
        }
    }
}
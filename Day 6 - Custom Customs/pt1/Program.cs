using System;
using System.IO;

namespace pt1
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Directory.GetCurrentDirectory() + "/input.txt";
            string[] file = File.ReadAllLines(path);
        }
    }
}

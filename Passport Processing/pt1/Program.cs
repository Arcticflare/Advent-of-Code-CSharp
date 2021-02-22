using System;
using System.IO;

namespace pt1
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Directory.GetCurrentDirectory() + "/passports.txt";

            string file = File.ReadAllText(path);

            string[] persons = file.Split(new string[] { "\r\n\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            int valid = 0;

            foreach (var person in persons)
            {
                bool a = person.Contains("byr");
                bool b = person.Contains("iyr");
                bool c = person.Contains("eyr");
                bool d = person.Contains("hgt");
                bool e = person.Contains("hcl");
                bool f = person.Contains("ecl");
                bool g = person.Contains("pid");

                if(a && b && c && d && e && f && g)
                {
                    valid++;
                }
            }

            Console.WriteLine(valid);
        }
    }
}

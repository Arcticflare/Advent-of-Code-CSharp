using System;
using System.IO;

namespace pt2
{
    class Program
    {
        static void Main(string[] args)
        {
            string GetFile = Directory.GetCurrentDirectory() + "/password.txt";

            string[] lines = File.ReadAllLines(GetFile);

            var valid = 0;

            foreach (string item in lines)
            {
                string[] i = item.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                int[] n = Array.ConvertAll(i[0].Split("-", StringSplitOptions.None), int.Parse);

                char char_ = Convert.ToChar(i[1].Substring(0,1));

                string pass = i[2];

                if( (pass[n[0] - 1] == char_) || (pass[n[1] - 1] == char_) )
                {
                    if( pass[n[0] - 1] != pass[n[1] - 1] )
                    {
                        valid++;
                    }
                }
            }

            Console.WriteLine(valid);
        }
    }
}




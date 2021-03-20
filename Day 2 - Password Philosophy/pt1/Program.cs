using System;
using System.IO;

namespace pt1
{
    class Program
    {
        static void Main(string[] args)
        {
            string GetFile = Directory.GetCurrentDirectory() + "/password.txt";

            string[] lines = File.ReadAllLines(GetFile);

            var valid = 0;

            foreach (var item in lines)
            {
                string[] i = item.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                int[] n = Array.ConvertAll(i[0].Split("-", StringSplitOptions.None), int.Parse);

                char char_ = Convert.ToChar(i[1].Substring(0,1));

                string pass = i[2];
                
                var count = 0;

                foreach (char p in pass)
                {
                    if (p == char_)
                    {
                        count++;
                    }
                }

                if (count >= n[0] && count <= n[1])
                {
                    valid++;
                }
            }

            Console.WriteLine(valid);
        }
    }
}

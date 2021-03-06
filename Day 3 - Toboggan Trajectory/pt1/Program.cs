﻿using System;
using System.IO;

namespace pt1
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Directory.GetCurrentDirectory() + "/pattern.txt";

            string[] grid = File.ReadAllLines(path);

            var treeshit = 0;
            var index = 0;
            var linecount = 0;
            
            do
            {
                string line = grid[linecount];

                if ( index >= line.Length )
                {
                    index = index - line.Length;
                }

                if  (line[index] == '#' )
                {
                    treeshit++;
                }

                linecount++;
                index += 3;
                
            } while (grid.Length > linecount);

            Console.WriteLine(treeshit);
        }
    }
}

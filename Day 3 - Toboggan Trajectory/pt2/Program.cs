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

            var index = 0;
            var line = 0;

            int[] right = { 1, 3, 5, 7, 1 };
            int[] down = { 1, 1, 1, 1, 2 };
            ulong[] trees = { 0, 0, 0, 0, 0 };

            for (var i = 0; i < 5; i++)
            {
                while (line < grid.Length)
                {
                    string c_line = grid[line];

                    if (index + 1 > c_line.Length)
                    {
                        index -= c_line.Length;
                    }

                    if (c_line[index] == '#')
                    {
                        trees[i]++;
                    }

                    index += right[i];
                    line += down[i];
                }
                index = 0;
                line = 0;
                Console.WriteLine(trees[i]);
            }

            Console.WriteLine(trees[0] * trees[1] * trees[2] * trees[3] * trees[4]);
        }
    }
}

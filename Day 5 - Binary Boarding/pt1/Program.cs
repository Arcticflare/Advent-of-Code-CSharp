using System;
using System.IO;

namespace pt1
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Directory.GetCurrentDirectory() + "/binary.txt";
            string[] lines = File.ReadAllLines(path);

            var highestId = 0;

            foreach (string line in lines)
            {
                var bit = 0b_0100_0000;
                int[] row_range = { 1, 128 };

                var bob = 0b_0100;
                int[] col_range = { 1, 8 };

                var seatId = 0;

                foreach (char letter in line)
                {
                    switch (letter)
                    {
                        case 'F':
                            row_range[1] -= bit;
                            bit >>= 1;
                            break;
                        case 'B':
                            row_range[0] += bit;
                            bit <<= 1;
                            break;
                        case 'L':
                            col_range[1] -= bob;
                            bob >>= 1;
                            break;
                        case 'R':
                            col_range[0] += bob;
                            bob <<= 1;
                            break;
                        default:
                            break;
                    }
                }
                
                seatId = ((row_range[0] - 1) * 8) + (col_range[0] - 1);

                highestId = seatId >= highestId ? seatId : highestId;
            }

            Console.WriteLine(highestId);
        }
    }
}
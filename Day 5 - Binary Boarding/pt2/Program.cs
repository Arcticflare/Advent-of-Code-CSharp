using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace pt2
{
    class Program
    {
        /* Finds a *SINGLE* missing int in a list of ints 
            Does not function if more than one int is missing. */
        static int FindMissing(List<int> list)
        {
            int total = (list.Count + 1) * (list.Count + 2) / 2;

            for (int i = 0; i < list.Count; i++)
            {
                total -= list[i];
            }

            return total;
        }
        static void Main(string[] args)
        {
            string path = Directory.GetCurrentDirectory() + "/binary.txt";
            string[] lines = File.ReadAllLines(path);

            List<int> seatIdList = new List<int>();
            int max = 0b_0100_0000_0000; // 1024

            foreach (var line in lines)
            {
                // 911 = 0011 1000 1111
                int bit = 0b_0100_0000;
                int bob = 0b_0100;

                int[] row_range = new int[] { 1, 128 };
                int[] col_range = new int[] { 1, 8 };

                int seatId = 0;
                int seatNum = 0;

                foreach (var letter in line)
                {
                    switch (letter)
                    {
                        case 'F':
                            row_range[1] -= bit;
                            bit >>= 1;
                            break;
                        case 'B':
                            row_range[0] += bit;
                            bit >>= 1;
                            break;
                        case 'L':
                            col_range[1] -= bob;
                            bob >>= 1;
                            break;
                        case 'R':
                            col_range[0] += bob;
                            bob >>= 1;
                            break;
                        default:
                            break;
                    }
                }

                seatNum = ((row_range[0] - 1) * (col_range[0] - 1));
                
                seatId = ((row_range[0] - 1) * 8) + (col_range[0] - 1);
                seatIdList.Add(seatId);
            }
            

            //Console Tests...
            int mySeatID = FindMissing(seatIdList);

            /* This finds ALL missing seats on the plane.
                I've used to to complete the task, but it *should* eventually return only the one seat. */
            var result = Enumerable.Range(0, max).Except(seatIdList);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
    }
}

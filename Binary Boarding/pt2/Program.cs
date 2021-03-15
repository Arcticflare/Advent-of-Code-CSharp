using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace pt2
{
    static class Extention
    {
        public static IEnumerable<int> FindMissing(this List<int> list)
    {
        // Sorting the list
        list.Sort();

        // First number of the list
        var firstNumber = list.First();

        // Last number of the list
        var lastNumber = list.Last();

        // Range that contains all numbers in the interval
        // [ firstNumber, lastNumber ]
        var range = Enumerable.Range(firstNumber, lastNumber - firstNumber);

        // Getting the set difference
        var missingNumbers = range.Except(list);

        return missingNumbers;
    }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string path = Directory.GetCurrentDirectory() + "/binary.txt";
            string[] lines = File.ReadAllLines(path);

            int highestId = 0;

            //Store all numbers in lists.
            List<int> seatNumList = new List<int>();
            List<int> seatNumList_sorted = new List<int>();

            foreach (var line in lines)
            {
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
                
                seatId = ((row_range[0] - 1) * 8) + (col_range[0] - 1);
                seatNum = (row_range[0] * col_range[0] - 1);

                highestId = seatId >= highestId ? seatId : highestId;

                //Add ints to lists.
                seatNumList.Add(seatNum);
                seatNumList_sorted.Add(seatNum);
            }
            seatNumList_sorted.Sort();

            //Console Tests...
            for (int i = 0; i < seatNumList.Count; i++)
            {
                Console.WriteLine("{0} - Sorted: {1}", seatNumList[i], seatNumList_sorted[i]);
            }
        }
    }
}

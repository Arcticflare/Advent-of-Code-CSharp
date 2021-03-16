using System;
using System.IO;

namespace pt2
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Directory.GetCurrentDirectory() + "/passportinvalid.txt";
            string file = File.ReadAllText(path);

            string[] persons = file.Split(new string[] { "\r\n\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            int valid = 0;

            foreach (var person in persons)
            {
                string[] values = person.Split(new string[] { " ", "\n" }, StringSplitOptions.RemoveEmptyEntries);
                // iyr:2002

                bool a = person.Contains("byr");
                bool b = person.Contains("iyr");
                bool c = person.Contains("eyr");
                bool d = person.Contains("hgt");
                bool e = person.Contains("hcl");
                bool f = person.Contains("ecl");
                bool g = person.Contains("pid");

                bool vCheck = true;

                if (a && b && c && d && e && f && g)
                {

                    while (vCheck)
                    {
                        foreach (var item in values)
                        {
                            string[] split = item.Split(":", StringSplitOptions.None);
                            Console.WriteLine("split0 = {0}, split1 = {1}", split[0], split[1]);

                            split[1] = split[1].Trim();

                            bool num = int.TryParse(split[1], out int x);

                            

                            switch (split[0])
                            {
                                case "byr":
                                    if (x < 1920 || x > 2002)
                                    {
                                        Console.WriteLine("check");
                                        vCheck = false;
                                    }

                                    break;

                                case "iyr":
                                    if (x < 2010 || x > 2020)
                                    {
                                        Console.WriteLine("check");
                                        vCheck = false;
                                    }

                                    break;

                                case "eyr":
                                    if (x < 2020 || x > 2030)
                                    {
                                        Console.WriteLine("check");
                                        vCheck = false;
                                    }

                                    break;

                                case "hgt":
                                    if (!split[1].Contains("cm"))
                                    {
                                        if(!split[1].Contains("in"))
                                        {
                                            Console.WriteLine("check");
                                            vCheck = false;
                                            break;
                                        }
                                    }

                                    string[] s = split[1].Split(new char[] { 'c', 'i' }, StringSplitOptions.None);
                                    int val;
                                    bool boolay = int.TryParse(s[0], out val);

                                    if (s[1] == "m" && boolay)
                                    {
                                        if (val < 150 || val > 193)
                                        {
                                            Console.WriteLine("check");
                                            vCheck = false;
                                            break;
                                        }
                                    }

                                    if (s[1] == "n" && boolay)
                                    {
                                        if (val < 59 || val > 76) 
                                        {
                                            Console.WriteLine("check");
                                            vCheck = false;
                                            break;
                                        }
                                    }

                                    break;

                                case "hcl":
                                    if (split[1][0] == '#' && split[1].Length == 7)
                                    {
                                        for (int i = 1; i <= split[1].Length - 1; i++)
                                        {
                                            int ch = Convert.ToInt32(split[1][i]);
                                            if (Char.IsDigit(split[1][i]))
                                            {
                                                break;
                                            }
                                            else
                                            {
                                                if (ch < 97 && ch > 102)
                                                {
                                                    if (ch < 65 && ch > 70)
                                                    {
                                                        Console.WriteLine("check");
                                                        vCheck = false;
                                                        break;
                                                    }
                                                    
                                                    Console.WriteLine("check");
                                                    vCheck = false;
                                                    break;
                                                }
                                            }
                                        }
                                    }

                                    else
                                    {
                                        Console.WriteLine("check");
                                        vCheck = false;
                                        break;
                                    }

                                    break;

                                case "ecl":
                                    if (split[1] == "amb" || split[1] == "blu" || split[1] == "brn" || split[1] == "gry" ||
                                        split[1] == "grn" || split[1] == "hzl" || split[1] == "oth")
                                    {
                                        break;
                                    }

                                    else
                                    {
                                        Console.WriteLine("check");
                                        vCheck = false;
                                        break;
                                    }

                                case "pid":
                                    if (!double.TryParse(split[1], out _))
                                    {
                                        Console.WriteLine("check");
                                        vCheck = false;
                                        break;
                                    }
                                    if (split[1].Length != 9)
                                    {
                                        Console.WriteLine("check");
                                        vCheck = false;
                                        break;
                                    }

                                    break;

                                case "cid":
                                    break;

                                default:
                                    break;
                            }
                        }
                        if (vCheck)
                        {
                            valid++;
                            vCheck = false;
                        }
                    }
                    Console.WriteLine();
                }
            }

            Console.WriteLine(valid);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace robot_vacuum_cleaner
{
    internal class Program
    {
        static string[,] ModelGeneration()
        {
            int lines, columns;
            do 
            { 
                Console.Write("Add meg a lakás sorainak számát (20, 30) intervallumban: ");
                lines = Convert.ToInt32(Console.ReadLine());
                Console.Write("Add meg a lakás oszlopainak számát (20, 30) intervalumban: ");
                columns = Convert.ToInt32(Console.ReadLine());
            } while ((lines == columns) || (lines > 30 || lines < 20) ||(columns > 30 || columns < 20));

            string[,] houseModel = new string[lines, columns];

            return houseModel;
        }

        static string[,] CreateModel(string[,] houseModel)
        {
            string[,] house = houseModel;
            Random random = new Random();
            bool robot = false;
            bool dirty = false;
            bool clear = false;

            do
            {
                for (int i = 0; i < house.GetLength(0); i++)
                {
                    for (int j = 0; j < house.GetLength(1); j++)
                    {
                        int number = random.Next(1, 11);
                        if (number >= 1 && number <= 5)
                        {
                            house[i, j] = "-";
                            clear = true;
                        }
                        else if (number >= 6 && number <= 7)
                        {
                            house[i, j] = "b";
                        }
                        else if (number >= 8 && number <= 10)
                        {
                            house[i, j] = "k";
                            dirty = true;
                        }
                    }
                }
            } while (dirty == false || clear == false);

            do
            {
                Random random_number = new Random();

                int row = random.Next(1, house.GetLength(0) + 1);
                int column = random.Next(1, house.GetLength(1) + 1);

                for (int i = 0; i < house.GetLength(0); i++)
                {
                    for (int j = 0; j < house.GetLength(1); j++)
                    {
                        if (row == i && column == j)
                        {
                            if (house[i, j] == "-")
                            {
                                house[i, j] = "r";
                                robot = true;
                            }
                        }
                    }
                }
            } while (robot == false);

            return house;
        }

        static void WriteHouse(string[,] house)
        {
            Console.WriteLine();

            for (int i = 0; i < house.GetLength(0); i++)
            {
                for (int j = 0; j < house.GetLength(1); j++)
                {
                    switch (house[i, j])
                    {
                        case "-":
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write(house[i, j] + " ");
                            break;
                        case "b":
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write(house[i, j] + " ");
                            break;
                        case "k":
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(house[i, j] + " ");
                            break;
                        case "r":
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(house[i, j] + " ");
                            break;
                    }
                }
                Console.WriteLine();
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine("A továbblépéshez nyomjon meg egy billentyűt!");
            Console.ReadKey();
            Console.Clear();
        }

        static void Cleaning(string[,] house)
        {
            Random steps = new Random();
            bool cleaned = false;

            do
            {
                int step = steps.Next(1, 5);
                string step_direction = "";

                switch (step)
                {
                    case 1:
                        step_direction = "up";
                        break;
                    case 2:
                        step_direction = "down";
                        break;
                    case 3:
                        step_direction = "left";
                        break;
                    case 4:
                        step_direction = "right";
                        break;
                    default:
                        step_direction = " ";
                        break;
                }

                for (int i = 0; i < house.GetLength(0); i++)
                {
                    for (int j = 0; j < house.GetLength(1); j++)
                    {
                        if (house[i, j] == "r")
                        {
                            if (step_direction == "down")
                            {
                                if (i == house.GetLength(0) - 1)
                                {
                                    Console.WriteLine("Robot falnak ütközött lefelé!");
                                    continue;
                                }
                                else if (house[i + 1, j] == "b")
                                {
                                    Console.WriteLine("Robot bútornak ütközött lefelé!");
                                    continue;
                                }
                                else
                                {
                                    house[i, j] = "-";
                                    house[i + 1, j] = "r";
                                    Console.WriteLine("A robot egyet lefelé lépett!");
                                    continue;
                                }
                            }
                            else if (step_direction == "up")
                            {
                                if (i == 0)
                                {
                                    Console.WriteLine("Robot falnak ütközött felfelé!");
                                    continue;
                                }
                                else if (house[i - 1, j] == "b")
                                {
                                    Console.WriteLine("Robot bútornak ütközött felfelé!");
                                    continue;
                                }
                                else
                                {
                                    house[i, j] = "-";
                                    house[i - 1, j] = "r";
                                    Console.WriteLine("A robot egyet felfelé lépett!");
                                    continue;
                                }
                            }
                            else if (step_direction == "right")
                            {
                                if (j == house.GetLength(1) - 1)
                                {
                                    Console.WriteLine("Robot falnak ütközött jobbra!");
                                    continue;
                                }
                                else if (house[i, j + 1] == "b")
                                {
                                    Console.WriteLine("Robot bútornak ütközött jobbra!");
                                    continue;
                                }
                                else
                                {
                                    house[i, j] = "-";
                                    house[i, j + 1] = "r";
                                    Console.WriteLine("A robot egyet jobbra lépett!");
                                    continue;
                                }
                            }
                            else if (step_direction == "left")
                            {
                                if (j == 0)
                                {
                                    Console.WriteLine("Robot falnak ütközött balra!");
                                    continue;
                                }
                                else if (house[i, j - 1] == "b")
                                {
                                    Console.WriteLine("Robot bútornak ütközött balra!");
                                    continue;
                                }
                                else
                                { 
                                    house[i, j] = "-";
                                    house[i, j - 1] = "r";
                                    Console.WriteLine("A robot egyet balra lépett!");
                                    continue;
                                }
                            }
                        }
                        else
                        {
                            continue;
                        }
                    }
                }

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                Console.WriteLine("A továbblépéshez nyomjon meg egy billentyűt!");
                Console.ReadKey();
                Console.Clear();

                for (int i = 0; i < house.GetLength(0); i++)
                {
                    for (int j = 0; j < house.GetLength(1); j++)
                    {
                        switch (house[i, j])
                        {
                            case "-":
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write(house[i, j] + " ");
                                break;
                            case "b":
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.Write(house[i, j] + " ");
                                break;
                            case "k":
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write(house[i, j] + " ");
                                break;
                            case "r":
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write(house[i, j] + " ");
                                break;
                        }
                    }
                    Console.WriteLine();
                }
            } while (!cleaned);
        }

        static bool CheckCleaned(string[,] house)
        {
            bool cleaned = false;

            for (int i = 0; i < house.GetLength(0); i++)
            {
                for (int j = 0; j < house.GetLength(1); j++)
                {
                    if (house[i, j] == "k")
                    {
                        cleaned = false;
                        break;
                    }
                }
            }
            cleaned = true;

            return cleaned;
        }

        static void Main(string[] args)
        {
            string[,] houseModel = ModelGeneration();
            string[,] house = CreateModel(houseModel);

            bool cleaned = CheckCleaned(house);
            do
            {
                WriteHouse(house);
                Cleaning(house);
            } while (cleaned == false);
        }
    }
}

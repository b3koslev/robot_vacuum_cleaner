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
            int cleaned_cells = 0;
            int total_steps = 0;
            int dirty = 0;
            List<string> coordinates = new List<string>();

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
                            if (i == 0 && j == 0)
                            {
                                if (house[i, j + 1] == "b" && house[i + 1, j] == "b")
                                {
                                    Console.WriteLine("A robot nem tud mozdulni a bútorok miatt.");
                                    break;
                                }
                            }
                            else if (i == house.GetLength(0) && j == house.GetLength(1))
                            {
                                if (house[i, j - 1] == "b" && house[i - 1, j] == "b")
                                {
                                    Console.WriteLine("A robot nem tud mozdulni a bútorok miatt.");
                                    break;
                                }
                            }
                            else if (i == house.GetLength(0) && j == 0)
                            {
                                if (house[i, j + 1] == "b" && house[i - 1, j] == "b")
                                {
                                    Console.WriteLine("A robot nem tud mozdulni a bútorok miatt.");
                                    break;
                                }
                            }
                            else if (i == 0 && j == house.GetLength(1))
                            {
                                if (house[i, j - 1] == "b" && house[i + 1, j] == "b")
                                {
                                    Console.WriteLine("A robot nem tud mozdulni a bútorok miatt.");
                                    break;
                                }
                            }
                            else
                            {
                                if (step_direction == "down")
                                {
                                    if (house[i + 1, j] == "k")
                                    {
                                        dirty++;
                                        coordinates.Add($"{i + 1}, {j}");
                                        total_steps++;
                                        cleaned_cells++;
                                        continue;
                                    }
                                    else
                                    {
                                        continue;
                                    }
                                }
                                else if (step_direction == "up")
                                {
                                    if (house[i - 1, j] == "k")
                                    {
                                        dirty++;
                                        coordinates.Add($"{i - 1}, {j}");
                                        total_steps++;
                                        cleaned_cells++;
                                        continue;
                                    }
                                    else
                                    {
                                        continue;
                                    }
                                }
                                else if (step_direction == "right")
                                {
                                    if (house[i, j + 1] == "k")
                                    {
                                        dirty++;
                                        coordinates.Add($"{i}, {j + 1}");
                                        total_steps++;
                                        cleaned_cells++;
                                        continue;
                                    }
                                    else 
                                    {
                                        continue;
                                    }
                                }
                                else if (step_direction == "left")
                                {
                                    if (house[i, j - 1] == "k")
                                    {
                                        dirty++;
                                        coordinates.Add($"{i}, {j - 1}");
                                        total_steps++;
                                        cleaned_cells++;
                                        continue;
                                    }
                                    else
                                    {
                                        continue;
                                    }
                                }
                            }
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
            } while (!cleaned);

            Console.WriteLine("===========================");
            Console.WriteLine("\tStatisztika");
            Console.WriteLine("===========================");

            Console.WriteLine("Összes lépés: " + total_steps);
            Console.WriteLine("Tisztított cellák száma: " + cleaned_cells);

            Console.WriteLine("Koszos cellák száma: " + dirty);

            Console.Write("A koszos cellák koordinátái: ");
            foreach (string cell in coordinates)
            {
                Console.Write($"{cell}; ");
            }
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
                        if (i == 0 && j == 0)
                        {
                            if (house[i, j + 1] == "b" && house[i + 1, j] == "b")
                            {
                                Console.WriteLine("A kosz nem elérhető a bútorok miatt.");
                                cleaned = true;
                                break;
                            }
                        }
                        else if (i == house.GetLength(0) && j == house.GetLength(1))
                        {
                            if (house[i, j - 1] == "b" && house[i - 1, j] == "b")
                            {
                                Console.WriteLine("A kosz nem elérhető a bútorok miatt.");
                                cleaned = true;
                                break;
                            }
                        }
                        else if (i == house.GetLength(0) && j == 0)
                        {
                            if (house[i, j + 1] == "b" && house[i - 1, j] == "b")
                            {
                                Console.WriteLine("A kosz nem elérhető a bútorok miatt.");
                                cleaned = true;
                                break;
                            }
                        }
                        else if (i == 0 && j == house.GetLength(1))
                        {
                            if (house[i, j - 1] == "b" && house[i + 1, j] == "b")
                            {
                                Console.WriteLine("A kosz nem elérhető a bútorok miatt.");
                                cleaned = true;
                                break;
                            }
                        }
                        else
                        {
                            cleaned = false;
                            break;
                        }
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

            WriteHouse(house);

            bool cleaned = CheckCleaned(house);
            if (cleaned)
            {
                Cleaning(house);
            }
        }
    }
}

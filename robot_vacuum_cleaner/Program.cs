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

            for (int i = 0; i < house.GetLength(0); i++)
            {
                for (int j = 0; j < house.GetLength(1); j++)
                {
                    int number = random.Next(1, 11);
                    if (number >= 1 && number <= 5)
                    {
                        house[i, j] = "-";
                    }
                    else if (number >= 6 && number <= 7)
                    {
                        house[i, j] = "b";
                    }
                    else if (number >= 8 && number <= 10)
                    {
                        house[i, j] = "k";
                    }
                }
            }

            return house;
        }

        static void WriteHouse(string[,] house)
        {
            Console.WriteLine();

            for (int i = 0; i < house.GetLength(0); i++)
            {
                for (int j = 0; j < house.GetLength(1); j++)
                {
                    Console.Write(house[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            string[,] houseModel = ModelGeneration();
            string[,] house = CreateModel(houseModel);
            WriteHouse(house);
        }
    }
}

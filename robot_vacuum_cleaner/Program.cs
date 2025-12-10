using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace robot_vacuum_cleaner
{
    internal class Program
    {
        static int[,] ModelGeneration()
        {
            int lines, columns;
            do 
            { 
                Console.Write("Add meg a lakás sorainak számát (20, 30) intervallumban: ");
                lines = Convert.ToInt32(Console.ReadLine());
                Console.Write("Add meg a lakás oszlopainak számát (20, 30) intervalumban: ");
                columns = Convert.ToInt32(Console.ReadLine());
            } while ((lines == columns) || (lines > 30 || lines < 20) ||(columns > 30 || columns < 20));

            int[,] houseModel = new int[lines, columns];

            return houseModel;
        }

        static int[,] CreateModel(int[,] houseModel)
        {
            int[,] house = houseModel;
            Random random = new Random();

            for (int i = 0; i < house.GetLength(0); i++)
            {
                for (int j = 0; j < house.GetLength(1); j++)
                {
                    int number = random.Next(1, 11);
                    if (number >= 1 && number <= 5)
                    {
                        house[i, j] = '-';
                    }
                    else if (number >= 6 && number <= 7)
                    {
                        house[i, j] = 'b';
                    }
                    else if (number >= 8 && number <= 10)
                    {
                        house[i, j] = 'k';
                    }
                }
            }

            return house;
        }

        static void Main(string[] args)
        {
            int[,] houseModel = ModelGeneration();
            int[,] house = CreateModel(houseModel);
        }
    }
}

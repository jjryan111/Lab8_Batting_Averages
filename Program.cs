using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8_Batting_Average_List
{
    class Program
    {
        static void Main(string[] args)
        {
            string yesNo = "y";
            while (yesNo == "y")
            {
                int numPlayers = GetInput("Enter the number of batters: ", "Must have at least one batter! ", 0, int.MaxValue);
                double[,] averages = new double[numPlayers,3];

                string ynBat = "y";
 
                for (int i = 0; i < numPlayers; i++)
                {
                    ynBat = "y";
                    Console.WriteLine("Player"+(i+1));
                    averages[i, 0] = i;
                    double atBats = 0;
//                  Console.WriteLine(i);
                    double hits = 0;
                    double bases = 0;
                    while (ynBat == "y")
                    {
                        atBats++;
                        double result = GetInput("Enter number of bases earned: ", "Invalid input!", 0, 4);
                        if (result > 0)
                        {
                            hits++;
                        }
                        bases = bases + result;
//                        Console.WriteLine("{0} {1}",bases, hits);
                        averages[i,1] = (hits / atBats);
//                        Console.WriteLine(averages[i,1]);
                        averages[i,2] = (bases / atBats);
                        ynBat = ynInput("Enter another at bat? (y/n): ");
                    }
                }
                for (int j = 0; j < numPlayers; j++)
                {
                    Console.WriteLine("Player {0} has a batting average of {1:F2} and a slugging percentage of {2:F2}",(j+1), averages[j,1],averages[j,2]);
                }
                yesNo = ynInput("Another team? (y/n) : ");
            }

        }
        public static int GetInput(string question, string error, int bottomNum, int topNum)
        {
            bool validInput = false;
            int exitNum = 0;
            while (!validInput)
            {
                Console.Write(question);
                bool inp = int.TryParse(Console.ReadLine(), out exitNum);
                if (!inp || exitNum < bottomNum || exitNum > topNum)
                {
                    Console.WriteLine(error);
                }
                else
                {
                    validInput = true;
                }
            }
            return exitNum;
        }

        public static string ynInput(string question)
        // Gets a y or n.
        {
            string input = "";
            bool invalid = true;
            while (invalid)
            {
                Console.Write("\n {0} ",question);
                input = Console.ReadLine();
                input = input.ToLower();
                if (input == "y" || input == "n")
                {
                    invalid = false;
                }
                else
                {
                    Console.WriteLine("\nPlease enter y or n.");
                }
            }
            return input;
        }
    }
}

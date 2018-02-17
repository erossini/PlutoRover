using PlutoRover.Abstractions;
using PlutoRover.Abstractions.Enums;
using PlutoRover.Library;
using PlutoRover.Library.Factories;
using PlutoRover.Library.Positions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace PlutoRover.ConsoleApp
{
    class Program
    {
        static IPlanet pluto;
        static IRobotController robotController;
        static IRobotQueueCommandRunner queueOfCommandsRunner;

        static void Main(string[] args)
        {
            List<IPosition> objectsOnMap = new List<IPosition>();
            objectsOnMap.Add(new Position(1, 2, CompassDirection.North));
            objectsOnMap.Add(new Position(10, 20, CompassDirection.East));
            objectsOnMap.Add(new Position(50, 40, CompassDirection.South));
            objectsOnMap.Add(new Position(90, 90, CompassDirection.West));

            pluto = new Planet
            {
                Xsize = 100,
                Ysize = 100,
                ObjectsOnMap = objectsOnMap
            };

            robotController = new RobotController(new Position(0, 0, CompassDirection.North), pluto);
            queueOfCommandsRunner = new RobotQueueCommandRunner(robotController);

            DisplayWelcome();
            DisplayPlanetSize();
            DisplayMenu();
        }

        static bool CheckCommand(string strCommand)
        {
            bool rtn = true;

            if (!string.IsNullOrEmpty(strCommand))
            {
                foreach (char c in strCommand.ToCharArray())
                    if ("fblrFBLR".IndexOf(c) < 0)
                        rtn = false;
            }

            return rtn;
        }

        static void Display()
        {
            ConsoleColor startColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.White;

            Console.ForegroundColor = startColor;
        }

        static void DisplayMenu()
        {
            string input = "";
            while (input.ToLower() != "q")
            {
                ConsoleColor startColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Gray;

                Console.WriteLine("New direction >");
                input = Console.ReadLine();

                bool check = CheckCommand(input);
                if (!check)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Position must be in x,y,direction format.");
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;

                    IEnumerable<IPosition> robotPath = queueOfCommandsRunner.Run(input);

                    IPosition position = robotPath.LastOrDefault();
                    Console.WriteLine($"The new position of the rover is {position.Xcoordinate},{position.Ycoordinate},{position.Direction.ToString()[0]}.");
                    if (robotController.Collision)
                        Console.WriteLine("Collision detect!");

                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }

                Console.ForegroundColor = startColor;
            }
        }

        static void DisplayPlanetSize()
        {
            ConsoleColor startColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine($"Pluto has size: X -> {pluto.Xsize}");
            Console.WriteLine($"                Y -> {pluto.Ysize}");
            Console.WriteLine($"          Objects -> {pluto.ObjectsOnMap?.ToList().Count}");
            Console.WriteLine("");

            Console.ForegroundColor = startColor;
        }

        static void DisplayWelcome()
        {
            ConsoleColor startColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine(@"      ___                       ___                         ___       ");
            Console.WriteLine(@"     /\  \                     /\  \                       /\  \      ");
            Console.WriteLine(@"    /::\  \                    \:\  \         ___         /::\  \     ");
            Console.WriteLine(@"   /:/\:\__\                    \:\  \       /\__\       /:/\:\  \    ");
            Console.WriteLine(@"  /:/ /:/  /  ___     ___   ___  \:\  \     /:/  /      /:/  \:\  \   ");
            Console.WriteLine(@" /:/_/:/  /  /\  \   /\__\ /\  \  \:\__\   /:/__/      /:/__/ \:\__\  ");
            Console.WriteLine(@" \:\/:/  /   \:\  \ /:/  / \:\  \ /:/  /  /::\  \      \:\  \ /:/  /  ");
            Console.WriteLine(@"  \::/__/     \:\  /:/  /   \:\  /:/  /  /:/\:\  \      \:\  /:/  /   ");
            Console.WriteLine(@"   \:\  \      \:\/:/  /     \:\/:/  /   \/__\:\  \      \:\/:/  /    ");
            Console.WriteLine(@"    \:\__\      \::/  /       \::/  /         \:\__\      \::/  /     ");
            Console.WriteLine(@"     \/__/       \/__/         \/__/           \/__/       \/__/      ");
            Console.WriteLine(@"      ___           ___                         ___           ___     ");
            Console.WriteLine(@"     /\  \         /\  \          ___          /\__\         /\  \    ");
            Console.WriteLine(@"    /::\  \       /::\  \        /\  \        /:/ _/_       /::\  \   ");
            Console.WriteLine(@"   /:/\:\__\     /:/\:\  \       \:\  \      /:/ /\__\     /:/\:\__\  ");
            Console.WriteLine(@"  /:/ /:/  /    /:/  \:\  \       \:\  \    /:/ /:/ _/_   /:/ /:/  /  ");
            Console.WriteLine(@" /:/_/:/__/___ /:/__/ \:\__\  ___  \:\__\  /:/_/:/ /\__\ /:/_/:/__/___");
            Console.WriteLine(@" \:\/:::::/  / \:\  \ /:/  / /\  \ |:|  |  \:\/:/ /:/  / \:\/:::::/  /");
            Console.WriteLine(@"  \::/~~/~~~~   \:\  /:/  /  \:\  \|:|  |   \::/_/:/  /   \::/~~/~~~~ ");
            Console.WriteLine(@"   \:\~~\        \:\/:/  /    \:\__|:|__|    \:\/:/  /     \:\~~\     ");
            Console.WriteLine(@"    \:\__\        \::/  /      \::::/__/      \::/  /       \:\__\    ");
            Console.WriteLine(@"     \/__/         \/__/        ~~~~           \/__/         \/__/    ");
            Console.WriteLine("");

            Console.ForegroundColor = startColor;
        }
    }
}

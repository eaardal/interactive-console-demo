using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InteractiveConsoleDemo
{
    class SingleSelect
    {
        public static void Run()
        {
            var heroes = new List<string> { "Iron Man", "Thor", "The Hulk" };
            const string question = "Who is the coolest?";

            ConsoleKeyInfo mainLoopKeyInfo;

            do
            {
                (var selectedIndex, var keyInfo) = AskUserToSelectItem(heroes, question);

                Console.Clear();

                Console.WriteLine(question);

                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine($"{heroes.ElementAt(selectedIndex)} is the coolest!");
                    Console.ResetColor();

                    Console.WriteLine("Press a key to run again or Escape to exit");
                }

                mainLoopKeyInfo = Console.ReadKey();

            } while (mainLoopKeyInfo.Key != ConsoleKey.Escape);
        }

        private static (int selectedIndex, ConsoleKeyInfo keyInfo) AskUserToSelectItem(IReadOnlyCollection<string> items, string question)
        {
            var selectedIndex = 0;

            Console.CursorVisible = false;

            ConsoleKeyInfo keyInfo;

            do
            {
                Console.Clear();

                Console.WriteLine(question);

                for (var i = 0; i < items.Count; i++)
                {
                    if (selectedIndex == i)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"{i + 1}. {items.ElementAt(i)}");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine($"{i + 1}. {items.ElementAt(i)}");
                        Console.ResetColor();
                    }
                }

                keyInfo = Console.ReadKey();

                if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    if (selectedIndex + 1 < items.Count)
                    {
                        selectedIndex++;
                    }
                }

                if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    if (selectedIndex - 1 >= 0)
                    {
                        selectedIndex--;
                    }
                }
            } while (keyInfo.Key != ConsoleKey.Escape && keyInfo.Key != ConsoleKey.Enter);

            return (selectedIndex, keyInfo);
        }
    }
}

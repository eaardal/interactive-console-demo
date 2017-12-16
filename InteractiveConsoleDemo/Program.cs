using System;
using System.Collections.Generic;
using System.Linq;

namespace InteractiveConsoleDemo
{
    class Program
    {
        private static int _selectedHero;

        static void Main(string[] args)
        {
            _selectedHero = 1;

            var heroes = new List<string> {"Iron Man", "Thor", "The Hulk"};

            Console.WriteLine("Who is the coolest?");

            ConsoleKeyInfo key;

            do
            {
                Console.Clear();
                Console.CursorVisible = false;

                for (var i = 0; i < heroes.Count; i++)
                {
                    if (_selectedHero - 1 == i)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"{i + 1}. {heroes.ElementAt(i)}");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine($"{i + 1}. {heroes.ElementAt(i)}");
                        Console.ResetColor();
                    }
                }

                key = Console.ReadKey();

                if (key.Key == ConsoleKey.DownArrow)
                {
                    if (_selectedHero + 1 <= heroes.Count)
                    {
                        _selectedHero++;
                    }
                }

                if (key.Key == ConsoleKey.UpArrow)
                {
                    if (_selectedHero - 1 >= 1)
                    {
                        _selectedHero--;
                    }
                }
            } while (key.Key != ConsoleKey.Escape);

            

            Console.ReadLine();
        }
    }
}

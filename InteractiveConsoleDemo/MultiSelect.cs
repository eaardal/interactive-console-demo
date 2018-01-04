using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace InteractiveConsoleDemo
{
    class MultiSelect
    {
        public static void Run()
        {
            var heroes = new List<string> { "Iron Man", "Thor", "The Hulk", "Spiderman", "Batman" };
            const string question = "Who is the coolest?";

            ConsoleKeyInfo mainLoopKeyInfo;

            do
            {
                (var selectedIndices, var keyInfo) = AskUserToSelectItems(heroes, question);

                Console.Clear();

                Console.WriteLine(question);

                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Black;

                    foreach (var selectedIndex in selectedIndices)
                    {
                        Console.WriteLine($"You selected {heroes.ElementAt(selectedIndex)}");
                    }

                    Console.ResetColor();

                    Console.WriteLine("Press a key to run again or Escape to exit");
                }

                mainLoopKeyInfo = Console.ReadKey();

            } while (mainLoopKeyInfo.Key != ConsoleKey.Escape);
        }

        public static (IReadOnlyCollection<int> selectedIndices, ConsoleKeyInfo keyInfo) AskUserToSelectItems(IReadOnlyCollection<string> items, string question)
        {
            var selectedIndex = 0;
            var selectedIndices = new List<int>();

            Console.CursorVisible = false;

            ConsoleKeyInfo keyInfo;

            do
            {
                Console.Clear();

                Console.WriteLine(question);

                for (var i = 0; i < items.Count; i++)
                {
                    string text;

                    if (selectedIndex == i)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        text = $"[-] {items.ElementAt(i)}";
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        text = $"[-] {items.ElementAt(i)}";
                    }

                    if (selectedIndices.Contains(i) && selectedIndex == i)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        text = $"[+] {items.ElementAt(i)}";
                    }
                    else if (selectedIndices.Contains(i))
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        text = $"[+] {items.ElementAt(i)}";
                    }

                    Console.WriteLine(text);
                    Console.ResetColor();
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

                if (keyInfo.Key == ConsoleKey.Spacebar)
                {
                    if (selectedIndices.Contains(selectedIndex))
                    {
                        selectedIndices.Remove(selectedIndex);
                    }
                    else
                    {
                        selectedIndices.Add(selectedIndex);
                    }
                }

            } while (keyInfo.Key != ConsoleKey.Escape && keyInfo.Key != ConsoleKey.Enter);

            return (selectedIndices, keyInfo);
        }
    }
}

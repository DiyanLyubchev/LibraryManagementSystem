using System;
using System.Collections.Generic;
using System.Text;

namespace VenneslaLibraryTeamWork
{
    public class CommandArgs : ICommandArgs
    {
        public Users Users { get; set; }
        public ILibrary Library { get; set; }
        public Book SelectedBook { get; set; }

        public T MultipleChoice<T>(string title, List<T> options)  
        {
            int currentSelection = 0;
            ConsoleKey key;

            Console.CursorVisible = false;

            do
            {
                Console.Clear();

                Console.WriteLine($"Welcome to {this.Library.Name}, {this.Library.Address}");
                Console.WriteLine($"{title}{Environment.NewLine}");

                for (int i = 0; i < options.Count; i++)
                {
                    Console.SetCursorPosition(0, i + 2);

                    Console.Write($"{i + 1}. ");

                    if (i == currentSelection)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                    }

                    var optionParts = options[i].ToString().Split('_');
                    var currentOption = optionParts[optionParts.Length - 1];

                    Console.Write($"{currentOption}");
                    Console.ResetColor();
                }

                key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        if (currentSelection > 0)
                        {
                            currentSelection -= 1;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (currentSelection + 1 < options.Count)
                        {
                            currentSelection += 1;
                        }
                        break;
                }
            } while (key != ConsoleKey.Enter);

            Console.CursorVisible = true;
            Console.Clear();

            return options[currentSelection];
        }

    }

}

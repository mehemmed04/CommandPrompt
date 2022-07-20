using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPrompt
{
    public class CommandColor:CommandRoot
    {
        public ConsoleColor[] colors = new ConsoleColor[]
      {
            ConsoleColor.Black,
            ConsoleColor.Blue,
            ConsoleColor.Green,
            ConsoleColor.Red,
            ConsoleColor.Yellow,
            ConsoleColor.White,
            ConsoleColor.Gray,
      };

        public CommandColor(string command)
        {
            Command = command;
        }
        public void SetColor()
        {
            var splits = Command
                        .Where(x => x != ' ')
                        .ToList();
            var number = splits[5] - 48;//ASCII Table
            Console.ForegroundColor = colors[number];
        }
    }
}

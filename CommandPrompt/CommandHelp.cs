using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPrompt
{
    public class CommandHelp : CommandRoot
    {
        public List<CommandRoot> Commands { get; set; } = new List<CommandRoot>
        {
            new CommandRoot
            {
                Command="BREAK",
                 ShortDescription = "Sets or clears extended CTRL+C checking."
            },
             
            new CommandRoot
            {
                 Command="COLOR",
                 ShortDescription="Sets the default console foreground and background colors."
            },
              
            new CommandRoot
            {
                  Command="COPY",
                 ShortDescription="Copies one or more files to another location."
            },
               
            new CommandRoot
            {
                 Command ="DATE",
                 ShortDescription="Displays or sets the date."
            }, 
            new CommandRoot
            {
                Command="DIR",
                 ShortDescription="Displays a list of files and subdirectories in a directory."
            }, 
            new CommandRoot
            {
                Command="FIND",
                ShortDescription="Searches for a text string in a file or files.",
            }, 
            new CommandRoot
            {
                Command="FORMAT",
                ShortDescription="Formats a disk for use with Windows.",
            },
            new CommandRoot
            {
                Command="GOTO",
                ShortDescription="Directs the Windows command interpreter to a labeled line in a batch program.",
            }, 
            new CommandRoot
            {
                Command="IF",
                ShortDescription="Performs conditional processing in batch programs.",
            }, 
            new CommandRoot
            {
                Command="MKDIR",
                ShortDescription="Creates a directory.",
            }, 
            new CommandRoot
            {
                Command="RENAME",
                ShortDescription="Renames a file or files.",
            }, 
            new CommandRoot
            {
                Command="SORT",
                ShortDescription="Sorts input.",
            }, 
            new CommandRoot
            {
                Command="SHUTDOWN",
                ShortDescription="Allows proper local or remote shutdown of machine.",
            }, 
            new CommandRoot
            {
                Command="TREE",
                ShortDescription="Graphically displays the directory structure of a drive or path.",
            }, 
            new CommandRoot
            {
                Command="TYPE",
                ShortDescription="Displays the contents of a text file.",
            },
        };
        public CommandHelp(string command)
        {
            Command = command;
        }
        public void CallHelpCommand()
        {
            var result = Command
                        .Where(x => x != ' ')
                        .ToList();
            if (result[0] == 'h' && result[1] == 'e' && result[2] == 'l' && result[3] == 'p' && result.Count==4)
            {
                foreach (var c in Commands)
                {
                    Console.WriteLine($"{c.Command}".PadRight(15) + $"{c.ShortDescription}");
                }
            }
        }
    }
}

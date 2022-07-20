using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPrompt
{
    public class CommandTree : CommandRoot
    {
        public CommandTree(string command)
        {
            Command = command;
        }
        public void ShowTree()
        {
           string CURRENT_PATH = Directory.GetCurrentDirectory();
            var dir = new DirectoryInfo(CURRENT_PATH);
            CURRENT_PATH = dir.Parent.Parent.Parent.Parent.FullName;

            Console.WriteLine("Folder PATH listing for volume Windows");
            PrintDirectoryTree(CURRENT_PATH);

        }
        public void PrintDirectoryTree(string rootDirectoryPath)
        {
            try
            {
                if (!Directory.Exists(rootDirectoryPath))
                {
                    throw new DirectoryNotFoundException(
                        $"Directory '{rootDirectoryPath}' not found.");
                }

                var rootDirectory = new DirectoryInfo(rootDirectoryPath);
                PrintDirectoryTree(rootDirectory, 0);
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void PrintDirectoryTree( DirectoryInfo directory, int currentLevel)
        {
            var indentation = string.Empty;
            for (var i = 0; i < currentLevel; i++)
            {
                indentation += "|---";
            }

            Console.WriteLine($"{indentation}-{directory.Name}");
            //indentation = indentation.Remove(0, 4);
            indentation =  indentation.Insert(0, "    ");
            var nextLevel = currentLevel + 1;
            try
            {
                foreach (var subDirectory in directory.GetDirectories())
                {
                    PrintDirectoryTree(subDirectory, nextLevel);
                }
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine($"{indentation}-{e.Message}");
            }
        }

    }
}
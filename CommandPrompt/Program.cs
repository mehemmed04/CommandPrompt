using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPrompt
{
    class Command
    {
        public int Name { get; set; }
        public int Explaining { get; set; }
        public int ShortExplaining { get; set; }
    }
    public class Controller
    {
        static string CURRENT_PATH = "";
        static string Command = "";
        public static string GetMicrosoftVersion()
        {
            string subKey = @"SOFTWARE\Wow6432Node\Microsoft\Windows NT\CurrentVersion";
            Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.LocalMachine;
            Microsoft.Win32.RegistryKey skey = key.OpenSubKey(subKey);
            string name = skey.GetValue("ProductName").ToString();

            return $@"Microfot {name} [{Environment.Version.ToString()}]
(c) Microsoft Corporation. All rights reserved.";
        }
        public static void Start()
        {


            CURRENT_PATH = Directory.GetCurrentDirectory();
            Console.WriteLine(GetMicrosoftVersion());
            while (true)
            {
                Console.WriteLine();
                Console.Write(CURRENT_PATH + ">");
                Command = Console.ReadLine();
                if (Command == "cd ../")
                {
                    var dir = new DirectoryInfo(CURRENT_PATH);
                    CURRENT_PATH = dir.Parent.FullName;
                }
                else if (Command.ToLower().Contains("color"))
                {
                    CommandColor commandColor = new CommandColor(Command);
                    commandColor.SetColor();

                }
                else if (Command.ToLower().Contains("help"))
                {
                    CommandHelp commandHelp = new CommandHelp(Command);
                    commandHelp.CallHelpCommand();
                }
                else if (Command.ToLower().Contains("tree"))
                {
                    CommandTree commandTree = new CommandTree(Command);
                    commandTree.ShowTree();
                }
            }

        }

    }

    public class Program
    {

        static void Main(string[] args)
        {
            Console.Title = "Command Prompt";
            Controller.Start();

        }
    }
}
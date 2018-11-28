using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Investments
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string userInput = "";

            PrintUsages();
            Console.ReadKey();
        }

        public static void Run()
        {
            string userInput = "";

            Console.WriteLine("Welcome to the investment program!\n");
            PrintUsages();

            do
            {
                userInput = Console.ReadLine();
                HandleInput(userInput);
            }
            while (userInput.Contains("exit") != true);

            return;
        }

        static void PrintUsages()
        {
            Console.WriteLine("Usage examples: ");
            Console.WriteLine("1. establish symbol price");
            Console.WriteLine("2. update symbol price");
            Console.WriteLine("3. create investor name");
            Console.WriteLine("4. subscribe investor name");
            Console.WriteLine("5. unsubscribe investor name");
            Console.WriteLine("6. query stock");
            Console.WriteLine("7. help");
            Console.WriteLine("8. exit\n");
        }

        static void HandleInput(string userInput)
        {
            string[] commands = userInput.Split();

            switch (commands[0])
            {
                case "establish":
                    
                    break;
                case "update":
                    break;
                case "create":
                    break;
                case "subscribe":
                    break;
                case "unsubscribe":
                    break;
                case "query":
                    break;
                case "help":
                    break;
                case "exit":
                    break;
                default:
                    Console.WriteLine("Unrecognized command.  Try 'help' or 'exit'");
                    break;
            }
        }
    }
}

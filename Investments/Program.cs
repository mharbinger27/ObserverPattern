using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Investments
{
    public class Program
    {
        public static List<ConcreteStock> stockList = new List<ConcreteStock>();
        public static List<Investor> investorList = new List<Investor>();

        public static void Main(string[] args)
        {
            Run();
        }

        public static void Run()
        {
            string userInput = "";

            Console.WriteLine("Welcome to the investment program!\n");
            PrintUsages();

            do
            {
                Console.Write("\nEnter command: ");
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
            Console.WriteLine("3. enroll investor");
            Console.WriteLine("4. subscribe investor symbol");
            Console.WriteLine("5. unsubscribe investor symbol");
            Console.WriteLine("6. query stock");
            Console.WriteLine("7. help");
            Console.WriteLine("8. exit");
        }

        static void HandleInput(string userInput)
        {
            string[] commands = userInput.Split();

            if(commands.Length > 3 || commands.Length < 1)
            {
                Console.WriteLine("Incorrect number of commands. Try to match the examples in 'help'.");
                return;
            }

            switch (commands[0])
            {
                case "establish":
                    EstablishSymbol(commands[1], double.Parse(commands[2]));
                    break;
                case "update":
                    UpdateValue(commands[1], double.Parse(commands[2]));
                    break;
                case "enroll":
                    EnrollInvestor(commands[1]);
                    break;
                case "subscribe":
                    SubscribeInvestor(commands[1], commands[2]);
                    break;
                case "unsubscribe":
                    UnsubscribeInvestor(commands[1], commands[2]);
                    break;
                case "query":
                    QueryStock(commands[1]);
                    break;
                case "help":
                    PrintUsages();
                    break;
                case "exit":
                    break;
                default:
                    Console.WriteLine("Unrecognized command.  Try 'help' or 'exit'");
                    break;
            }
        }

        static void EstablishSymbol(string symbolName, double price)
        {
            var stock = stockList.Where(i => i.Symbol == symbolName).FirstOrDefault();

            if(stock == null)
            {
                stockList.Add(new ConcreteStock(symbolName, price));
            }
            else
            {
                Console.WriteLine($"Stock {symbolName} already exists.");
            }
        }

        static void UpdateValue(string symbolName, double price)
        {
            var stock = stockList.Where(i => i.Symbol == symbolName).FirstOrDefault();

            if(stock == null)
            {
                Console.WriteLine($"Stock {symbolName} not found. Establish it first.");
            }
            else
            {
                stock.Price = price;
            }

        }

        static void EnrollInvestor(string investorName)
        {
            var investor = investorList.Where(i => i.Name == investorName).FirstOrDefault();

            if (investor == null)
            {
                investorList.Add(new Investor(investorName));
                Console.WriteLine($"Enrolled investor {investorName}.");
            }
            else
            {
                Console.WriteLine($"Investor {investorName} already enrolled.");
            }
        }

        static void SubscribeInvestor(string investorName, string symbolName)
        {
            var stock = stockList.Where(i => i.Symbol == symbolName).FirstOrDefault();
            var investor = investorList.Where(i => i.Name == investorName).FirstOrDefault();

            if (stock == null)
            {
                Console.WriteLine($"Stock {symbolName} not found. Establish it first.");
            }
            else if (investor == null)
            {
                Console.WriteLine($"Investor {investorName} not found. Enroll them first.");
            }
            else
            {
                stock.Attach(investor);
            }
        }

        static void UnsubscribeInvestor(string investorName, string symbolName)
        {
            var stock = stockList.Where(i => i.Symbol == symbolName).FirstOrDefault();
            var investor = investorList.Where(i => i.Name == investorName).FirstOrDefault();

            if (stock == null)
            {
                Console.WriteLine($"Stock {symbolName} not found. Establish it first.");
            }
            else if (investor == null)
            {
                Console.WriteLine($"Investor {investorName} not found. Enroll them first.");
            }
            else
            {
                stock.Detach(investor);
            }
        }

        static void QueryStock(string symbolName)
        {
            var stock = stockList.Where(i => i.Symbol == symbolName).FirstOrDefault();

            if (stock == null)
            {
                Console.WriteLine($"Stock {symbolName} not found. Establish it first.");
            }
            else
            {
                Console.WriteLine($"Stock {symbolName} has value {stock.Price}.");
            }

        }
    }
}

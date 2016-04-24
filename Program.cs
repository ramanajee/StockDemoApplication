using StockDemo.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace StockDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            StockBLL stockBll = new StockBLL();
            var companyList = stockBll.Get();

            Console.WriteLine("::::Welcome to Stock Information Application:::::" + "\n");
            while (true)
            {
                Console.WriteLine("===============================================================");
                Console.WriteLine("1.Print Top 10 Companies Information" + "\n");
                Console.WriteLine("2.Live Stock Information" + "\n");
                Console.WriteLine("3.Setup Live Notifications(Coming Soon)..");
                Console.WriteLine("4.Exit" + "\n");
                Console.WriteLine("===============================================================");
                Console.Write("Select Following Option");
                var userOption = Console.ReadLine();
                switch (userOption)
                {
                    case "1":
                        stockBll.PrintTop10();
                        break;
                    case "2":
                        Console.WriteLine("Enter Symbol");
                        stockBll.LiveStock(Console.ReadLine());
                        break;
                    case "3":
                        // TODO : Notification
                        break;
                    case "4":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Select Correct option" + "\n");
                        userOption = Console.ReadLine();
                        break;
                }
            }
            var symbol = Console.ReadLine();
            var searchResults = stockBll.Get(symbol);
            if (searchResults.Count == 0)
            {
                Console.Write("This Symbol not found in the our list...");
                Console.ReadKey();
                Environment.Exit(0);
            }
           
            Console.ReadLine();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BankLib;

namespace Mod13Dz
{
    internal class Program
    {
        static Queue<Client> queue = new Queue<Client>();
        static void Main(string[] args)
        {
            FirstMenu();
        }

        static void FirstMenu()
        {
            Console.Clear();
            Console.WriteLine("1) Add client to the queue");
            Console.WriteLine("2) Serve the next client");
            Console.WriteLine("3) Exit the program");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddClientToQueue();
                    break;

                case "2":
                    ServeNextClient();
                    break;

                case "3":
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    Thread.Sleep(3000);
                    FirstMenu();
                    break;
            }
            Console.WriteLine();
        }

        static void AddClientToQueue()
        {
            Console.Clear();
            Console.WriteLine("Select a service:");
            Console.WriteLine("1. Credit");
            Console.WriteLine("2. Open a deposit");
            Console.WriteLine("3. Consultation");
            Console.WriteLine("4. Back to main menu");

            string choice = Console.ReadLine();
            string service = "";

            switch (choice)
            {
                case "1":
                    service = "Credit";
                    break;
                case "2":
                    service = "Open a deposit";
                    break;
                case "3":
                    service = "Consultation";
                    break;
                case "4":
                    FirstMenu();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    Thread.Sleep(3000);
                    AddClientToQueue();
                    break;
            }
            Console.Write("Enter the client's ID: ");
            string id = Console.ReadLine();

            Client client = new Client(id, service);

            queue.Enqueue(client);

            Console.WriteLine($"{client.Service} client {client.Id} added to the queue.");
            PrintQueueStatus();
        }

        static void ServeNextClient()
        {
            if (queue.Count > 0)
            {
                Client client = queue.Dequeue();
                Console.WriteLine($"Service provided to {client.Service} client {client.Id}.");
            }
            else
            {
                Console.WriteLine("Queue is empty. No clients to serve.");
            }

            PrintQueueStatus();
        }

        static void PrintQueueStatus()
        {
            Console.WriteLine();
            Console.WriteLine($"Current queue ({queue.Count} clients):");
            foreach (var client in queue)
            {
                Console.WriteLine($"{client.Service} client {client.Id}");
            }

            Console.WriteLine();
            Console.WriteLine("Return to the main menu [Y/N]?");
            string choice = Console.ReadLine();

            if (choice == "Y" || choice == "y")
            {
                FirstMenu();
            }
            else if (choice == "N" || choice == "n")
            {
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
                Thread.Sleep(3000);
                PrintQueueStatus();
            }
        }
    }
}

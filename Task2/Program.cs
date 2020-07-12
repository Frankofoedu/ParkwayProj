using Newtonsoft.Json;
using System;
using System.IO;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Reading configuration...");
            //read transaction charge config to get charges
            var charges = JsonConvert.DeserializeObject<Data>(File.ReadAllText("fee.json"));

            //collect user input
            Console.WriteLine("Enter your amount to transfer.");

            var inputAmount = int.Parse(Console.ReadLine());

            if (inputAmount < 1 || inputAmount > 999999999)
            {
                Console.WriteLine("Amount is not within range.");
            }

            foreach (var charge in charges.Fees)
            {
                if (inputAmount >= charge.MinAmount && inputAmount <= charge.MaxAmount)
                {
                    Console.WriteLine($"Amount: #{inputAmount}");
                    Console.WriteLine($"Transfer Amount: #{inputAmount - charge.FeeAmount}");
                    Console.WriteLine($"Charge: #{charge.FeeAmount}");
                    Console.WriteLine($"Debit Amount (Transfer Amount + Charge): #{(inputAmount - charge.FeeAmount) + charge.FeeAmount}");
                    
                    break;
                }
            }


            Console.WriteLine("Do you want to try again? Y/N");

            if (Console.ReadLine().ToLower() == "y")
            {
                Main(null);
            }




        }
    }
}

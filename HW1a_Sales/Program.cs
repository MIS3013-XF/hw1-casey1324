// HW1a Sales Total
// Your Name: Casey Wallen
// Did you seek help? If yes, specify the helper or web link here: My CS major friend Luis

using System;
using System.Globalization;

namespace HW1a_Sales
{
    internal class Program
    {
        // Sales tax constant (8.5%)
        private const decimal SalesTaxRate = 0.085m;

        static void Main(string[] args)
        {
            CultureInfo.CurrentCulture = new CultureInfo("en-US");

            // Prompt for product name
            Console.Write("What is the product name of the item you are purchasing? ");
            string itemName = Console.ReadLine()?.Trim();
            if (string.IsNullOrWhiteSpace(itemName))
            {
                itemName = "Item";
            }

            // Get a valid quantity
            int quantity = ReadInt($"How many {itemName}'s do you want to buy? ", 1);

            // Get a valid unit price
            decimal unitPrice = ReadDecimal($"What is the price for each {itemName}? ", 0.01m);

            // Calculations
            decimal subtotal = quantity * unitPrice;
            decimal salesTax = decimal.Round(subtotal * SalesTaxRate, 2, MidpointRounding.AwayFromZero);
            decimal total = subtotal + salesTax;

            // Output
            Console.WriteLine();
            Console.WriteLine($"    Your subtotal for your bill is {subtotal:C2}");
            Console.WriteLine($"    Your sales tax for your bill is {salesTax:C2}");
            Console.WriteLine($"    Your total for your bill is {total:C2}");
            Console.WriteLine();
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }

        // Helper: read integer input with validation
        private static int ReadInt(string prompt, int minValue)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine()?.Trim();
                if (int.TryParse(input, out int value) && value >= minValue)
                {
                    return value;
                }
                Console.WriteLine($"  Please enter a whole number >= {minValue}.");
            }
        }

        // Helper: read decimal input with validation
        private static decimal ReadDecimal(string prompt, decimal minValue)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine()?.Trim();
                if (decimal.TryParse(input, NumberStyles.Number, CultureInfo.CurrentCulture, out decimal value) && value >= minValue)
                {
                    return value;
                }
                Console.WriteLine($"  Please enter a valid amount >= {minValue}.");
            }
        }
    }
}

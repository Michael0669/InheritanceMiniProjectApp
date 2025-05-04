using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceMiniProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<InventoryItemModel> inventory = new List<InventoryItemModel>();
            List<IPurchasable> purchasables = new List<IPurchasable>();
            List<IRentable> rentables = new List<IRentable>();

            var vehicle = new VehicleModel { DealerFee = 25, ProductName = "Kia" };
            var book = new BookModel { ProductName = "Harry Potter", NumberOfPages = 332 };
            var excavator = new ExcavatorModel { ProductName = "Excavator", QuantityInStock = 2 };

            purchasables.Add(vehicle);
            purchasables.Add(book);

            rentables.Add(vehicle);
            rentables.Add(excavator);

            Console.WriteLine("Do you want to rent or purchase something: ");
            string rentalDecision = Console.ReadLine();

            if (rentalDecision.ToLower() == "rent")
            {
                foreach (var item in rentables)
                {
                    Console.WriteLine($"Item {item.ProductName}");
                    Console.Write("Do you want to rent this item: ");
                    string wantToRent = Console.ReadLine();

                    if (wantToRent.ToLower() == "yes")
                    {
                        item.Rent();
                    }

                    Console.WriteLine("Do you want to return this item: ");
                    string wantToReturn = Console.ReadLine();

                    if (wantToReturn.ToLower() == "yes")
                    {
                        item.ReturnRental();
                    }
                }
            }
            else
            {
                foreach (var item in purchasables)
                {
                    Console.WriteLine($"Item {item.ProductName}");
                    Console.Write("Do you want to purchase this item: ");
                    string wantToPurchase = Console.ReadLine();

                    if (wantToPurchase.ToLower() == "yes")
                    {
                        item.Purchase();
                    }
                    else
                    {
                        Console.WriteLine("Thank you, come again.");
                    }
                    
                }
            }

                Console.ReadLine();
        }
    }
}

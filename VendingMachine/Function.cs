using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class Function
    {
        public Dictionary<string, Product> Products = new Dictionary<string, Product>();
        Products prod = new Products();

        public Function()
        {
            this.Products = prod.GetProducts(); //Would have a database normally and would sync in stocklevel through a hangfire job as an example
        } 

        public void DisplayProducts()
        {
            Console.WriteLine($"\n\n{"#".PadRight(5)} {"Stock"} {"Product".PadRight(15)} {"Price".PadLeft(7)}");
            foreach (KeyValuePair<string, Product> prod in this.Products)
            {
                if (prod.Value.StockLevel > 0)
                {
                    string id = prod.Key.PadRight(5);
                    string stockLevel = prod.Value.StockLevel.ToString().PadRight(5);
                    string productName = prod.Value.ProductName.PadRight(15);
                    string price = prod.Value.Price.ToString("C").PadLeft(7);
                    Console.WriteLine($"{id} {stockLevel} {productName} {price} each");
                }
                else
                {
                    Console.WriteLine($"{prod.Key}: {prod.Value.ProductName} Out of Stock.");
                }
            }
        }

        public bool Selection(string input)
        {
            var chosen = this.Products.Where(a => a.Key == input).FirstOrDefault().Value;
            Console.WriteLine();
            if (chosen == null) //Check If input was valid
            { 
                Console.WriteLine("Please select a valid product"); 
                return false; 
            }
            if (chosen.StockLevel == 0)
            {
                Console.WriteLine("This product is out of stock. Please choose another product");
                return false;
            }
            Console.WriteLine("You have chosen " + chosen.ProductName + ". Please insert - £" + chosen.Price);
            return true;
        }
    }
}

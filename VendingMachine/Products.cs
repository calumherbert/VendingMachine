using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class Products
    {
        public Dictionary<string, Product> GetProducts()
        {
            Dictionary<string, Product> Products = new Dictionary<string, Product>
            {
                { "0", new Product("Cola", 1.00M, 10) },
                { "1", new Product("Crisps", 0.50M, 20) },
                { "2", new Product("Chocolate", 0.60M, 0) },
            };
            return Products; ;
        }
    }
}

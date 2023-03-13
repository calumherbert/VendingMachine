using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class Product
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int StockLevel { get; set; }
        public Product(string productName, decimal price, int stocklevel)
        {
            this.ProductName = productName;
            this.Price = price;
            this.StockLevel = stocklevel;
        }
    }

}

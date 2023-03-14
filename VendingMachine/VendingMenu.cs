using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class VendingMenu
    {

        public VendingMenu() { }
        public bool MenuHeader()
        {
            Vend func = new Vend();
            Money mon = new Money();
            var productPrice = 0M;
            var productInput = "";
            var exactChangeRequired = false;
            var coinMessage = "INSERT COINS";
            if (exactChangeRequired) { coinMessage = "EXACT CHANGE ONLY"; }
            //would have a database call that checks the change levels within the machine to determine whether exact change is required. Update Method for topping change levels up as and when.
            //Can set to true if you want exact change to be used!
            var T = false;
            while (T == false)
            {
                Console.WriteLine("Please select a product by ID (0,1,2)");
                func.DisplayProducts();
                Console.WriteLine();
                while (T == false)
                {
                    productInput = Console.ReadLine();
                    var result = func.Selection(productInput);
                    if (result.IsValid == true)
                    {
                        productPrice = result.Product.Price;
                        T = result.IsValid;
                    }
                }
            }
            T = false;
            Console.WriteLine(coinMessage);
            while (T == false)
            {
                string input = Console.ReadLine();
                bool t = mon.AddMoney(input, productPrice, exactChangeRequired);
                T = t;
            }
            Console.ReadLine();
            Console.Clear();
            return false;
        }
    }
}

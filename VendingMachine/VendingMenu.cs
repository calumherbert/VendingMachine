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
        public void MenuHeader()
        {
            Function func = new Function();
            var T = false;
            while (true)
            {
                Console.WriteLine("Please select a product");
                func.DisplayProducts();
                Console.WriteLine();
                while (T == false)
                {
                    string input = Console.ReadLine();
                    T = func.Selection(input);
                }
                              
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}

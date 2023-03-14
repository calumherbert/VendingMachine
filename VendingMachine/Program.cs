using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class Program
    {
        public static void Main()
        {
            bool t = false;
            while (t == false)
            {
                VendingMenu vendingMenu = new VendingMenu();
                t = vendingMenu.MenuHeader();
            }

        }
    }
}

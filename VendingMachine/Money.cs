using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class Money
    {
        public decimal MoneyInMachine { get; private set; }
        public Money()
        {
            this.MoneyInMachine = 0M;
        }

        public bool AddMoney(string amount, decimal productPrice, bool exactChangeRequired)
        {
            var realAmount = new Regex(@"([0-9]+)").Match(amount).Groups[1].Value;
            var insertMessage = "INSERT COINS";
            if (exactChangeRequired == true)
            {
                insertMessage = "EXACT CHANGE ONLY";
            }
            if (!decimal.TryParse(realAmount, out decimal amountInserted)) //Check for real money
            {
                amountInserted = 0M;
                if (this.MoneyInMachine == 0M || amountInserted == 0M)
                {
                    Console.WriteLine("Invalid Currency In Change Pot");
                    Console.WriteLine("£{0} Current Balance. Product Price - £{1}", this.MoneyInMachine, productPrice);
                    Console.WriteLine(insertMessage);
                }
                return false;
            }
            //Ontop of above. Taking the assumption that only the follow currency coins exists in the uk (1p, 2p, 5p, 10p, 20p, 50p, £1, £2)
            //Could add a list/ table simular to the products and restrict input to match/ check for the above values only. I guess would be needed if foreign currency was added?!

            if (amount.Contains("£"))
            {
                amountInserted = amountInserted * 100;//convert to pence
            }
            this.MoneyInMachine += amountInserted / 100;
            if (this.MoneyInMachine >= productPrice && exactChangeRequired == false)
            {
                Console.WriteLine("THANKYOU");
                Console.WriteLine("{0} In Change Pot", (this.MoneyInMachine) - productPrice);
                this.MoneyInMachine = 0M;
                Console.WriteLine("Press Enter to Start. Current Balance {0}", this.MoneyInMachine);
                return true;
            }
            if (this.MoneyInMachine >= productPrice && exactChangeRequired == true)
            {
                Console.WriteLine("THANKYOU");
                Console.WriteLine("No Change Given");
                this.MoneyInMachine = 0M;
                Console.WriteLine("Press Enter to Start. Current Balance {0}", this.MoneyInMachine);
                return true;
            }
            if (this.MoneyInMachine > 0M)
            {
                Console.WriteLine("£{0} Current Balance. Product Price - £{1}", this.MoneyInMachine, productPrice); //Show current amount  
                Console.WriteLine(insertMessage);
            }
            else
            {
                Console.WriteLine(insertMessage);
            }

            return false;
        }
    }
}

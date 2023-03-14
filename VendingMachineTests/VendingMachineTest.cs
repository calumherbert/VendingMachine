using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using VendingMachine;

namespace VendingMachineTests
{
    [TestClass]
    public class VendingMachineTest
    {
        [TestMethod]
        public void DisplayProducts()
        {
            Vend fn = new Vend();
            fn.DisplayProducts();
        }

        [DataTestMethod]
        [DataRow("G", false)] //Invalid selection
        [DataRow("0", true)]
        [DataRow("1", true)]
        [DataRow("2", false)] //Out of stock
        public void ValidSelectionInStock(string input, bool expected)
        {
            Vend fn = new Vend();
            var result = fn.Selection(input);
            Assert.AreEqual(expected, result.IsValid);
        }

        [DataTestMethod]
        [DataRow("50", 50)]
        [DataRow("40", 20)]
        [DataRow("30", 30)]
        [DataRow("20", 20)]
        public void AddingMoney(string input, int expected)
        {
            Vend fn = new Vend();
            var productPrice = 0.5M;
            fn.Money.AddMoney(input, productPrice);
            decimal result = fn.Money.MoneyInMachine;
            Assert.AreEqual((decimal)expected, result);
        }

        [DataTestMethod]
        [DataRow("button", false)]
        [DataRow("20", true)]
        [DataRow("50", true)]
        [DataRow("plastic", false)]
        [DataRow("0", true)]
        public void ValidatingMoney(string input, bool expected)
        {
            Money fn = new Money();
            var productPrice = 0.5M;
            bool result = fn.AddMoney(input, productPrice);
            Assert.AreEqual(expected, result);
        }
    }
}

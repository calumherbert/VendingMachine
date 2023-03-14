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
        [DataRow("50p", true)]
        [DataRow("Button", false)]
        [DataRow("£1", true)]
        [DataRow("Box", false)]
        public void AddingMoney(string input, bool expected)
        {
            Money fn = new Money();
            var productPrice = 0.5M;
            bool t = fn.AddMoney(input, productPrice, false);           
            Assert.AreEqual(expected, t);
        } 
    }
}

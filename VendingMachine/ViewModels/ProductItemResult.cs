using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.ViewModels
{
    public class ProductItemResult
    {
        public bool IsValid { get; set; }
        public Product Product { get; set; }
    }
}

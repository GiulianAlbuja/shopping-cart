using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartEntity
{
    public class Cart
    {
        public int IdCart { get; set; }
        public Customer ObjectCustomer { get; set; }
        public Product ObjectProduct { get; set; }
        public int Quantity { get; set; }
    }
}

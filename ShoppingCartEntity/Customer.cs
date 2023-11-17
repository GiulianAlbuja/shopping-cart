using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartEntity
{
    public class Customer
    {
        public int IdCustomer { get; set; }
        public String CustomerNames { get; set; }
        public String CustomerLastNames { get; set; }
        public String CustomerEmail { get; set; }
        public String CustomerPassword { get; set; }
        public bool ResetPassword { get; set; }
    }
}

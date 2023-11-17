using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartEntity
{
    public class SaleDetail
    {
        public int IdSaleDetail { get; set; }
        public int IdSale { get; set; }
        public Product ObjectProduct { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
        public String IdTransaction { get; set; }
    }
}

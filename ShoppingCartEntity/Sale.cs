using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartEntity
{
    public class Sale
    {
        //Por que aqui no hace referencia?
        public int IdSale { get; set; }
        public int IdCustomer { get; set; }
        public int TotalProduct { get; set; }
        public decimal TotalAmount { get; set; }
        public String Contact { get; set; }
        public String IdDistrict { get; set; }
        public String Phone { get; set; }
        public String ShippingAddress { get; set; }
        public String IdTransaction { get; set; }
        public String SaleDate { get; set; }
        public List<SaleDetail> ObjectsSaleDetail { get; set;}


    }
}

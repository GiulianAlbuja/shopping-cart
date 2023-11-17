using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartEntity
{
    public class Product
    {
        public int IdProduct { get; set; }
        public String ProductName { get; set; }
        public String ProductDescription { get; set; }
        public Brand ObjectBrand { get; set; }
        public Category ObjectCategory { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public String ImagePath { get; set; }
        public String ImageName { get; set; }
        public bool Asset { get; set; }
    }
}

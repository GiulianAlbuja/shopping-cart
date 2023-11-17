using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartEntity
{
    public class User
    {
        public int IdUser { get; set; }
        public String UserNames { get; set; }
        public String UserLastNames { get; set; }
        public String Email { get; set; }
        public String UserPassword { get; set; }
        public bool ResetPassword { get; set; }
        public bool Asset { get; set; }
    }
}

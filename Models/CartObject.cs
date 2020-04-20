using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlikHalafim.Models
{
    public class CartObject
    {
        public int ProductId { get; set; }
        public int ProductQuantiy { get; set; }

        public bool Equals(CartObject other)
        {
            if (other == null) return false;
            return this.ProductId == other.ProductId;
        }
    }
}

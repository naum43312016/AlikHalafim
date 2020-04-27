using AlikHalafim.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlikHalafim.ViewModel
{
    public class OrderDetailViewModel
    {
        public Order Order { get; set; }
        public List<CartItemForDb> Products { get; set; }
    }
}

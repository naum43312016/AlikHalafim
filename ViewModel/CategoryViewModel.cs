using AlikHalafim.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlikHalafim.ViewModel
{
    public class CategoryViewModel
    {
        public List<List<Category>> RegCategories { get; set; }
        public List<List<Category>> PartsCategories { get; set; }
    }
}

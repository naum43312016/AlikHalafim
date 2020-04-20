using AlikHalafim.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlikHalafim.ViewModel
{
    public class PartsCategoryViewModel
    {
        public Category Main { get; set; }
        public List<Category> SubCategories { get; set; }
    }
}

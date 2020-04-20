using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AlikHalafim.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        public string CategoryName { get; set; }

        public string CategoryImage { get; set; }

        public Nullable<int> ParentCategoryId { get; set; }

        [ForeignKey("ParentCategoryId")]
        public virtual Category ParentCategory { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AlikHalafim.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string CatalogNumber { get; set; }//מקט
        public string OriginalNumbers { get; set; }


        [Required]
        public int Quantity { get; set; }
        [Required]
        public string Price { get; set; }

        public int Rank { get; set; }

        public string BigDescription { get; set; }
        public string ProductName { get; set; }
        public string MainDescription { get; set; }
        public string Manufacturer { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; } //Category Id

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        public string ProductImage { get; set; }
        public string Vehicles { get; set; }
    }
}

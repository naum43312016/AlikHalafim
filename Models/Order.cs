using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlikHalafim.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public string Status { get; set; }

        public string UserId { get; set; }

        public double Total { get; set; }
        public double SubTotal { get; set; }

        public DateTime OrderDate { get; set; }

        public string PaymentStatus { get; set; }


        public string Comments { get; set; }
        public string PaymentMethod { get; set; }
        public string DeliveryMethod { get; set; }


        [Required(ErrorMessage = "נא למלא")]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "נא למלא")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "נא למלא")]
        public string Email { get; set; }

        [Required(ErrorMessage = "נא למלא")]
        public string PhoneNumber { get; set; }

        public string TransactionId { get; set; }

        [Required(ErrorMessage = "נא למלא")]
        public string City { get; set; }
        
        [Required(ErrorMessage = "נא למלא")]
        public string Address { get; set; }

        [Required(ErrorMessage = "נא למלא")]
        public string HouseNumber { get; set; }

        public string AppartmentNumber { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Abc.Entity.Concrete
{
    public class ShippingDetails
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Adres { get; set; }

        [Required]
        [Range(15, 75)]
        public int Age { get; set; }
    }
}

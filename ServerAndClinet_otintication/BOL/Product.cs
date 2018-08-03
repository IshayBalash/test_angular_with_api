using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public class Product
    {
        [Required]
        public string ProductName { get; set; }

        [PriceValidation]
        public int ProductPrice { get; set; }
    }
}

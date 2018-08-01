using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Product
    {
        
        public string ProductName { get; set; }


        [PriceValidation]
        public int Price { get; set; } = 10;
    }
}
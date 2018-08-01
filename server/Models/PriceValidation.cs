using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class PriceValidation:ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            bool result = int.TryParse(value.ToString(), out int num);
            if (result)
            {
                if (num > 10 && num < 40)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
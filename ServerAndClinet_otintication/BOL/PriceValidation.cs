using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public class PriceValidation:ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            bool Result = int.TryParse(value.ToString(), out int num);
            if (Result) {
                if (num > 10 && num < 100)
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

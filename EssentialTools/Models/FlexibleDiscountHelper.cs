using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EssentialTools.Models
{
    public class FlexibleDiscountHelper: IDiscountHelper
    {
        decimal IDiscountHelper.ApplyDiscount(decimal totalParam)
        {
            decimal discount = totalParam > 100 ? 70 : 25;
            return (totalParam - (discount / 100m * totalParam));
        }
    }
}
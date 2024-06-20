using System.Collections.Generic;
using ECommerce.Core.Models;

namespace ECommerce.Core.Models
{
    public class LayoutViewModel
    {
        public int CartItemsCount { get; set; }
        public decimal CartTotalPrice { get; set; }
        public IEnumerable<Product> Products { get; set; } = new List<Product>();
    }
}

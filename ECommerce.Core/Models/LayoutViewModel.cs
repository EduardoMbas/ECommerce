namespace ECommerce.Web.Models
{
    public class LayoutViewModel
    {
        public IEnumerable<ECommerce.Core.Models.Product> Products { get; set; }
        public int CartItemsCount { get; set; }
        public decimal CartTotalPrice { get; set; }
    }
}

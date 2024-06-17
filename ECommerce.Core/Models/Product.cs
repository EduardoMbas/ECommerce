namespace ECommerce.Core.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public string ImageUrl { get; set; }

        // Construtor sem parâmetros
        public Product()
        {
        }

        // Construtor com parâmetros (opcional)
        public Product(int id, string name, string description, decimal price, string category, string imageUrl)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            Category = category;
            ImageUrl = imageUrl;
        }
    }
}

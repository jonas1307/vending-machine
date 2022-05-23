using VendingMachine.Domain.Contracts;

namespace VendingMachine.Domain
{
    public class ProductGrid : IProductGrid
    {
        public ProductGrid()
        {
            // Seed products
            AddProduct(1, "Chips", 325, 1);
            AddProduct(2, "Chocolate", 125, 1);
            AddProduct(3, "Fancy Chocolate", 250, 1);
            AddProduct(4, "Mints", 175, 1);
            AddProduct(5, "Soda", 150, 1);
        }

        private IList<Product> Products { get; } = new List<Product>();

        public Product AddProduct(int id, string name, int value, int quantity)
        {
            if (Products.Any(x => x.Id == id)) throw new ArgumentException($"Id {id} is already assigned to another product");

            var product = new Product(id, name, value, quantity);
            Products.Add(product);

            return product;
        }

        public Product GetProduct(int id)
        {
            var product = Products.SingleOrDefault(x => x.Id == id);

            if (product == default) throw new ArgumentException($"No product with id {id} was found");

            return product;
        }

        public IList<Product> GetAllProducts() => Products;
    }
}

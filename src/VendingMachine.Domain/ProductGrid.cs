using VendingMachine.Domain.Contracts;

namespace VendingMachine.Domain
{
    public class ProductGrid : IProductGrid
    {
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

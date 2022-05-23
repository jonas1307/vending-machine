namespace VendingMachine.Domain.Contracts
{
    public interface IProductGrid
    {
        Product AddProduct(int id, string name, int value, int quantity);
        Product GetProduct(int id);
        IList<Product> GetAllProducts();
    }
}

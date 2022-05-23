namespace VendingMachine.Domain.UnitTests
{
    public class ProductGridTests
    {
        [Fact(DisplayName = "should throw an ArgumentException when adding product with existing id")]
        public void AddProduct_IdAlreadyExists_ThrowsArgumentException()
        {
            var grid = new ProductGrid();
            grid.AddProduct(1, "Chips", 300, 1);

            var ex = Record.Exception(() => grid.AddProduct(1, "Chocolate", 100, 1));

            Assert.IsType<ArgumentException>(ex);
        }

        [Fact(DisplayName = "should throw an ArgumentException when querying a invalid id for a product")]
        public void GetProduct_IdDoesntExists_ThrowsArgumentException()
        {
            var grid = new ProductGrid();
            grid.AddProduct(1, "Chips", 300, 1);

            var ex = Record.Exception(() => grid.GetProduct(2));

            Assert.IsType<ArgumentException>(ex);
        }

        [Fact(DisplayName = "should return a list of products")]
        public void GetAllProducts_WhenCalled_ReturnsProductList()
        {
            var grid = new ProductGrid();
            grid.AddProduct(1, "Chips", 300, 1);
            grid.AddProduct(2, "Soda", 100, 1);

            var result = grid.GetAllProducts();

            Assert.IsAssignableFrom<IList<Product>>(result);
        }
    }
}

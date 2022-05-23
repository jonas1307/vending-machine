using VendingMachine.Domain.Exceptions;

namespace VendingMachine.Domain.UnitTests
{
    public class ProductTests
    {
        [Fact(DisplayName = "should throw a ProductNotAvailable exception if a product is not available")]
        public void Sell_ProductNotAvailable_ThrowsProductNotAvailableException()
        {
            var product = new Product(1, "Chips", 100, 0);

            Assert.Throws<ProductNotAvailableException>(() => product.Sell(100));
        }

        [Fact(DisplayName = "should throw an InsufficientFundsException exception if a product is underpaid")]
        public void Sell_ProductUnderpaid_ThrowsInsufficientFundsException()
        {
            var product = new Product(1, "Chips", 100, 1);

            Assert.Throws<InsufficientFundsException>(() => product.Sell(90));
        }
    }
}

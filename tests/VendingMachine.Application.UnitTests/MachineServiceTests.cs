using VendingMachine.Domain;
using VendingMachine.Domain.Exceptions;

namespace VendingMachine.Application.UnitTests
{
    public class MachineServiceTests
    {
        [Fact(DisplayName = "should sell a product and return the corresponding change")]
        public void SellProduct_ValidParameters_ShouldReturnSale()
        {
            var customerStack = new CustomerCoinStack();
            customerStack.Push(100);
            customerStack.Push(50);

            var machineStack = new MachineCoinStack();
            machineStack.AddCoin(5);
            machineStack.AddCoin(25);

            var productGrid = new ProductGrid();
            productGrid.AddProduct(1, "Chips", 120, 10);

            var changeService = new ChangeService(machineStack);

            var service = new MachineService(customerStack, machineStack, productGrid, changeService);

            var result = service.SellProduct(1);

            var product = result.Product;
            Assert.Equal(1, product.Id);
            Assert.Equal("Chips", product.Name);
            Assert.Equal(120, product.Value);
            Assert.Equal(9, product.Quantity);

            var change = result.Change;
            Assert.Equal(new int[] { 5, 25 }, change);
        }

        [Fact(DisplayName = "should throw a ArgumentException when trying to sell a invalid product")]
        public void SellProduct_InvalidProduct_ThrowsArgumentException()
        {
            var customerStack = new CustomerCoinStack();
            customerStack.Push(100);
            customerStack.Push(50);

            var machineStack = new MachineCoinStack();
            machineStack.AddCoin(5);
            machineStack.AddCoin(25);

            var productGrid = new ProductGrid();
            productGrid.AddProduct(1, "Chips", 120, 10);

            var changeService = new ChangeService(machineStack);

            var service = new MachineService(customerStack, machineStack, productGrid, changeService);

            Assert.Throws<ArgumentException>(() => service.SellProduct(2));
        }

        [Fact(DisplayName = "should throw a NotEnoughChangeException when there is not enough change for a sale")]
        public void SellProduct_NotEnoughChange_ThrowsNotEnoughChangeException()
        {
            var customerStack = new CustomerCoinStack();
            customerStack.Push(100);
            customerStack.Push(50);

            var machineStack = new MachineCoinStack();
            machineStack.AddCoin(10);

            var productGrid = new ProductGrid();
            productGrid.AddProduct(1, "Chips", 120, 10);

            var changeService = new ChangeService(machineStack);

            var service = new MachineService(customerStack, machineStack, productGrid, changeService);

            Assert.Throws<ArgumentException>(() => service.SellProduct(2));
        }

        [Fact(DisplayName = "should throw a ProductNotAvailableException when a product is not available")]
        public void SellProduct_ProductNotAvailable_ThrowsProductNotAvailableException()
        {
            var customerStack = new CustomerCoinStack();
            customerStack.Push(100);
            customerStack.Push(50);

            var machineStack = new MachineCoinStack();
            machineStack.AddCoin(5);
            machineStack.AddCoin(25);

            var productGrid = new ProductGrid();
            productGrid.AddProduct(1, "Chips", 120, 0);

            var changeService = new ChangeService(machineStack);

            var service = new MachineService(customerStack, machineStack, productGrid, changeService);

            Assert.Throws<ProductNotAvailableException>(() => service.SellProduct(1));
        }

        [Fact(DisplayName = "should throw a InsufficientFundsException due to insufficient funds")]
        public void SellProduct_InsufficientCoinsInserted_ThrowsInsufficientFundsException()
        {
            var customerStack = new CustomerCoinStack();
            customerStack.Push(100);

            var machineStack = new MachineCoinStack();
            machineStack.AddCoin(5);
            machineStack.AddCoin(25);

            var productGrid = new ProductGrid();
            productGrid.AddProduct(1, "Chips", 120, 0);

            var changeService = new ChangeService(machineStack);

            var service = new MachineService(customerStack, machineStack, productGrid, changeService);

            Assert.Throws<ProductNotAvailableException>(() => service.SellProduct(1));
        }

        [Fact(DisplayName = "should return the sum of the inserted coin's values")]
        public void GetPaidAmmount_WhenCalled_ReturnsInsertedCoinsValue()
        {
            var customerStack = new CustomerCoinStack();

            var machineStack = new MachineCoinStack();

            var productGrid = new ProductGrid();

            var changeService = new ChangeService(machineStack);

            var service = new MachineService(customerStack, machineStack, productGrid, changeService);

            customerStack.Push(100);
            customerStack.Push(100);

            var result = service.GetPaidAmmount();

            Assert.Equal(200, result);
        }

        [Fact(DisplayName = "should add the inserted coins to the user stack")]
        public void AddCoin_WhenCalled_AddsCoinToStack()
        {
            var customerStack = new CustomerCoinStack();

            var machineStack = new MachineCoinStack();
            machineStack.AddCoin(5);
            machineStack.AddCoin(25);

            var productGrid = new ProductGrid();
            productGrid.AddProduct(1, "Chips", 120, 0);

            var changeService = new ChangeService(machineStack);

            var service = new MachineService(customerStack, machineStack, productGrid, changeService);
            service.AddCoin(100);

            Assert.Equal(100, customerStack.GetSum());
        }

        [Fact(DisplayName = "should release the inserted coins")]
        public void ReleaseCoins_WhenCalled_ReturnsInsertedCoins()
        {
            var customerStack = new CustomerCoinStack();

            var machineStack = new MachineCoinStack();

            var productGrid = new ProductGrid();

            var changeService = new ChangeService(machineStack);

            var service = new MachineService(customerStack, machineStack, productGrid, changeService);
            service.AddCoin(100);
            service.AddCoin(25);

            var result = service.ReleaseCoins();

            Assert.Equal(new int[] { 25, 100 }, result);
        }
    }
}

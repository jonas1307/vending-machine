using VendingMachine.Application.Contracts;
using VendingMachine.Domain;
using VendingMachine.Domain.Contracts;

namespace VendingMachine.Application
{
    public class MachineService : IMachineService
    {
        private readonly ICustomerCoinStack _customerCoinStack;
        private readonly IMachineCoinStack _machineCoinStack;
        private readonly IProductGrid _productGrid;

        private readonly IChangeService _changeService;

        public MachineService(ICustomerCoinStack customerCoinStack, IMachineCoinStack machineCoinStack, IProductGrid productGrid, IChangeService changeService)
        {
            _customerCoinStack = customerCoinStack;
            _machineCoinStack = machineCoinStack;
            _productGrid = productGrid;
            _changeService = changeService;
        }

        public void AddCoin(int faceValue) => _customerCoinStack.Push(faceValue);

        public int GetPaidAmmount() => _customerCoinStack.GetSum();

        public int[] ReleaseCoins() => _customerCoinStack.Flush();

        public Sale SellProduct(int productId)
        {
            var product = _productGrid.GetProduct(productId);
            var paidAmmount = _customerCoinStack.GetSum();
            var change = _changeService.CalculateChange(paidAmmount - product.Value).ToArray();

            product.Sell(paidAmmount);

            while (_customerCoinStack.TryPop(out var coin))
            {
                _machineCoinStack.AddCoin(coin);
            }

            return new Sale(product, change);
        }
    }
}

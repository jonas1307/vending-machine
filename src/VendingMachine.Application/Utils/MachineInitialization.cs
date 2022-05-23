using VendingMachine.Domain;
using VendingMachine.Domain.Contracts;

namespace VendingMachine.Application.Utils
{
    public class MachineInitialization
    {
        private bool _initialized;
        private readonly IMachineCoinStack _machineCoinStack;
        private readonly IProductGrid _productGrid;

        public MachineInitialization(IMachineCoinStack machineCoinStack, IProductGrid productGrid)
        {
            _machineCoinStack = machineCoinStack;
            _productGrid = productGrid;
        }

        public void Initialize()
        {
            if (_initialized) return;

            // Seeding coins
            for (int i = 0; i < 100; i++)
            {
                foreach (var faceValue in Settings.CoinFaceValues)
                {
                    _machineCoinStack.AddCoin(faceValue);
                }
            }

            // Seeding products
            _productGrid.AddProduct(1, "Chips", 325, 10);
            _productGrid.AddProduct(2, "Chocolate", 125, 10);
            _productGrid.AddProduct(3, "Fancy Chocolate", 250, 10);
            _productGrid.AddProduct(4, "Mints", 175, 10);
            _productGrid.AddProduct(5, "Soda", 150, 10);

            _initialized = true;
        }
    }
}

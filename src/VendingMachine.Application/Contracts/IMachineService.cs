using VendingMachine.Domain;

namespace VendingMachine.Application.Contracts
{
    public interface IMachineService
    {
        void AddCoin(int faceValue);
        int GetPaidAmmount();
        int[] ReleaseCoins();
        Sale SellProduct(int productId);
    }
}

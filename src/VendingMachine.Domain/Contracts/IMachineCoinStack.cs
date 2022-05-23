namespace VendingMachine.Domain.Contracts
{
    public interface IMachineCoinStack
    {
        void AddCoin(int faceValue);
        bool HasEnoughCoins(int faceValue, int amount);
        void RemoveCoin(int faceValue);
    }
}

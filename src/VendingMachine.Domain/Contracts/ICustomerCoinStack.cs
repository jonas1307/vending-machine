namespace VendingMachine.Domain.Contracts
{
    public interface ICustomerCoinStack
    {
        int[] Flush();
        int GetSum();
        int Push(int coin);
        bool TryPop(out int coin);
    }
}

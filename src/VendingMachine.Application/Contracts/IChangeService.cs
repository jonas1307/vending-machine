namespace VendingMachine.Application.Contracts
{
    public interface IChangeService
    {
        Stack<int> CalculateChange(int change);
    }
}

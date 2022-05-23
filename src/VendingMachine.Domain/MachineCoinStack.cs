using VendingMachine.Domain.Exceptions;

namespace VendingMachine.Domain
{
    public class MachineCoinStack : Stack<int>
    {
        private Dictionary<int, int> Coins { get; } = new Dictionary<int, int>();

        public MachineCoinStack()
        {
            Coins.Add(5, 0);
            Coins.Add(10, 0);
            Coins.Add(25, 0);
            Coins.Add(50, 0);
            Coins.Add(100, 0);
        }

        public void AddCoin(int faceValue) => Coins[faceValue] += 1;

        public void RemoveCoin(int faceValue)
        {
            if (Coins[faceValue] <= 0) throw new NotEnoughChangeException($"{faceValue} coins are not available");

            Coins[faceValue] -= 1;
        }

        public bool HasEnoughCoins(int faceValue, int amount) => Coins[faceValue] >= amount;
    }
}

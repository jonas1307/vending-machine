using VendingMachine.Domain.Contracts;
using VendingMachine.Domain.Exceptions;

namespace VendingMachine.Domain
{
    public class MachineCoinStack : Stack<int>, IMachineCoinStack
    {
        private Dictionary<int, int> Coins { get; } = new Dictionary<int, int>();

        public MachineCoinStack()
        {
            foreach (var coin in Settings.CoinFaceValues)
            {
                Coins.Add(coin, 0);
            }
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

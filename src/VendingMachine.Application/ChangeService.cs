using VendingMachine.Application.Contracts;
using VendingMachine.Domain;

namespace VendingMachine.Application
{
    public class ChangeService : IChangeService
    {
        public Stack<int> CalculateChange(int change)
        {
            var result = new Stack<int>();

            foreach (var value in Settings.CoinFaceValues)
            {
                SelectCoins(ref change, result, value);
            }

            return result;
        }

        private void SelectCoins(ref int change, Stack<int> coins, int faceValue)
        {
            while (change >= faceValue)
            {
                change -= faceValue;
                coins.Push(faceValue);
            }
        }
    }
}

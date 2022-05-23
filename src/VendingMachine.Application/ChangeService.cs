using VendingMachine.Application.Contracts;

namespace VendingMachine.Application
{
    public class ChangeService : IChangeService
    {
        public Stack<int> CalculateChange(int change)
        {
            var result = new Stack<int>();

            var faceValues = new int[] { 100, 50, 25, 10, 5 };

            foreach (var value in faceValues)
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

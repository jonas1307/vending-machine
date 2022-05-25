using VendingMachine.Application.Contracts;
using VendingMachine.Domain;
using VendingMachine.Domain.Contracts;
using VendingMachine.Domain.Exceptions;

namespace VendingMachine.Application
{
    public class ChangeService : IChangeService
    {
        private readonly IMachineCoinStack _machineCoinStack;

        public ChangeService(IMachineCoinStack machineCoinStack)
        {
            _machineCoinStack = machineCoinStack;
        }

        public Stack<int> CalculateChange(int change)
        {
            var changeStack = new Stack<int>();
            var tempChangeStack = new Dictionary<int, int>();

            foreach (var value in Settings.CoinFaceValues)
            {
                var coins = SelectCoins(ref change, value);
                tempChangeStack.Add(value, coins);
            }

            if (change > 0) throw new NotEnoughChangeException("not enough change for selling the selected product");

            ReleaseCoins(changeStack, tempChangeStack);

            return changeStack;
        }

        private int SelectCoins(ref int change, int faceValue)
        {
            var totalCoins = change / faceValue;

            if (totalCoins == 0) return 0;
            if (!_machineCoinStack.HasEnoughCoins(faceValue, totalCoins)) return 0;

            change -= faceValue * totalCoins;

            return totalCoins;
        }

        private void ReleaseCoins(Stack<int> changeStack, Dictionary<int, int> tempChangeStack)
        {
            foreach (var faceValue in tempChangeStack.Keys)
            {
                for (int i = 0; i < tempChangeStack[faceValue]; i++)
                {
                    _machineCoinStack.RemoveCoin(faceValue);
                    changeStack.Push(faceValue);
                }
            }
        }
    }
}

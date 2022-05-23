namespace VendingMachine.Domain
{
    public class CustomerCoinStack : Stack<int>
    {
        public Stack<int> Coins { get; } = new Stack<int>();

        public new int Push(int coin)
        {
            Coins.Push(coin);

            return GetSum();
        }

        public new bool TryPop(out int coin) => Coins.TryPop(out coin);

        public int GetSum() => Coins.Sum();

        public int[] Flush()
        {
            var result = Coins.ToArray();

            Coins.Clear();

            return result;
        }
    }
}

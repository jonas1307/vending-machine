using VendingMachine.Domain.Exceptions;

namespace VendingMachine.Domain.UnitTests
{
    public class MachineCoinStackTests
    {
        [Fact]
        public void RemoveCoin_CoinDoesntExist_Throws()
        {
            var stack = new MachineCoinStack();

            Assert.Throws<NotEnoughChangeException>(() => stack.RemoveCoin(5));
        }
    }
}

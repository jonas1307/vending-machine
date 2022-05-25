using VendingMachine.Domain;
using VendingMachine.Domain.Contracts;
using VendingMachine.Domain.Exceptions;

namespace VendingMachine.Application.UnitTests
{
    public class ChangeServiceTests
    {
        private readonly IMachineCoinStack _machineCoinStack = new MachineCoinStack();

        public ChangeServiceTests()
        {
            for (int i = 0; i < 10; i++)
            {
                _machineCoinStack.AddCoin(50);
                _machineCoinStack.AddCoin(100);
            }

            _machineCoinStack.AddCoin(10);
            _machineCoinStack.AddCoin(25);
        }

        [Theory(DisplayName = "should return the correct change if the machine stack has enough coins")]
        [InlineData(90, 100, new int[0])]
        [InlineData(100, 100, new int[0])]
        [InlineData(200, 100, new int[] { 100 })]
        [InlineData(300, 150, new int[] { 50, 100 })]
        [InlineData(250, 150, new int[] { 100 })]
        [InlineData(285, 150, new int[] { 10, 25, 100 })]
        public void CalculateChange_StackHasEnoughCoins_ReturnsCorrectChange(int paidAmmount, int price, int[] expectedResult)
        {
            var service = new ChangeService(_machineCoinStack);

            var result = service.CalculateChange(paidAmmount - price);

            Assert.Equal(expectedResult, result.ToArray());
        }

        [Theory(DisplayName = "should throw a NotEnoughChangeException if the stack can't provide the change")]
        [InlineData(5)]
        [InlineData(30)]
        public void CalculateChange_StackDoesNotHaveEnoughCoins_ThrowsNotEnoughChangeException(int change)
        {
            var service = new ChangeService(_machineCoinStack);

            Assert.Throws<NotEnoughChangeException>(() => service.CalculateChange(change));
        }
    }
}

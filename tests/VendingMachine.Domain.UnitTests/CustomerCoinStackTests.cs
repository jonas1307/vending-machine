namespace VendingMachine.Domain.UnitTests
{
    public class CustomerCoinStackTests
    {
        [Fact(DisplayName = "should sum coin values as they are added to the stack")]
        public void CustomerCoinStack_PushValue_ShouldReturnCorrectSum()
        {
            var stack = new CustomerCoinStack();

            var result = stack.Push(25);
            Assert.True(result == 25);

            result = stack.Push(5);
            Assert.True(result == 30);
        }

        [Fact(DisplayName = "should pop a coin from the stack after it has been added")]
        public void CustomerCoinStack_PopValue_ShouldReturnCorrectValue()
        {
            var stack = new CustomerCoinStack();
            stack.Push(100);

            stack.TryPop(out var coin);

            Assert.True(coin == 100);
        }
    }
}

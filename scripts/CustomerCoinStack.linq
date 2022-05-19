<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();
}

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

#region private::Tests

[Fact]
void CustomerCoinStack_PushValue_ShouldReturnCorrectSum()
{
	var stack = new CustomerCoinStack();
	
	var result = stack.Push(25);
	Assert.True(result == 25);
	
	result = stack.Push(5);
	Assert.True(result == 30);
}

[Fact]
void CustomerCoinStack_PopValue_ShouldReturnCorrectValue()
{
	var stack = new CustomerCoinStack();
	
	stack.Push(100);
	stack.TryPop(out var coin);
	
	Assert.True(coin == 100);
}

#endregion
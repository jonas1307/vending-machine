<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();
}

Stack<int> CalculateChange(int change)
{
	var result = new Stack<int>();
	
	var faceValues = new int[] { 100, 50, 25, 10, 5 };
	
	foreach (var value in faceValues)
	{
		SelectCoins(ref change, result, value);
	}
	
	return result;
}

void SelectCoins(ref int change, Stack<int> coins, int faceValue)
{
	while (change >= faceValue)
	{
		change -= faceValue;
		coins.Push(faceValue);
	}
}

#region private::Tests

[Theory]
[InlineData(110, 120, new int[0])]
[InlineData(120, 120, new int[0])]
[InlineData(130, 120, new int[] { 10 })]
[InlineData(140, 120, new int[] { 10, 10 })]
[InlineData(150, 120, new int[] { 5, 25 })]
[InlineData(160, 120, new int[] { 5, 10, 25 })]
[InlineData(170, 120, new int[] { 50 })]
[InlineData(220, 120, new int[] { 100 })]
[InlineData(500, 120, new int[] { 5, 25, 50, 100, 100, 100 })]
void CalculateChange_OnCall_ReturnCorrectStack(int paidAmmount, int price, int[] expectedResult)
{
	var change = paidAmmount - price;
	
	var result = CalculateChange(change);
	
	Assert.Equal(expectedResult, result.ToArray());
}

#endregion
<Query Kind="Program" />

void Main()
{
	var paidAmmount = 300;
	var price = 125;
	var change = paidAmmount - price;
	
	CalculateChange(change).Dump();
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
<Query Kind="Program" />

void Main()
{
	var paidAmmount = 300;
	var price = 125;
	var change = paidAmmount - price;
	
	var result = new Stack<int>();

	var faceValues = new int[] { 100, 50, 25, 10, 5 };

	foreach (var value in faceValues)
	{
		CalculateChange(ref change, result, value);
	}
	
	result.Dump();
}

void CalculateChange(ref int change, Stack<int> coins, int faceValue)
{
	while (change >= faceValue)
	{
		change -= faceValue;
		coins.Push(faceValue);
	}
}
<Query Kind="Program" />

void Main()
{
	var paidAmmount = 300;
	var price = 125;
	var change = paidAmmount - price;
	
	var result = new Stack<int>();
	
	CalculateChange(ref change, result, 100);
	CalculateChange(ref change, result, 50);
	CalculateChange(ref change, result, 25);
	CalculateChange(ref change, result, 10);
	CalculateChange(ref change, result, 5);
	
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
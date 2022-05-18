<Query Kind="Program" />

void Main()
{
	var paidAmmount = 200;
	var price = 125;
	var change = paidAmmount - price;
	
	while (change > 0)
	{
		CalculateChange(ref change, 100);
		CalculateChange(ref change, 50);
		CalculateChange(ref change, 25);
		CalculateChange(ref change, 10);
		CalculateChange(ref change, 5);
	}
}

void CalculateChange(ref int change, int faceValue)
{
	if (change % faceValue != change)
	{
		change -= faceValue;
		Console.WriteLine($"{((decimal)faceValue / 100):0.00} USD");
	}
}
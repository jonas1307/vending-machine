<Query Kind="Program" />

void Main()
{
	var paidAmmount = 200;
	var price = 125;
	var change = paidAmmount - price;
	
	while (change > 0)
	{
		if (change % 100 != change)
		{
			change -= 100;
			Console.WriteLine("1.00 USD");
		}
		
		if (change % 50 != change)
		{
			change -= 50;
			Console.WriteLine("0.50 USD");
		}
		
		if (change % 25 != change)
		{
			change -= 25;
			Console.WriteLine("0.25 USD");
		}
		
		if (change % 10 != change)
		{
			change -= 10;
			Console.WriteLine("0.10 USD");
		}
		
		if (change % 5 != change)
		{
			change -= 5;
			Console.WriteLine("0.05 USD");
		}
	}
}
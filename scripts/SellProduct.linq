<Query Kind="Program" />

void Main()
{
	
}

public class Product
{
	public int Id { get; }
	
	public string Name { get; }
	
	public int Value { get; }
	
	public int Quantity { get; private set; }
	
	public Product(int id, string name, int value, int quantity)
	{
		Id = id;
		Name = name;
		Value = value;
		Quantity = quantity;
	}
	
	public void Sell()
	{
		if (Quantity <= 0) throw new ProductNotAvailableException("Product not available for selling");
		
		Quantity--;
	}
}

public class ProductGrid
{
	public IList<Product> Products { get; private set; } = new List<Product>();
	
	public Product AddProduct(int id, string name, int value, int quantity)
	{
		if (Products.Any(x => x.Id == id)) throw new ArgumentException($"Id {id} is already assigned to another product");
		
		var product = new Product(id, name, value, quantity);
		Products.Add(product);
		
		return product;
	}
	
	public Product GetProduct(int id)
	{
		var product = Products.SingleOrDefault(x => x.Id == id);
		
		if (product == default) throw new ArgumentException($"No product with id {id} was found");
		
		return product;
	}
	
	public IEnumerable<Product> GetAllProducts => Products;
}

public class Sale
{
	public Product Product { get; set; }
	public int[] Change { get;set; }
}

public class MachineCoinStack : Stack<int>
{
	private Dictionary<int, int> Coins { get; } = new Dictionary<int, int>();
	
	public MachineCoinStack()
	{
		Coins.Add(5, 0);
		Coins.Add(10, 0);
		Coins.Add(25, 0);
		Coins.Add(50, 0);
		Coins.Add(100, 0);
	}
	
	public void AddCoin(int faceValue) => Coins[faceValue] += 1;
	
	public void RemoveCoin(int faceValue)
	{
		if (Coins[faceValue] <= 0) throw new NotEnoughChangeException($"{faceValue} coins are not available");
		
		Coins[faceValue] -= 1;
	}
	
	public bool HasEnoughCoins(int faceValue, int amount) => Coins[faceValue] >= amount;
}

public class ProductNotAvailableException : Exception
{
	public ProductNotAvailableException(string message) : base(message)
	{
	
	}
}

public class NotEnoughChangeException : Exception
{
	public NotEnoughChangeException(string message) : base(message)
	{
	
	}
}
public class Settings
{
	public static int[] CoinValues = { 5, 10, 25, 50, 100 };
}
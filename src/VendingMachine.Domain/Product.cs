using VendingMachine.Domain.Exceptions;

namespace VendingMachine.Domain
{
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

            Quantity -= 1;
        }
    }
}

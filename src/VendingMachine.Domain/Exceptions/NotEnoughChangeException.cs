namespace VendingMachine.Domain.Exceptions
{
    public class NotEnoughChangeException : Exception
    {
        public NotEnoughChangeException(string message) : base(message)
        {

        }
    }
}

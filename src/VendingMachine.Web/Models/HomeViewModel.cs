using VendingMachine.Domain;

namespace VendingMachine.Web.Models
{
    public class HomeViewModel
    {
        public string AvailableCurrency { get; }

        public IList<Product> Products { get; }

        public HomeViewModel(string availableCurrency, IList<Product> products)
        {
            AvailableCurrency = availableCurrency;
            Products = products;
        }
    }
}

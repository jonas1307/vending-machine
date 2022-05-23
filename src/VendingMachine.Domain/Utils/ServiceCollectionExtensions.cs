using Microsoft.Extensions.DependencyInjection;
using VendingMachine.Domain.Contracts;

namespace VendingMachine.Domain.Utils
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterDomainServices(this IServiceCollection services)
        {
            services.AddSingleton<ICustomerCoinStack, CustomerCoinStack>();
            services.AddSingleton<IMachineCoinStack, MachineCoinStack>();
            services.AddSingleton<IProductGrid, ProductGrid>();
        }
    }
}

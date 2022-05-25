using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using VendingMachine.Domain.Contracts;

namespace VendingMachine.Domain.Utils
{
    [ExcludeFromCodeCoverage]
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

using Microsoft.Extensions.DependencyInjection;
using VendingMachine.Application.Contracts;

namespace VendingMachine.Application.Utils
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<IChangeService, ChangeService>();
        }
    }
}

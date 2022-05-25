using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using VendingMachine.Application.Contracts;

namespace VendingMachine.Application.Utils
{
    [ExcludeFromCodeCoverage]
    public static class ServiceCollectionExtensions
    {
        public static void RegisterApplicationServices(this IServiceCollection services)
        {
            services.AddSingleton<MachineInitialization>();
            services.AddTransient<IChangeService, ChangeService>();
            services.AddTransient<IMachineService, MachineService>();
        }
    }
}

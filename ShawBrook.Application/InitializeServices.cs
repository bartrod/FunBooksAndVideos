using Microsoft.Extensions.DependencyInjection;
using ShawBrook.Application.Services;
using ShawBrook.Application.Services.Interfaces;
using System.Reflection;

namespace ShawBrook.Application
{
    public static class ServicesInitializer
    {
        public static IServiceCollection InitializeServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddScoped<IProductProcessor, MembershipProductProcessor>();
            services.AddScoped<IProductProcessor, PhysicalProductProcessor>();
            services.AddScoped<IPurchaseOrderService, PurchaseOrderService>();
            services.AddScoped<IPurchaseOrderProcessor, PurchaseOrderProcessor>();

            return services;
        }
    }
}

using Application.Features.StoreProcedureModule.Handlers;
using Application.Features.StoreProcedureModule.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class InvertionOfControl
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<IStoreProcedureHandlers, StoreProcedureHandlers>();
            return services;
        }
    }
}

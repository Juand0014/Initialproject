using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class InvertionOfControl
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            return services;
        }
    }
}

using AuthGuardPro_Application;
using AuthGuardPro_Core;

namespace AuthGuardPro
{
    public static class DependencyIn
    {
        public static IServiceCollection AllDI(this IServiceCollection services)
        {

            services.CoreDI();
            services.ApplicationDI();
            services.AddHttpContextAccessor();
            return services;
        }
    }
}

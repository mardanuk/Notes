using Notes.Domain.Options;

namespace Presentation.Configurations
{
    public static class OptionsConfiguration
    {
        public static IServiceCollection LoadConfigurations(this IServiceCollection services)
        {
            services.AddOptions<PageConfiguration>("PageProperties");

            return services;
        }
    }
}

using GymJournal.Infrastructure;

namespace GymJournal.Startup
{
    public static class ModuleConfiguration
    {
        public static IServiceCollection RegisterModules(this IServiceCollection services)
        {
            services.ConfigureGymJournalModule();
            return services;
        }
    }
}

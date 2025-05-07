using GymJournal.Infrastructure.Authentication;
using GymJournal.Infrastructure.Database;
using GymJournal.Mappers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using GymJournal.Model;
using GymJournal.Repositories;
using GymJournal.RepositoryInterfaces;
using Microsoft.AspNetCore.Authentication;
using System.Runtime.CompilerServices;

namespace GymJournal.Infrastructure
{
    public static class GymJournalStartup
    {
        public static IServiceCollection ConfigureGymJournalModule(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(GymJournalMapper).Assembly);
            SetupModel(services);
            SetupInfrastructure(services);
            return services;
        }

        private static void SetupModel(IServiceCollection services)
        {
            services.AddScoped<IPersonRepository, PersonRepository>();
        }

        private static void SetupInfrastructure(IServiceCollection services)
        {
            services.AddScoped(typeof(ICrudRepository<Person>), typeof(CrudDatabaseRepository<Person, GymJournalContext>));
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddDbContext<GymJournalContext>(opt =>
            opt.UseNpgsql(DbConnectionStringBuilder.Build("gymjournal"),
               x => x.MigrationsHistoryTable("__EFMigrationsHistory", "gymjournal")));
        }
    }
}

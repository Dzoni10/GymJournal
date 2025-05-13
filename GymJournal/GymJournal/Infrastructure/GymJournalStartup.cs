using GymJournal.Infrastructure.Authentication;
using GymJournal.Infrastructure.Database;
using GymJournal.Mappers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using GymJournal.Model;
using GymJournal.Repositories;
using GymJournal.RepositoryInterfaces;
using System.Runtime.CompilerServices;
using GymJournal.ServiceInterfaces;
using Microsoft.AspNetCore.WebSockets;
using GymJournal.Services;

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
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<ITokenGenerator,JWTGenerator>();
            services.AddScoped<ITrainingService,TrainingService>();
        }

        private static void SetupInfrastructure(IServiceCollection services)
        {
            services.AddScoped(typeof(ICrudRepository<Person>), typeof(CrudDatabaseRepository<Person, GymJournalContext>)); // genericki za klasicne metode
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped(typeof(ICrudRepository<Training>),typeof(CrudDatabaseRepository<Training, GymJournalContext>)); // negenericki jer ima posebne metode
            services.AddScoped<ITrainingRepository, TrainingRepository>();

            services.AddDbContext<GymJournalContext>(opt =>
            opt.UseNpgsql(DbConnectionStringBuilder.Build("gymjournal"),
               x => x.MigrationsHistoryTable("__EFMigrationsHistory", "gymjournal")));
        }
    }
}

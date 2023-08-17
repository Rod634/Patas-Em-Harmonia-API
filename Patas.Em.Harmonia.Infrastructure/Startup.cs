using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Patas.Em.Harmonia.Domain.UI;
using Patas.Em.Harmonia.Infrastructure.Data;
using Patas.Em.Harmonia.Infrastructure.Data.Context;
using Patas.Em.Harmonia.Infrastructure.Data.Interfaces;

namespace Patas.Em.Harmonia.Infrastructure.Setup
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IServiceCollection Services { get; }

        private const string SETTINGS_SECTION = "Settings";

        public Startup(IConfiguration configuration, IServiceCollection services)
        {
            Configuration = configuration;
            Services = services;
        }

        /// <summary>
        /// Registers project's specific services
        /// </summary>
        public void AddDependencies()
        {
            var settings = GetSettings();

            // Dependency injection
            Services.AddSingleton(settings)
                    .AddScoped<PatasDBContext>()
                    .AddScoped<IRepositoryBase, RepositoryBase>();
        }

        public void AddDbContext()
        {
            var settings = GetSettings();

            // Db context
            Services.AddDbContext<PatasDBContext>(options =>
            {
                options
                    .UseSqlServer(settings.DatabaseConnectionString)
                    .UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll);
            }, ServiceLifetime.Scoped);
        }

        private ApiSettings GetSettings()
        {
            return Configuration.GetSection(SETTINGS_SECTION).Get<ApiSettings>();
        }
    }
}

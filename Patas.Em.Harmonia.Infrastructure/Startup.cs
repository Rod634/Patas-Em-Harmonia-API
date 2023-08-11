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

        private const string SETTINGS_SECTION = "Settings";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Registers project's specific services
        /// </summary>
        public void ConfigApp(IServiceCollection services)
        {
            var settings = Configuration.GetSection(SETTINGS_SECTION).Get<ApiSettings>();
            //var envelopeSerializer = EnvelopeSerializerFactory.Create

            // Dependency injection
            services.AddSingleton(settings)
                    .AddScoped<PatasDBContext>()
                    .AddScoped<IRepositoryBase, RepositoryBase>();


            // Db context
            services.AddDbContext<PatasDBContext>(options =>
            {
                options
                    .UseSqlServer(settings.DatabaseConnectionString)
                    .UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll);
            }, ServiceLifetime.Scoped);



        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DL.NetCore.EmptySolution.Data.EFCore.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            string dbConnectionString = configuration.GetConnectionString("appDbContext");
            string assemblyName = typeof(AppDbContext).Namespace;

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(dbConnectionString, optionsBuilder =>
                    optionsBuilder.MigrationsAssembly(assemblyName)
                )
            );
        }
    }
}

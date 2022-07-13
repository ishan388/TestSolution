using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NC_DLRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NC_BLRepositories
{
    public class DependencySetupFixture
    {
        public static ServiceProvider ConfigureDependencies()
        {
            ServiceCollection? services = new ServiceCollection();
            //services.AddDbContext<MyShopContext>(options => options.UseInMemoryDatabase(databaseName: "TestDatabase"));
            services.AddDbContext<MyShopContext>(options => options.UseSqlServer(Properties.Resources.ConnectionString.ToString()));

            services.AddScoped<IDLProductsRepo, DLProductsRepo>();
            services.AddScoped<IBLProductsRepo, BLProductsRepo>();
            return services.BuildServiceProvider();
        }
    }
}

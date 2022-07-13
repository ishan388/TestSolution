using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NC_Models;

namespace NC_DLRepositories
{
    public partial class MyShopContext : DbContext
    {
        public MyShopContext()
        {
        }

        public MyShopContext(DbContextOptions<MyShopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Product> Products { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer(Properties.Resources.ConnectionString.ToString());

                IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true)
                .Build();
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            }
        }
    }
}

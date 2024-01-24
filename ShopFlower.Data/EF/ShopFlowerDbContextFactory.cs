using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace ShopFlower.Data.EF
{
    public class ShopFlowerDbContextFactory : IDesignTimeDbContextFactory<ShopFlowerDbContext>
    {
        public ShopFlowerDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            var connectionString = configuration.GetConnectionString("ShopFlowerDB");

            var optionBuilder = new DbContextOptionsBuilder<ShopFlowerDbContext>();
            optionBuilder.UseSqlServer(connectionString);

            return new ShopFlowerDbContext(optionBuilder.Options);
        }
    }
}

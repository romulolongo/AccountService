using AccountServices.Infra.Data.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AccountServices.Infra.Data.Context
{
    public class AccountContext : DbContext
    {
        readonly IConfiguration _configuration;

        public AccountContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = _configuration.GetConnectionString("AccountServiceConnectionString");

            optionsBuilder.UseSqlServer(connectionString, b => b.MigrationsAssembly("AccountService.Infra.Data"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AccountMapping());
        }
    }
}

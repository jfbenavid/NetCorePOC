namespace TestApiRest.Repository
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;

    public class DBContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public DBContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql(_configuration.GetConnectionString("TestDB"));
        }

        public DbSet<User> Users { get; set; }
    }
}
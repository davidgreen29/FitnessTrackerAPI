using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using trackerApi.Data.Configurations;
namespace trackerApi.Data
{
    public class UserDataDbContext:IdentityDbContext<User>
    {
        public UserDataDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Weight> Weights { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            
        }
    }
}

using Microsoft.EntityFrameworkCore;
using NewApp.ViewModels;

namespace NewApp.Dao
{
    public class MyDbContext : DbContext
    {
        public DbSet<User> User { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }
    }
}
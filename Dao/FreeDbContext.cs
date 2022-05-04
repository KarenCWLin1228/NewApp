using Microsoft.EntityFrameworkCore;

namespace NewApp.Dao
{
    public class FreeDbContext : DbContext
    {
        public FreeDbContext(
            DbContextOptions<FreeDbContext> options)
            : base(options)
        {
        }

        public DbSet<NewApp.Models.Article> Article { get; set; }
    }
}

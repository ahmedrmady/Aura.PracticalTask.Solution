using Aura.PracticalTask.Data.Entites;
using Microsoft.EntityFrameworkCore;

namespace Aura.PracticalTask.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }
        public AppDbContext()
        {
            
        }


        public DbSet<Record> Records { get; set; }

    }
}

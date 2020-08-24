using GameOfDrones.Entities;
using Microsoft.EntityFrameworkCore;


namespace GameOfDrones.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            :base(options)
        {

        }

        public DbSet <Games> Game { get; set; }
        public DbSet<Options> Option { get; set; }
        public DbSet<Players> Player { get; set; }
        public DbSet<Rounds> Round { get; set; }
    }
}

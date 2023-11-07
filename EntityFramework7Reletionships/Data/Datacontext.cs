using EntityFramework7Reletionships.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework7Reletionships.Data
{
    public class Datacontext : DbContext
    {
        public Datacontext(DbContextOptions<Datacontext> options) : base(options)
        {
            
        }
        public DbSet<Character> Characters { get; set; }
        public DbSet<BackPack> BackPacks { get; set; }
        public DbSet<Wepon> Wepons { get; set; }
        public DbSet<Faction> Factions { get; set; }
    }
}

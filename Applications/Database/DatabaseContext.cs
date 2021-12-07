using ChessApp.Applications.Models;
using Microsoft.EntityFrameworkCore;

namespace ChessApp.Applications.Database
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options)
        {
            
        }
        public DbSet<Player> Player{get;set;}
        public DbSet<MatchHistory> MatchHistory{get;set;}
        protected override void OnModelCreating (ModelBuilder builder){
            base.OnModelCreating(builder);
            builder.Entity<Player>(player=> {
                player.HasMany(m => m.HostMatches).WithOne(o => o.Host).OnDelete(DeleteBehavior.Cascade);
                player.HasMany(m => m.JoinMatches).WithOne(o => o.Opponent).OnDelete(DeleteBehavior.NoAction);
            });
            builder.Entity<MatchHistory>(mh => {
                mh.Property(p => p.MatchResult).HasConversion<string>();
            });
        }
    }
}
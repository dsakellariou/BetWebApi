using BetWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BetWebApi
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options):base(options)
        {
            //Check the DB connection
            Database.EnsureCreated();
        }
        
        public DbSet<Match> Matches { get; set; }
        public DbSet<MatchOdds> MatchOdds { get; set; }
    }
}

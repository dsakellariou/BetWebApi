using Microsoft.EntityFrameworkCore;

namespace BetWebApi.Models
{
    public class MatchOddContext : DbContext
    {
        public MatchOddContext(DbContextOptions<MatchOddContext> options):base(options)
        {

        }

        public DbSet<MatchOdd> MatchOdds { get; set; }
    }
}

using BetWebApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BetWebApi.Repositories
{
    public class MatchRepository : IMatchRepository
    {
        private ApplicationDBContext _matchContext;
        public MatchRepository(ApplicationDBContext matchContext)
        {
            _matchContext = matchContext;
        }

        /// <summary>
        /// Get Match with odds
        /// </summary>
        /// <param name="Matchid"></param>
        /// <returns></returns>
        public async Task<Match> GetMatch(int Matchid)
        {
            var match = _matchContext.Matches
           .Include(c => c.MatchOdds)
           .AsNoTracking()
           .FirstOrDefaultAsync(x => x.ID == Matchid);
            return await match;

        }

        /// <summary>
        /// Get all matches to List
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Match>> GetMatches()
        {
            var matches = _matchContext.Matches
          .Include(c => c.MatchOdds)
          .AsNoTracking();
            return await matches.ToListAsync();
        }

        /// <summary>
        /// Create new match with odds
        /// </summary>
        /// <param name="match"></param>
        /// <returns></returns>
        public async Task<Match> CreateMatch(Match match)
        {
            _matchContext.Matches.Add(match);
            await _matchContext.SaveChangesAsync();
            return match;
        }

        /// <summary>
        /// Update match
        /// </summary>
        /// <param name="match"></param>
        /// <returns></returns>
        public async Task UpdateMatch(Match match)
        {
            _matchContext.Entry(match).State = EntityState.Modified;
            await _matchContext.SaveChangesAsync();
        }

        /// <summary>
        /// Delete Match
        /// </summary>
        /// <param name="Matchid"></param>
        /// <returns></returns>
        public async Task DeleteMatch(int Matchid)
        {
            var matchToDelete = await _matchContext.Matches.FindAsync(Matchid);
            _matchContext.Matches.Remove(matchToDelete);
            await _matchContext.SaveChangesAsync();
        }


    }
}

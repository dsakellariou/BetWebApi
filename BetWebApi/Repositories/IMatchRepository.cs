using BetWebApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BetWebApi.Repositories
{
    public interface IMatchRepository
    {
        Task<IEnumerable<Match>> GetMatches();

        Task<Match> GetMatch(int Matchid);

        Task<Match> CreateMatch(Match match);

        Task UpdateMatch(Match match);

        Task DeleteMatch(int Matchid);
    }
}

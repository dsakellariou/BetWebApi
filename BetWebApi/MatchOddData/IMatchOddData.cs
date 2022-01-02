using BetWebApi.Models;
using System.Collections.Generic;

namespace BetWebApi.MatchOddData
{
    public interface IMatchOddData
    {
        List<MatchOdd> GetMatchOdds();

        MatchOdd GetMatchOdd(int Matchid);

        MatchOdd AddMatchOdd(MatchOdd matchodd);

        MatchOdd EditMatchOdd(MatchOdd matchodd);

        void DeleteMatchOdd(MatchOdd matchodd);
    }
}

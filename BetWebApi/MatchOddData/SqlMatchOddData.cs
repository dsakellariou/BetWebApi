using BetWebApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace BetWebApi.MatchOddData
{
    public class SqlMatchOddData : IMatchOddData
    {
        private MatchOddContext _matchOddContext;
        public SqlMatchOddData(MatchOddContext matchOddContext)
        {
            _matchOddContext = matchOddContext;
        }


        public MatchOdd AddMatchOdd(MatchOdd matchodd)
        {
            _matchOddContext.MatchOdds.Add(matchodd);
            _matchOddContext.SaveChanges();

            return matchodd;
        }

        public void DeleteMatchOdd(MatchOdd matchodd)
        {
            _matchOddContext.MatchOdds.Remove(matchodd);
            _matchOddContext.SaveChanges();
        }

        public MatchOdd EditMatchOdd(MatchOdd matchodd)
        {
            var existingmatchodd = _matchOddContext.MatchOdds.Find(matchodd.ID);
            if(existingmatchodd != null)
            {
                _matchOddContext.MatchOdds.Update(matchodd);
                _matchOddContext.SaveChanges();
            }

            return matchodd;
        }

        public MatchOdd GetMatchOdd(int Matchid)
        {
            var matchodd = _matchOddContext.MatchOdds.Find(Matchid);
            return matchodd;
        }

        public List<MatchOdd> GetMatchOdds()
        {
            return _matchOddContext.MatchOdds.ToList();
        }
    }
}

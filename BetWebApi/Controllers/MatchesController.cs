using BetWebApi.Repositories;
using BetWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BetWebApi.Controllers
{
    [ApiController]
    [Route("api/matches")]
    public class MatchesController : ControllerBase
    {
        private IMatchRepository _matchRepository;
        public MatchesController(IMatchRepository matchRepository)
        {
            _matchRepository = matchRepository;
        }

        /// <summary>
        /// Get a list of matches including odds
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<Match>> GetMatches()
        {
            return await _matchRepository.GetMatches();
        }


        /// <summary>
        /// Get Match with odds
        /// </summary>
        /// <param name="id"></param>
        /// <returns>match</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Match>> GetMatch(int id)
        {
            var match = await _matchRepository.GetMatch(id);
            if (match == null)
            {
                return NotFound();
            }
            return match;
        }

        /// <summary>
        /// Create a Match, with Odds
        /// </summary>
        /// <param name="match"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Match>> CreateMatch([FromBody] Match match)
        {
            var newMatch = await _matchRepository.CreateMatch(match);
            return CreatedAtAction(nameof(GetMatches), new { id = newMatch.ID }, newMatch);
        }

        /// <summary>
        /// Update match by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="match"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateMatch(int id, [FromBody] Match match)
        {
            var existingmatch = await _matchRepository.GetMatch(id);
            if (existingmatch != null)
            {
                match.ID = existingmatch.ID;
                await _matchRepository.UpdateMatch(match);
                return CreatedAtAction(nameof(GetMatches), new { id = match.ID }, match); ;
            }

            return BadRequest();
        }

        /// <summary>
        /// Delete match by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMatch(int id)
        {
            var existingmatch = await _matchRepository.GetMatch(id);
            if (existingmatch == null)
                return NotFound();

            await _matchRepository.DeleteMatch(existingmatch.ID);
            return NoContent();
        }
    }
}

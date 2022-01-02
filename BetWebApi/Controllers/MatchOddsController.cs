using BetWebApi.MatchOddData;
using BetWebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BetWebApi.Controllers
{
    [ApiController]
    public class MatchOddsController : ControllerBase
    {
        private IMatchOddData _matchOddData;
        public MatchOddsController(IMatchOddData matchOddData)
        {
            _matchOddData = matchOddData;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetMatchOdds()
        {
            return Ok(_matchOddData.GetMatchOdds());
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetMatchOdd(int id)
        {
            return Ok(_matchOddData.GetMatchOdd(id));
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult AddMatchOdd(MatchOdd matchOdd)
        {
           var newmatchodd = _matchOddData.AddMatchOdd(matchOdd);
           if (newmatchodd == null)
            { return NotFound("Error on creating matchodd!"); }

            return Created(HttpContext.Request.Scheme + "://"+HttpContext.Request.Host+ HttpContext.Request.Path + "/" + matchOdd.ID,matchOdd);
        }

        [HttpPut]
        [Route("api/[controller]/{id}")]
        public IActionResult EditMatchOdd(int id, MatchOdd matchOdd)
        {
            var existingmatchodd = _matchOddData.GetMatchOdd(id);
            if (existingmatchodd != null)
            {
                matchOdd.ID = existingmatchodd.ID; 
                _matchOddData.EditMatchOdd(matchOdd);
                return Ok();
            }

            return NotFound(@$"MatchOdd with Id: {id} not found");
        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult DeleteMatchOdd(int id)
        {
            var existingmatchodd = _matchOddData.GetMatchOdd(id);
            if (existingmatchodd != null)
            {
                _matchOddData.DeleteMatchOdd(existingmatchodd);
                return Ok();
            }

            return NotFound(@$"MatchOdd with Id: {id} not found");
        }
    }
}

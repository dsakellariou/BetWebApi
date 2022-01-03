using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using BetWebApi.Models;
using MatchesApi.Enums;

namespace BetWebApi.Models
{
    public class Match
    {        
        public Match()
        {
            MatchOdds = new List<MatchOdds>();
        }

        [Key]
        public int ID { get; set; }
        
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime MatchDate { get; set; }
        [Required]
        public DateTime MatchTime { get; set; }
        [Required]
        public string TeamA { get; set; }
        [Required]
        public string TeamB { get; set; }
        [Required]
        public Sport sport{ get; set; }

        public IList<MatchOdds> MatchOdds { get; set; }
    }
}

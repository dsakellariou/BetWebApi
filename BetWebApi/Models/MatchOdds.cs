using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BetWebApi.Models
{
    public class MatchOdds
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [ForeignKey("Matches")]
        public int MatchID { get; set; }

        [Required]
        [MaxLength(1)]
        public string Specifier{get;set;}

        [Required]
        public double Odd { get; set; }
    }

}

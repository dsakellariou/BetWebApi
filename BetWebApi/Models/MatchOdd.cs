using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BetWebApi.Models
{
    public class MatchOdd
    {


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Required]
        public int MatchID { get; set; }


        private string _specifier;


        [Required]
        [MaxLength(1, ErrorMessage = "The Specifier must be (1 or X or 2")]
        public string Specifier
        {
            get { return _specifier; }
            set
            {
                _specifier = _specifier != "1" || _specifier != "2" || _specifier != "X" ? value : "-";
            }
        }



        [Required]
        public double Odd { get; set; }
    }

}

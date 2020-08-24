using GameOfDrones.Entities;
using System.ComponentModel.DataAnnotations;


namespace GameOfDrones.Models
{
    public class RoundsDTO
    {
        public int Id { get; set; }
        [Required]
        public int gameID { get; set; }
        [Required]
        public int playerOneChoice { get; set; }
        [Required]
        public int playerTwoChoice { get; set; }
        [Required]
        public int roundWinner { get; set; }
        public Games game { get; set; }
    }
}

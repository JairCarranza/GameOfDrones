using System.ComponentModel.DataAnnotations;


namespace GameOfDrones.Models
{
    public class GameCreationDTO
    {

        [Required]
        public int IdPlayer1 { get; set; }
        [Required]
        public int IdPlayer2 { get; set; }
        [Required]
        public int IdWinner { get; set; }

    }
}

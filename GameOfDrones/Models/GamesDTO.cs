using GameOfDrones.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace GameOfDrones.Models
{
    public class GamesDTO
    {
        public int Id { get; set; }
        [Required]
        public int IdPlayer1 { get; set; }
        [Required]
        public int IdPlayer2 { get; set; }
        [Required]
        public int IdWinner { get; set; }
        public List<Rounds> Rounds { get; set; }
    }
}

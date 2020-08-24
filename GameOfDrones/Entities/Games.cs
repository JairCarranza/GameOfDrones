using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GameOfDrones.Entities
{
    public class Games
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

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GameOfDrones.Entities
{
    public class Rounds
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

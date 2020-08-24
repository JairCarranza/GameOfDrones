using GameOfDrones.Context;
using GameOfDrones.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameOfDrones.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class RoundsController : ControllerBase
    {

        // <summary>
        //Inyeccion instancia dbcontext
        // </summary>
        private readonly ApplicationDbContext context;
        public RoundsController(ApplicationDbContext context)
        {
            this.context = context;
        }


        // <summary>
        //Método que consulta el listado total de rounds
        // </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rounds>>> Get()
        {
            return await context.Round.ToListAsync();
        }


        // <summary>
        //Método que consulta un round particular por id
        // </summary>
        [HttpGet("{id}", Name = "GetRound")]
        public async Task<ActionResult<Rounds>> Get(int id)
        {
            var round = context.Round.FirstOrDefaultAsync(x => x.Id == id);

            if (round == null)
            {
                return NotFound();
            }

            return await round;
        }


        // <summary>
        //Método que agrega registro de un juego
        // </summary>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Rounds round)
        {
            context.Round.Add(round);
            await context.SaveChangesAsync();
            return new CreatedAtRouteResult("GetRound", new { id = round.Id }, round);
        }


        // <summary>
        //Método que actualiza un registro identificado por su id
        // </summary>
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Rounds Round)
        {
            if (id != Round.Id)
            {
                return BadRequest();
            }

            context.Entry(Round).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok();
        }


        // <summary>
        //Método que borra un registro identificado por su id
        // </summary>
        [HttpDelete("{id}")]
        public async Task<ActionResult<Rounds>> Delete(int id)
        {
            var round = context.Round.FirstOrDefault(x => x.Id == id);

            if (round == null)
            {
                return NotFound();
            }

            context.Round.Remove(round);
            await context.SaveChangesAsync();
            return round;
        }

    }

}

using GameOfDrones.Context;
using GameOfDrones.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameOfDrones.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {

        // <summary>
        //Inyeccion instancia dbcontext
        // </summary>
        private readonly ApplicationDbContext context;
        public PlayersController(ApplicationDbContext context)
        {
            this.context = context;
        }


        // <summary>
        //Método que consulta el listado total de opciones
        // </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Players>>> Get()
        {
            return await context.Player.ToListAsync();
        }


        // <summary>
        //Método que consulta una opción particular por id
        // </summary>
        [HttpGet("{id}", Name = "GetPlayer")]
        public async Task<ActionResult<Players>> Get(int id)
        {
            var player = context.Player.FirstOrDefaultAsync(x => x.Id == id);

            if (player == null)
            {
                return NotFound();
            }

            return await player;
        }


        // <summary>
        //Método que agrega registro de un jugador
        // </summary>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Players player)
        {
            context.Player.Add(player);
            await context.SaveChangesAsync();
            return new CreatedAtRouteResult("GetPlayer", new { id = player.Id }, player);
        }


        // <summary>
        //Método que actualiza un registro identificado por su id
        // </summary>
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Players player)
        {
            if (id != player.Id)
            {
                return BadRequest();
            }

            context.Entry(player).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok();
        }


        // <summary>
        //Método que borra un registro identificado por su id
        // </summary>
        [HttpDelete("{id}")]
        public async Task<ActionResult<Players>> Delete(int id)
        {
            var player = context.Player.FirstOrDefault(x => x.Id == id);

            if (player == null)
            {
                return NotFound();
            }

            context.Player.Remove(player);
            await context.SaveChangesAsync();
            return player;
        }

    }
}

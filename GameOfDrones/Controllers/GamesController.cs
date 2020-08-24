
using AutoMapper;
using GameOfDrones.Context;
using GameOfDrones.Entities;
using GameOfDrones.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameOfDrones.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {

        // <summary>
        //Inyeccion instancia dbcontext
        // </summary>
        private readonly ApplicationDbContext context;
        private readonly ILogger<GamesController> logger;
        private readonly IMapper mapper;

        public GamesController(ApplicationDbContext context, ILogger<GamesController> logger, IMapper mapper)
        {
            this.context = context;
            this.logger = logger;
            this.mapper = mapper;
        }

        

        // <summary>
        //Método que consulta el listado total de juegos
        // </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Games>>> Get()
        {
            logger.LogInformation("Getting the games");
            return await context.Game.Include(x => x.Rounds).ToListAsync();
        }

        // <summary>
        //Método que consulta un juego particular por id
        // </summary>
        [HttpGet("{id}", Name = "GetGame")]
        public async Task<ActionResult<GamesDTO>> Get(int id)
        {
            var game = await context.Game.Include(x => x.Rounds).FirstOrDefaultAsync(x => x.Id == id);

            if (game == null)
            {
                logger.LogWarning($"The Game with ID {id} has not been found");
                return NotFound();
            }

            var gameDTO = mapper.Map<GamesDTO>(game);

            return gameDTO;
        }


        // <summary>
        //Método que agrega registro de un juego
        // </summary>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] GameCreationDTO gameCreation)
        {
            var game = mapper.Map<Games>(gameCreation);
            context.Game.Add(game);
            await context.SaveChangesAsync();
            var gameDTO = mapper.Map<GamesDTO>(game); ;//Retorna cabezera location donde esta la ubicación del recurso
            return new CreatedAtRouteResult("GetGame", new { id = game.Id }, gameDTO); 
        }


        // <summary>
        //Método que actualiza un registro identificado por su id
        // </summary>
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] GameCreationDTO gameUpdate)
        {
            var game = mapper.Map<Games>(gameUpdate);
            game.Id = id;
            context.Entry(game).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok();
        }


        // <summary>
        //Método que borra un registro identificado por su id
        // </summary>
        [HttpDelete("{id}")]
        public async Task<ActionResult<Games>> Delete(int id)
        {
            var gameid = await context.Game.Select(x => x.Id).FirstOrDefaultAsync(x => x == id);

            if (gameid == default(int))
            {
                return NotFound();
            }

            context.Game.Remove(new Games { Id = gameid });
            await context.SaveChangesAsync();
            return NoContent();
        }


    }
}

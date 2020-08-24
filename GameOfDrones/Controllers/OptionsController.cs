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
    public class OptionsController : ControllerBase
    {

        // <summary>
        //Inyeccion instancia dbcontext
        // </summary>
        private readonly ApplicationDbContext context;
        public OptionsController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Options>>> Get()
        {
            return await context.Option.ToListAsync();
        }


        // <summary>
        //Método que consulta una opción particular por id
        // </summary>
        [HttpGet("{id}", Name = "GetOption")]
        public async Task<ActionResult<Options>> Get(int id)
        {
            var option = context.Option.FirstOrDefaultAsync(x => x.Id == id);

            if (option == null)
            {
                return NotFound();
            }

            return await option;
        }


        // <summary>
        //Método que agrega registro de un jugador
        // </summary>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Options option)
        {
            context.Option.Add(option);
            await context.SaveChangesAsync();
            return new CreatedAtRouteResult("GetOption", new { id = option.Id }, option);
        }


        // <summary>
        //Método que actualiza un registro identificado por su id
        // </summary>
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Options option)
        {
            if (id != option.Id)
            {
                return BadRequest();
            }

            context.Entry(option).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok();
        }


        // <summary>
        //Método que borra un registro identificado por su id
        // </summary>
        [HttpDelete("{id}")]
        public async Task<ActionResult<Options>> Delete(int id)
        {
            var option = context.Option.FirstOrDefault(x => x.Id == id);

            if (option == null)
            {
                return NotFound();
            }

            context.Option.Remove(option);
            await context.SaveChangesAsync();
            return option;
        }

    }
}

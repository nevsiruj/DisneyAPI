using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DisneyAPI;
using DisneyAPI.Data;

namespace DisneyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonajesController : ControllerBase
    {
        private readonly DataContext _context;

        public PersonajesController(DataContext context)
        {
            _context = context;
        }



        // 3) Listado de Personajes **ONLY IMAGE & NAME**
        // GET: api/Personajes/ 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Personaje>>> GetPersonajes()
        {

             if (_context.Personajes == null)
            {
                return NotFound();
            }

            var result = from x in _context.Personajes
                         select new
                         {
                             Name = x.Name,
                             Imagen = x.Imagen,
                         };

            return Ok(result);  

        }


        // 5) Detalle de todos los personajes
        //   GET: api/Personajes
        [HttpGet("detalle")]

        public async Task<ActionResult<IEnumerable<Personaje>>> GetPersonajesDetails()
        {
            if (_context.Personajes == null)
            {
                return NotFound();
            }
            return await _context.Personajes.ToListAsync();
        }

        // 6.1) Busqueda de Personaje por Nombre 
        // GET: api/Personajes/ 
        [HttpGet("/characters/name/{name}")]
        public async Task<ActionResult<Personaje>> SearchPersonajes(string name)
        {

            if (_context.Personajes == null)
            {
                return NotFound();
            }

            //string LowerName = (name + "").ToLower();
            //var personajes = (from p in _context.Personajes
            //                  where (LowerName == "" || p.Name.ToLower().Contains(LowerName))
            //                  select p);
            var personajes =  await _context.Personajes.Where(s => EF.Functions.Like(s.Name, $"%{name}%")).ToListAsync();

            return Ok(personajes);
            
        }

        // 6.2) Busqueda de Personaje por Edad 
        // GET: api/Personajes/ 
        [HttpGet("/characters/edad/{edad}")]
        public async Task<ActionResult<Personaje>> SearchPersonajeById(int edad)
        {

            if (_context.Personajes == null)
            {
                return NotFound();
            }
            var personajes = await _context.Personajes.Where(s => s.Edad == edad).ToListAsync();

            return Ok(personajes);

        }

        // 6.3) Busqueda de Personaje por Pelicula 
        // GET: api/Personajes/ 
        [HttpGet("/characters/movies/{idMovie}")]
        public async Task<ActionResult<Personaje>> SearchPersonajeByMovieId(int idMovie)
        {

            if (_context.Personajes == null)
            {
                return NotFound();
            }
            var personajes = await _context.Personajes.Where(s => s.CurrentObraId == idMovie).ToListAsync();

            return Ok(personajes);

        }

        // GET: api/Personajes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Personaje>> GetPersonaje(int id)
        {
          if (_context.Personajes == null)
          {
              return NotFound();
          }
            var personaje = await _context.Personajes.FindAsync(id);

            if (personaje == null)
            {
                return NotFound();
            }

            return personaje;
        }


     

        // 4.1) Creacion de Personaje
        // POST: api/Personajes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Personaje>> PostPersonaje(Personaje personaje)
        {
          if (_context.Personajes == null)
          {
              return Problem("Entity set 'DataContext.Personajes'  is null.");
          }
            _context.Personajes.Add(personaje);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersonaje", new { id = personaje.Id }, personaje);
        }

        // 4.2) Edicion de Personaje
        // PUT: api/Personajes/5

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonaje(int id, Personaje personaje)
        {
            if (id != personaje.Id)
            {
                return BadRequest();
            }

            _context.Entry(personaje).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonajeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // 4.3) Eliminacion de Personaje
        // DELETE: api/Personajes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonaje(int id)
        {
            if (_context.Personajes == null)
            {
                return NotFound();
            }
            var personaje = await _context.Personajes.FindAsync(id);
            if (personaje == null)
            {
                return NotFound();
            }

            _context.Personajes.Remove(personaje);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PersonajeExists(int id)
        {
            return (_context.Personajes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

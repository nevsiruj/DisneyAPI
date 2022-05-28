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
    public class ObrasController : ControllerBase
    {
        private readonly DataContext _context;

        public ObrasController(DataContext context)
        {
            _context = context;
        }

        // 7) Listado de Peliculas
        // GET: api/Obras
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Obra>>> GetObras()
        {
          if (_context.Obras == null)
          {
              return NotFound();
          }
            var result = from x in _context.Obras
                         select new
                         {
                             Imagen = x.Imagen,
                             Titulo = x.Titulo,
                             FechaDeCreacion = x.FechaDeCreacion,
                         };

            return Ok(result);

        }

        // GET: api/Obras/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Obra>> GetObra(int id)
        {
          if (_context.Obras == null)
          {
              return NotFound();
          }
            var obra = await _context.Obras.FindAsync(id);

            if (obra == null)
            {
                return NotFound();
            }

            return obra;
        }

        // 8.1) Agregar Pelicula
        // POST: api/Obras
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Obra>> PostObra(Obra obra)
        {
            if (_context.Obras == null)
            {
                return Problem("Entity set 'DataContext.Obras'  is null.");
            }
            _context.Obras.Add(obra);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetObra", new { id = obra.ObraId }, obra);
        }

        // 8.2) Editar Pelicula 
        // PUT: api/Obras/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutObra(int id, Obra obra)
        {
            if (id != obra.ObraId)
            {
                return BadRequest();
            }

            _context.Entry(obra).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ObraExists(id))
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


        
        // 8.3) Eliminar Pelicula
        // DELETE: api/Obras/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteObra(int id)
        {
            if (_context.Obras == null)
            {
                return NotFound();
            }
            var obra = await _context.Obras.FindAsync(id);
            if (obra == null)
            {
                return NotFound();
            }

            _context.Obras.Remove(obra);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // 10.1) Busqueda de Obra por Nombre 
        [HttpGet("/Obras/titulo={titulo}")]
        public async Task<ActionResult<Obra>> SearchMovieByTitulo(string titulo)
        {

            if (_context.Obras == null)
            {
                return NotFound();
            }
            var obras = await _context.Obras.Where(s => EF.Functions.Like(s.Titulo, $"%{titulo}%")).ToListAsync();

            return Ok(obras);

        }

        // 10.2) Busqueda de Obra Por Genero
        [HttpGet("/Obras/genero={idGenero}")]
        public async Task<ActionResult<Obra>> SearchMovieByIdGenero(int idGenero)
        {

            if (_context.Obras == null)
            {
                return NotFound();
            }
            var obras = await _context.Obras.Where(s => s.currentGeneroId == idGenero).ToListAsync();

            return Ok(obras);

        }

        // 10.3.1) Order By ASC 
        [HttpGet("/Obras/OrderASC")]
        public async Task<ActionResult<Obra>> OrderMovieASC()
        {

            if (_context.Obras == null)
            {
                return NotFound();
            }
            var obras =  _context.Obras.OrderBy(x => x.Titulo);

            return Ok(obras);

        }

        // 10.3.2) Order By DESC
        [HttpGet("/Obras/OrderDESC")]
        public async Task<ActionResult<Obra>> OrderMovieDESC()
        {

            if (_context.Obras == null)
            {
                return NotFound();
            }
            var obras = _context.Obras.OrderByDescending(x => x.Titulo);

            return Ok(obras);

        }



        private bool ObraExists(int id)
        {
            return (_context.Obras?.Any(e => e.ObraId == id)).GetValueOrDefault();
        }
    }
}

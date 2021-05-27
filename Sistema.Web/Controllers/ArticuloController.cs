using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema.Datos;
using Sistema.Entidad.Almacen;

namespace Sistema.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticuloController : ControllerBase
    {
        private readonly DBContextSistema _context;

        public ArticuloController(DBContextSistema context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Articulo>>> GetArticulo()
        {
            return await _context.Articulos.ToListAsync();
        }

        [HttpGet("{Idarticulo}")]
        public async Task<ActionResult<Articulo>> GetArticulo(int id)
        {
            var Articulo = await _context.Articulos.FindAsync(id);
            if (Articulo == null)
            {
                return NotFound();
            }
            return Articulo;
        }

        [HttpGet("{Idarticulo}")]
        public async Task<ActionResult> PutArticulo(int id, Articulo articulo)
        {
            if (id != articulo.idarticulo)
            {
                return BadRequest();
            }
            _context.Entry(articulo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArticuloExists(id))
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
        [HttpPost]
        public async Task<ActionResult> Putarticulo(int id, Articulo articulo)
        {
            _context.Articulos.Add(articulo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArticulo", new { id = articulo.idarticulo }, articulo);
        }

        [HttpDelete("Idarticulo")]
        public async Task<ActionResult<Articulo>> Deletearticulo(int id)
        {
            var Articulo = await _context.Articulos.FindAsync(id);
            if (Articulo == null)
            {
                return NotFound();
            }
            _context.Articulos.Remove(Articulo);
            await _context.SaveChangesAsync();

            return Articulo;
        }

        private bool ArticuloExists(int id)
        {
            return _context.Articulos.Any(e => e.idarticulo == id);
        }

    }
}



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
    public class CategoriasController : ControllerBase
    {
        private readonly DBContextSistema _context;

        public CategoriasController(DBContextSistema context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categoria>>> GetCategorias()
        {
            return await _context.Categorias.ToListAsync();
        }

        [HttpGet("{IdCategoria}")]
        public async Task<ActionResult<Categoria>> GetCategorias(int id)
        {
            var Categoria = await _context.Categorias.FindAsync(id);
            if(Categoria == null)
            {
                return NotFound();
            }
            return Categoria;
        }

        [HttpGet("{IdCategoria}")]
        public async Task<ActionResult> PutCategoria (int id, Categoria categoria)
        {
            if (id != categoria.idcategoria)
            {
                return BadRequest();
            }
            _context.Entry(categoria).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoriaExists(id))
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
        public async Task<ActionResult> Putcategoria(int id, Categoria categoria)
        {
            _context.Categorias.Add(categoria);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategoria", new { id = categoria.idcategoria }, categoria);
        }
         
        [HttpDelete("idCategoria")]
        public async Task<ActionResult<Categoria>> Deletecategoria(int id)
        {
            var Categoria = await _context.Categorias.FindAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }
            _context.Categorias.Remove(Categoria);
            await _context.SaveChangesAsync();

            return Categoria;
        }

        private bool CategoriaExists(int id)
        {
            return _context.Categorias.Any(e => e.idcategoria == id);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema.Datos;
using Sistema.Entidad.Usuarios;

namespace Sistema.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private readonly DBContextSistema _context;

        public RolController(DBContextSistema context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rol>>> GetRol()
        {
            return await _context.Rols.ToListAsync();
        }

        [HttpGet("{IdRol}")]
        public async Task<ActionResult<Rol>> GetRol(int id)
        {
            var Rol = await _context.Rols.FindAsync(id);
            if (Rol == null)
            {
                return NotFound();
            }
            return Rol;
        }

        [HttpGet("{IdRol}")]
        public async Task<ActionResult> PutRol(int id, Rol rol)
        {
            if (id != rol.idrol)
            {
                return BadRequest();
            }
            _context.Entry(rol).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RolExists(id))
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
        public async Task<ActionResult> PutRols(int id, Rol rol)
        {
            _context.Rols.Add(rol);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRol", new { id = rol.idrol }, rol);
        }

        [HttpDelete("IdRol")]
        public async Task<ActionResult<Rol>> DeleteRol(int id)
        {
            var Rol = await _context.Rols.FindAsync(id);
            if (Rol == null)
            {
                return NotFound();
            }
            _context.Rols.Remove(Rol);
            await _context.SaveChangesAsync();

            return Rol;
        }

        private bool RolExists(int id)
        {
            return _context.Categorias.Any(e => e.idcategoria == id);
        }

    }
}

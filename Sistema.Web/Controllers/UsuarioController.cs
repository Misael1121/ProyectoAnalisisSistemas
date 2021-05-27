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
    public class UsuarioController : ControllerBase
    {
        private readonly DBContextSistema _context;

        public UsuarioController(DBContextSistema context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuarios>>> GetUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }

        [HttpGet("{IdUsuario}")]
        public async Task<ActionResult<Usuarios>> GetUsuarios(int id)
        {
            var Usuario = await _context.Usuarios.FindAsync(id);
            if (Usuario == null)
            {
                return NotFound();
            }
            return Usuario;
        }

        [HttpGet("{IdUsuario}")]
        public async Task<ActionResult> PutUsuario(int id, Usuarios usuario)
        {
            if (id != usuario.Idusuario)
            {
                return BadRequest();
            }
            _context.Entry(usuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuariosExists(id))
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
        public async Task<ActionResult> PutUsuarios(int id, Usuarios usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsuario", new { id = usuario.Idusuario }, usuario);
        }

        [HttpDelete("idUsuario")]
        public async Task<ActionResult<Usuarios>> DeleteUsuario(int id)
        {
            var Usuario = await _context.Usuarios.FindAsync(id);
            if (Usuario == null)
            {
                return NotFound();
            }
            _context.Usuarios.Remove(Usuario);
            await _context.SaveChangesAsync();

            return Usuario;
        }

        private bool UsuariosExists(int id)
        {
            return _context.Categorias.Any(e => e.idcategoria == id);
        }

    }
}

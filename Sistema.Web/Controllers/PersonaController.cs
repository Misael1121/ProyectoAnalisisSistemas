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
    public class PersonaController : ControllerBase
    {
        private readonly DBContextSistema _context;

        public PersonaController(DBContextSistema context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Persona>>> GetPersonas()
        {
            return await _context.Personas.ToListAsync();
        }

        [HttpGet("{IdPersona}")]
        public async Task<ActionResult<Persona>> GetPersonas(int id)
        {
            var Persona = await _context.Personas.FindAsync(id);
            if (Persona == null)
            {
                return NotFound();
            }
            return Persona;
        }

        [HttpGet("{IdPersona}")]
        public async Task<ActionResult> PutPersona(int id, Persona persona)
        {
            if (id != persona.idpersona)
            {
                return BadRequest();
            }
            _context.Entry(persona).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonaExists(id))
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
        public async Task<ActionResult> PutPersonas(int id, Persona persona)
        {
            _context.Personas.Add(persona);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersona", new { id = persona.idpersona }, persona);
        }

        [HttpDelete("IdPersona")]
        public async Task<ActionResult<Persona>> DeletePersona(int id)
        {
            var Persona = await _context.Personas.FindAsync(id);
            if (Persona == null)
            {
                return NotFound();
            }
            _context.Personas.Remove(Persona);
            await _context.SaveChangesAsync();

            return Persona;
        }

        private bool PersonaExists(int id)
        {
            return _context.Categorias.Any(e => e.idcategoria == id);
        }

    }
}


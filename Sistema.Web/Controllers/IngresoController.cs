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
    public class IngresoController : ControllerBase
    {
        private readonly DBContextSistema _context;

        public IngresoController(DBContextSistema context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ingreso>>> GetIngreso()
        {
            return await _context.Ingresos.ToListAsync();
        }

        [HttpGet("{Idingreso}")]
        public async Task<ActionResult<Ingreso>> GetIngreso(int id)
        {
            var Ingreso = await _context.Ingresos.FindAsync(id);
            if (Ingreso == null)
            {
                return NotFound();
            }
            return Ingreso;
        }

        [HttpGet("{Idingreso}")]
        public async Task<ActionResult> PutIngreso(int id, Ingreso ingreso)
        {
            if (id != ingreso.Idingreso)
            {
                return BadRequest();
            }
            _context.Entry(ingreso).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IngresoExists(id))
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
        public async Task<ActionResult> Putingreso(int id, Ingreso ingreso)
        {
            _context.Ingresos.Add(ingreso);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIngreso", new { id = ingreso.Idingreso }, ingreso);
        }

        [HttpDelete("Idingreso")]
        public async Task<ActionResult<Ingreso>> Deleteingreso(int id)
        {
            var Ingreso = await _context.Ingresos.FindAsync(id);
            if (Ingreso == null)
            {
                return NotFound();
            }
            _context.Ingresos.Remove(Ingreso);
            await _context.SaveChangesAsync();

            return Ingreso;
        }

        private bool IngresoExists(int id)
        {
            return _context.Ingresos.Any(e => e.Idingreso == id);
        }

    }
}


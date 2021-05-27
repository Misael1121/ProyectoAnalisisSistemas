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
    public class Detalle_FacturasController : ControllerBase
    {
        private readonly DBContextSistema _context;

        public Detalle_FacturasController(DBContextSistema context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Detalle_Facturas>>> GetDetalle_Facturas()
        {
            return await _context.Detalle_Facturas.ToListAsync();
        }

        [HttpGet("{Iddetalle_Facturas}")]
        public async Task<ActionResult<Detalle_Facturas>> GetDetalle_Facturas(int id)
        {
            var Detalle_Factura = await _context.Detalle_Facturas.FindAsync(id);
            if (Detalle_Factura == null)
            {
                return NotFound();
            }
            return Detalle_Factura;
        }

        [HttpGet("{Iddetalle_Facturas}")]
        public async Task<ActionResult> PutDetalle_Factura(int id, Detalle_Facturas detalle_Facturas)
        {
            if (id != detalle_Facturas.Iddetalle)
            {
                return BadRequest();
            }
            _context.Entry(detalle_Facturas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Detalle_FacturasExists(id))
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
        public async Task<ActionResult> PutDetalle_Facturas(int id, Detalle_Facturas detalle_Facturas)
        {
            _context.Detalle_Facturas.Add(detalle_Facturas);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDetalle_Facturas", new { id = detalle_Facturas.Iddetalle }, detalle_Facturas);
        }

        [HttpDelete("Iddetalle_Facturas")]
        public async Task<ActionResult<Detalle_Facturas>> DeleteDetalle_Facturas(int id)
        {
            var Detalle_Factura = await _context.Detalle_Facturas.FindAsync(id);
            if (Detalle_Factura == null)
            {
                return NotFound();
            }
            _context.Detalle_Facturas.Remove(Detalle_Factura);
            await _context.SaveChangesAsync();

            return Detalle_Factura;
        }

        private bool Detalle_FacturasExists(int id)
        {
            return _context.Detalle_Facturas.Any(e => e.Iddetalle == id);
        }

    }
}



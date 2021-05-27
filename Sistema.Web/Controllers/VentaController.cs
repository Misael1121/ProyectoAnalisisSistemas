using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema.Datos;
using Sistema.Entidad.Ventas;

namespace Sistema.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        private readonly DBContextSistema _context;

        public VentaController(DBContextSistema context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Venta>>> GetVentas()
        {
            return await _context.Ventas.ToListAsync();
        }

        [HttpGet("{IdVenta}")]
        public async Task<ActionResult<Venta>> GetVentas(int id)
        {
            var Venta = await _context.Ventas.FindAsync(id);
            if (Venta == null)
            {
                return NotFound();
            }
            return Venta;
        }

        [HttpGet("{IdVenta}")]
        public async Task<ActionResult> PutVenta(int id, Venta venta)
        {
            if (id != venta.idventa)
            {
                return BadRequest();
            }
            _context.Entry(venta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VentaExists(id))
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
        public async Task<ActionResult> PutVentas(int id, Venta venta)
        {
            _context.Ventas.Add(venta);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVentas", new { id = venta.idventa }, venta);
        }

        [HttpDelete("idVentas")]
        public async Task<ActionResult<Venta>> DeleteVenta(int id)
        {
            var Venta = await _context.Ventas.FindAsync(id);
            if (Venta == null)
            {
                return NotFound();
            }
            _context.Ventas.Remove(Venta);
            await _context.SaveChangesAsync();

            return Venta;
        }

        private bool VentaExists(int id)
        {
            return _context.Categorias.Any(e => e.idcategoria == id);
        }

    }
}

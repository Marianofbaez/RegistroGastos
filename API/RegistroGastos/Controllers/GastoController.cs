using Microsoft.AspNetCore.Mvc;
using RegistroGastos.Models;
using Microsoft.EntityFrameworkCore;

namespace RegistroGastos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GastoController : ControllerBase
    {
        private readonly AppDbContext _context;
        
        public GastoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Gasto>>> Get()
        {
            return await _context.Gastos.OrderByDescending(g => g.Fecha).ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Gasto>> Post(Gasto gasto)
        {
            _context.Gastos.Add(gasto);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = gasto.Id }, gasto);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServerScanPort.Data;
using System.Linq;

namespace ServerScanPort.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScaningsController : ControllerBase
    {
        private readonly ScanPortContext _context;

        public ScaningsController(ScanPortContext context)
        {
            _context = context;
        }

        // GET: api/Scanings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Scaning>>> GetScanings()
        {
            if (_context.Scanings == null)
            {
                return NotFound();
            }
            return await _context.Scanings.ToListAsync();
        }

        // GET: api/Scanings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Scaning>> GetScaning(int id)
        {
            if (_context.Scanings == null)
            {
                return NotFound();
            }
            var scaning = await _context.Scanings.FindAsync(id);

            if (scaning == null)
            {
                return NotFound();
            }

            return scaning;
        }

        // PUT: api/Scanings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutScaning(int id, Scaning scaning)
        {
            if (id != scaning.Id)
            {
                return BadRequest();
            }

            _context.Entry(scaning).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScaningExists(id))
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

        // POST: api/Scanings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Scaning>> PostScaning(Scaning scaning)
        {
            if (_context.Scanings == null)
            {
                return Problem("Entity set 'ScanPortContext.Scanings'  is null.");
            }
            //Запуск приложения для получения портов
            ServerScanPort.Operation.Nmap nmap = new();
            scaning.Port = nmap.TakePorts(scaning.IpAdress);


            _context.Scanings.Add(scaning);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetScaning", new { id = scaning.Id }, scaning);
        }

        // DELETE: api/Scanings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteScaning(int id)
        {
            if (_context.Scanings == null)
            {
                return NotFound();
            }
            var scaning = await _context.Scanings.FindAsync(id);
            if (scaning == null)
            {
                return NotFound();
            }

            _context.Scanings.Remove(scaning);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ScaningExists(int id)
        {
            return (_context.Scanings?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

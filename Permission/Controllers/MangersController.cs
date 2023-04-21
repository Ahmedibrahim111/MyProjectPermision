using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Permission.Model;

namespace Permission.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MangersController : ControllerBase
    {
        private readonly PermissionContext _context;

        public MangersController(PermissionContext context)
        {
            _context = context;
        }

        // GET: api/Mangers
        [HttpGet]
        public async Task<IActionResult> Getmangers()
        {
          if (_context.mangers == null)
          {
              return NotFound();
          }
            return Ok( await _context.mangers.ToListAsync());
        }

        // GET: api/Mangers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetManger(int id)
        {
          if (_context.mangers == null)
          {
              return NotFound();
          }
            var manger = await _context.mangers.FindAsync(id);

            if (manger == null)
            {
                return NotFound();
            }

            return Ok( manger);
        }

        // PUT: api/Mangers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutManger(int id, Manger manger)
        {
            if (id != manger.Id)
            {
                return BadRequest();
            }

            var Manger = await _context.mangers.ToListAsync();
            if (manger.Name == "" || manger.Name == "String")
            {
                return BadRequest("please input manger Name ");
            }
            if (Manger.Where(x => x.Name == manger.Name && x.Id != id).Any())
            {
                return BadRequest("the name replay");
            }
            var Mangervalue = Manger.Where(x => x.Id == id).FirstOrDefault();
            Mangervalue.Name = manger.Name;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MangerExists(id))
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

        // POST: api/Mangers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostManger(Manger manger)
        {
          if (_context.mangers == null)
          {
              return Problem("Entity set 'PermissionContext.mangers'  is null.");
          }
            var Manger = await _context.mangers.ToListAsync();
            if (manger.Name == "" || manger.Name == "String")
            {
                return BadRequest("please input Department Name ");
            }
            if (Manger.Where(x => x.Name == manger.Name).Any())
            {
                return BadRequest("the name replay");
            }
            _context.mangers.Add(manger);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetManger", new { id = manger.Id }, manger);
        }

        // DELETE: api/Mangers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteManger(int id)
        {
            if (_context.mangers == null)
            {
                return NotFound();
            }
            var manger = await _context.mangers.FindAsync(id);
            if (manger == null)
            {
                return NotFound();
            }

            _context.mangers.Remove(manger);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MangerExists(int id)
        {
            return (_context.mangers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

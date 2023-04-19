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
    public class DepartmentsController : ControllerBase
    {
        private readonly PermissionContext _context;

        public DepartmentsController(PermissionContext context)
        {
            _context = context;
        }

        // GET: api/Departments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Department>>> Getdepartments()
        {
          if (_context.departments == null)
          {
              return NotFound();
          }
            return await _context.departments.ToListAsync();
        }

        // GET: api/Departments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Department>> GetDepartment(int id)
        {
          if (_context.departments == null)
          {
              return NotFound();
          }

            var department = await _context.departments.FindAsync(id);

            if (department == null)
            {
                return NotFound();
            }

            return department;
        }

        // PUT: api/Departments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepartment(int id, Department department)
        {
            if (id != department.Id)
            {
                return BadRequest();
            }

            var Deparment = await _context.departments.ToListAsync();
            if (department.Name == "" || department.Name == "String")
            {
                return BadRequest("please input Department Name ");
            }
            if (Deparment.Where(x=>x.Name== department.Name&&x.Id != id).Any())
            {
                return BadRequest("the name replay");
            }
           var Deparmentvalue= Deparment.Where(x => x.Id == id).FirstOrDefault();
            Deparmentvalue.Name = department.Name;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartmentExists(id))
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

        // POST: api/Departments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Department>> PostDepartment(Department department)
        {
          if (_context.departments == null)
          {
              return Problem("Entity set 'PermissionContext.departments'  is null.");
          }
            var Deparment = await _context.departments.ToListAsync();
            if (department.Name == "" || department.Name == "String")
            {
                return BadRequest("please input Department Name ");
            }
            if (Deparment.Where(x => x.Name == department.Name).Any())
            {
                return BadRequest("the name replay");
            }
            _context.departments.Add(department);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDepartment", new { id = department.Id }, department);
        }

        // DELETE: api/Departments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            if (_context.departments == null)
            {
                return NotFound();
            }
            var department = await _context.departments.FindAsync(id);
            if (department == null)
            {
                return NotFound();
            }

            _context.departments.Remove(department);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DepartmentExists(int id)
        {
            return (_context.departments?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Permission.Model;
using Permission.Vm;

namespace Permission.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkPermitRequestsController : ControllerBase
    {
        private readonly PermissionContext _context;

        public WorkPermitRequestsController(PermissionContext context)
        {
            _context = context;
        }

        // GET: api/WorkPermitRequests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorkPermitRequest>>> GetworkPermitRequests()
        {
          if (_context.workPermitRequests == null)
          {
              return NotFound();
          }
            return await _context.workPermitRequests.ToListAsync();
        }
      //  GET: api/WorkPermitRequests
       [HttpGet("/GetworkPermitRequestsByMangerId {MangerId}")]
        public async Task<ActionResult<IEnumerable<WorkPermmisionVm>>> GetworkPermitRequestsByMangerId(int MangerId)
        {
            if (_context.workPermitRequests == null)
            {
                return NotFound();
            }
            var list= await _context.workPermitRequests.Include(x=>x.Manger).Include(x => x.Department).Where(x => x.MangerId == MangerId).Select(x => new WorkPermmisionVm
            {
                MangerName = x.Manger.Name,
                EmployeeName = x.EmployeeName,
                UpdatedAt = x.UpdatedAt,
                CreatedAt = x.CreatedAt,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                Status = x.Status,
                DeaparementNme = x.
            Department.Name,
                Id = x.Id

            }).ToListAsync();
            return list;
        }

        // GET: api/WorkPermitRequests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WorkPermitRequest>> GetWorkPermitRequest(int id)
        {
          if (_context.workPermitRequests == null)
          {
              return NotFound();
          }
            var workPermitRequest = await _context.workPermitRequests.FindAsync(id);

            if (workPermitRequest == null)
            {
                return NotFound();
            }

            return workPermitRequest;
        }

        // PUT: api/WorkPermitRequests/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorkPermitRequest(int id, WorkPermitRequest workPermitRequest)
        {
            if (id != workPermitRequest.Id)
            {
                return BadRequest("please input Id");
            }
            if (workPermitRequest.MangerId == 0)
            {
                return BadRequest("please select manger");
            }
            if (workPermitRequest.DepartmentId == 0)
            {
                return BadRequest("please select Department");
            }
            if (workPermitRequest.EmployeeName == "" || workPermitRequest.EmployeeName == "String")
            {
                return BadRequest("please input Employee Name");
            }
            if (workPermitRequest.EmployeeRole == "" || workPermitRequest.EmployeeRole == "String")
            {
                return BadRequest("please input Employee Role");
            }
            if (workPermitRequest.Equipment == "" || workPermitRequest.Equipment == "String")
            {
                return BadRequest("please input Equipment");
            }
            if (workPermitRequest.EquipmentUsed == "" || workPermitRequest.EquipmentUsed == "String")
            {
                return BadRequest("please input Equipment Used");
            }
            if (workPermitRequest.WorkConditions == "" || workPermitRequest.WorkConditions == "String")
            {
                return BadRequest("please input Work Conditions ");
            }
            if (workPermitRequest.StartDate == null)
            {
                return BadRequest("please input Start Date");
            }
            if (workPermitRequest.EndDate == null)
            {
                return BadRequest("please input End Date");
            }
            _context.Entry(workPermitRequest).State = EntityState.Modified;

            try
            {
                workPermitRequest.UpdatedAt
                    = DateTime.Now;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkPermitRequestExists(id))
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

        // POST: api/WorkPermitRequests
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<WorkPermitRequest>> PostWorkPermitRequest(WorkPermmisionPostVm workPermitRequest)
        {
          if (_context.workPermitRequests == null)
          {
              return Problem("Entity set 'PermissionContext.workPermitRequests'  is null.");
          }

            //check input
            if (workPermitRequest.MangerId == 0)
            {
                return BadRequest("please select manger");
            }
            if (workPermitRequest.DepartmentId == 0)
            {
                return BadRequest("please select Department");
            }
            if (workPermitRequest.EmployeeName == ""|| workPermitRequest.EmployeeName == "String")
            {
                return BadRequest("please input Employee Name");
            }
            if (workPermitRequest.EmployeeRole == "" || workPermitRequest.EmployeeRole == "String")
            {
                return BadRequest("please input Employee Role");
            }
            if (workPermitRequest.Equipment == "" || workPermitRequest.Equipment == "String")
            {
                return BadRequest("please input Equipment");
            }
            if (workPermitRequest.EquipmentUsed == "" || workPermitRequest.EquipmentUsed == "String")
            {
                return BadRequest("please input Equipment Used");
            }
            if (workPermitRequest.WorkConditions == "" || workPermitRequest.WorkConditions == "String")
            {
                return BadRequest("please input Work Conditions ");
            }
            if (workPermitRequest.StartDate == null )
            {
                return BadRequest("please input Start Date");
            }
            if (workPermitRequest.EndDate ==null)
            {
                return BadRequest("please input End Date");
            }
            WorkPermitRequest workPermitRequest1 = new WorkPermitRequest();
            workPermitRequest1.WorkPermitReject = 0;
            workPermitRequest1.WorkPermitReject = 0;
            workPermitRequest1.MangerId = workPermitRequest.MangerId;
            workPermitRequest1.DepartmentId = workPermitRequest.DepartmentId;
            workPermitRequest1.Status = "New";
            workPermitRequest1.CreatedAt = DateTime.Now;
            workPermitRequest1.Equipment = workPermitRequest.Equipment;
            workPermitRequest1.EmployeeName = workPermitRequest.EmployeeName;
            workPermitRequest1.EquipmentUsed = workPermitRequest.EquipmentUsed;
            workPermitRequest1.StartDate = workPermitRequest.StartDate;
            workPermitRequest1.FilesAttached = workPermitRequest.FilesAttached;
            workPermitRequest1.UpdatedAt = workPermitRequest.UpdatedAt;
            workPermitRequest1.EndDate = workPermitRequest.EndDate;
            workPermitRequest1.EmployeeRole = workPermitRequest.EmployeeRole;
            workPermitRequest1.WorkConditions = workPermitRequest.WorkConditions;
            _context.workPermitRequests.Add(workPermitRequest1);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWorkPermitRequest", new { id = workPermitRequest.Id }, workPermitRequest);
        }

        // DELETE: api/WorkPermitRequests/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkPermitRequest(int id)
        {
            if (_context.workPermitRequests == null)
            {
                return NotFound();
            }
            var workPermitRequest = await _context.workPermitRequests.FindAsync(id);
            if (workPermitRequest == null)
            {
                return NotFound();
            }

            _context.workPermitRequests.Remove(workPermitRequest);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpPut("AcceptRequest/{id}/{MangerId}")]
        public async Task<IActionResult> AcceptRequest(int id, int MangerId)
        {
            if (_context.workPermitRequests == null)
            {
                return NotFound();
            }
            var workPermitRequest = await _context.workPermitRequests.FindAsync(id);
            if (workPermitRequest == null)
            {
                return NotFound();
            }
            workPermitRequest.Status = "Approved";
            workPermitRequest.WorkPermitApprovers = MangerId;
            workPermitRequest.UpdatedAt = DateTime.Now;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkPermitRequestExists(id))
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
        [HttpPut("AcceptRejected/{id}/{MangerId}")]
        public async Task<IActionResult> AcceptRejected(int id, int MangerId)
        {
            if (_context.workPermitRequests == null)
            {
                return NotFound();
            }
            var workPermitRequest = await _context.workPermitRequests.FindAsync(id);
            if (workPermitRequest == null)
            {
                return NotFound();
            }
            workPermitRequest.Status = "Rejected";
            workPermitRequest.WorkPermitApprovers = MangerId;
            workPermitRequest.UpdatedAt = DateTime.Now;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkPermitRequestExists(id))
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

        private bool WorkPermitRequestExists(int id)
        {
            return (_context.workPermitRequests?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

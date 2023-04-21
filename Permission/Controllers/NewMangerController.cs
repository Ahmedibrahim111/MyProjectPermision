using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Permission.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Permission.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewMangerController : ControllerBase
    {

   
        // GET: api/<NewMangerController>
        [HttpGet]
        public async Task<IActionResult> Getmangers()
        {
            var List = new[]
      {
            new Manger()
            {
                Id =1,
                Name = "Ali",
                
            },
            new Manger()
            {
                Id = 2,
                Name = "Ahmed",
            }
        };
            if (List == null)
            {
                return NotFound();
            }
            return Ok(List.ToList());
        }


        // GET api/<NewMangerController>/5
        [HttpGet("{id}")]
        public  IActionResult GetManger(int id)
        {
            
            var List = new Manger[]
     {
            new Manger()
            {
                Id =1,
                Name = "Ali",

            },
            new Manger()
            {
                Id =2,
                Name = "Ahmed",
            }
           };
            var manger = List.FirstOrDefault(x=>x.Id==id);

            if (manger == null)
            {
                return NotFound();
            }

            return Ok(manger);
        }


        // POST api/<NewMangerController>
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutManger(int id, Manger manger)
        {
            
            var Manger = new Manger[]
     {
            new Manger()
            {
                Id = 1,
                Name = "Ali",

            },
            new Manger()
            {
                Id = 2,
                Name = "Ahmed",
            }
           };
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
          
                if (Mangervalue==null)
                {
                    return NotFound();
                }
                else
                {
                return Ok(Mangervalue);
                }
            

            return NoContent();
        }

        // POST: api/Mangers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult PostManger(Manger manger)
        {
            List<Manger> List = new List<Manger>();
            {
                var Manger = new Manger()
                {
                    Id = 1,
                    Name = "Ali",
                };
                var Manger2 = new Manger()
                {
                    Id = 2,
                    Name = "Ahmed",
                };
                List.Add(Manger);
                List.Add(Manger);



            };
            if (manger.Name == "" || manger.Name == "String")
            {
                return BadRequest("please input Department Name ");
            }
            if (List.Where(x => x.Name == manger.Name).Any())
            {
                return BadRequest("the name replay");
            }

            List.Add(manger);
            return CreatedAtAction("GetManger", new { id = manger.Id }, manger);
        }

        // DELETE: api/Mangers/5
        [HttpDelete("{id}")]
        public IActionResult DeleteManger(int id)
        {

            List<Manger> List = new List<Manger>();
     {
                var Manger = new Manger()
                {
                    Id = 1,
                    Name = "Ali",
                };
                var Manger2 = new Manger()
                {
                    Id = 2,
                    Name = "Ahmed",
                };
                List.Add(Manger);
                List.Add(Manger);

           };
            var manger = List.FirstOrDefault(x => x.Id == id);
            if (manger == null)
            {
                return NotFound();
            }

            List.Remove(manger);

            return NoContent();
        }

        
    }
}

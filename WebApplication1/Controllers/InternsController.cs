using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InternsController : ControllerBase
    {
        public readonly Singleton interns;

        public InternsController()
        {
            interns = Singleton.Interns;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            if (interns.GetCount() == 0)
                return NotFound();
            return Ok(interns.GetAll());
        }

        // GET api/values/5
        [HttpGet("{id:long}")]
        public IActionResult GetById(long id)
        {
            var item = interns.GetOne(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Intern intern)
        {
            if(interns.AddIntern(intern))
                return CreatedAtAction("GetById", new { id = intern.Id }, intern);
            return BadRequest();
        }

        // DELETE api/values/5
        [HttpDelete("{id:long}")]
        public IActionResult Delete(long id)
        {
            if (interns.DeleteIntern(id))
            {
                return Ok();
            }

            return NotFound();
        }
    }
}

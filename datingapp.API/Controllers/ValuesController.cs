using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using datingapp.API.Data;
using Microsoft.EntityFrameworkCore;
namespace datingapp.API.Controllers
{ 
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly datacontext _context;
        public ValuesController(datacontext context)
        {
            _context = context; 
        }
        //Get api/values
        [HttpGet]
        public async Task<IActionResult> GetValues(){
            var values = await _context.Values.ToListAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
         public async Task<IActionResult> GetValues(int id)
        {
            var value = await _context.Values.FirstOrDefaultAsync(x=> x.id == id);
            return Ok(value);
        }

        [HttpPost]
        
        public void Post([FromBody]  string value) 
        {

        }

        [HttpPut("{id}")]
        public void Put(int id,[FromBody] string value)
        {

        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_database_HTTP_Requests.Data;
using backend_database_HTTP_Requests.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend_database_HTTP_Requests.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly Context _context;
        public StudentsController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetValues()
        {
            var values = await _context.Students.ToListAsync();
            if (values != null)
            {
                return values;
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<ActionResult<Student>> Post_Values(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetValues", new { id = student.id }, student);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Student>> Delete_values(int id)
        {
            var values = await _context.Students.FindAsync(id);
            if (values == null)
            {
                return NotFound();
            }
            _context.Students.Remove(values);
            await _context.SaveChangesAsync();
            return values;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put_Values(int id, Student student)
        {
            if (id != student.id)
            {
                return BadRequest();
            }

            _context.Entry(student).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ValuesExists(id))
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

        private bool ValuesExists(int id)
        {
            return _context.Students.Any(x => x.id == id);
        }
    }
}

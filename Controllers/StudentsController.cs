using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_database_HTTP_Requests.Data;
using backend_database_HTTP_Requests.DTO;
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
        public async Task<ActionResult<IEnumerable<StudentDTO>>> GetStudents()
        {
            var student = from students in _context.Students join students_descriptions in _context.Students_Description on students.id equals students_descriptions.studentId
                          select new StudentDTO {
                              studentId = students.id,
                              age = students_descriptions.age,
                              firstName = students_descriptions.firstName,
                              lastName = students_descriptions.lastName,
                              adress = students_descriptions.adress,
                              country = students_descriptions.country,
                              grade = students.grade
                          };

            return await student.ToListAsync();
        }

        [HttpGet("{id}")]
        public ActionResult<StudentDTO> GetStudents_byId(int id)
        {
            var student = from students in _context.Students
                          join students_descriptions in _context.Students_Description on students.id equals students_descriptions.studentId
                          select new StudentDTO
                          {
                              studentId = students.id,
                              age = students_descriptions.age,
                              firstName = students_descriptions.firstName,
                              lastName = students_descriptions.lastName,
                              adress = students_descriptions.adress,
                              country = students_descriptions.country,
                              grade = students.grade
                          };

            var student_by_id = student.ToList().Find(x => x.studentId == id);

            if (student_by_id == null)
            {
                return NotFound();
            }
            return student_by_id;
        }


        [HttpPost]
        public async Task<ActionResult> Add_Students(AddStudent studentDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var student = new Student()
            {
                grade = studentDTO.grade
            };
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();

            var student_description = new Student_description()
            {
                studentId = student.id,
                firstName = studentDTO.firstName,
                lastName = studentDTO.lastName,
                age = studentDTO.age,
                adress = studentDTO.country,
                country = studentDTO.country
            };
            await _context.AddAsync(student_description);

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudents", new { id = student.id }, studentDTO);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<Student>> Delete_Students(int id)
        {
            var student = _context.Students.Find(id);
            var student_description = _context.Students_Description.SingleOrDefault(x => x.studentId == id);

            if (student == null)
            {
                return NotFound();
            }
            else
            {
                _context.Remove(student);
                _context.Remove(student_description);
                await _context.SaveChangesAsync();
                return student;
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update_Students(int id, StudentDTO student)
        {
            if (id != student.studentId || !StudentExists(id))
            {
                return BadRequest();
            }
            else
            {
                var students = _context.Students.SingleOrDefault(x => x.id == id);
                var students_description = _context.Students_Description.SingleOrDefault(x => x.studentId == id);
                students.id = student.studentId;
                students.grade = student.grade;
                students_description.firstName = student.firstName;
                students_description.lastName = student.lastName;
                students_description.age = student.age;
                students_description.adress = student.adress;
                students_description.country = student.country;
                await _context.SaveChangesAsync();
                return NoContent();
            }
        }

        private bool StudentExists(int id)
        {
            return _context.Students.Any(x => x.id == id);
        }
    }
}

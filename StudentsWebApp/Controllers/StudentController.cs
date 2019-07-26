using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Students.Data;
using Students.Services;

namespace StudentsWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudent _Student;
        public StudentController(IStudent Student)
        {
            _Student = Student;
        }
        [HttpPost]
        public async Task<IActionResult> Save([FromBody] Student _student)
        {
            if(_student == null)
            {
                return BadRequest();
            }

            POJO model = await _Student.Save(_student);
            if (model == null)
            {
                return NotFound();
            }
            return Ok(model);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetStudent(int? Id)
        {
            if (Id == null)
            {
                return BadRequest();
            }
            Student model = await _Student.GetStudent(Id);
            if (model == null)
            {
                return NotFound();
            }
            return Ok(model);
        }

        [HttpGet]
        public  IActionResult GetStudents()
        {

            IQueryable<Student> model =  _Student.GetStudents;
            if (model == null)
            {
                return NotFound();
            }
            return Ok(model);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int? id)
        {           
            if (id == null)
            {
                return BadRequest();
            }
            POJO model=await _Student.DeleteAsync(id);

            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

    }
}
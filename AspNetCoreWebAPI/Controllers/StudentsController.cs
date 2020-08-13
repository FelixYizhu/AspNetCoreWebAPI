using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreWebAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreWebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        // Create a list of students
        List<Student> _oStudents = new List<Student>()
        {
            new Student(){Id=1, Name="Felix", Roll=10001},
            new Student(){Id=2, Name="Bob", Roll=10002},
            new Student(){Id=3, Name="Joah", Roll=10003},
            new Student(){Id=4, Name="Joe", Roll=10004},
            new Student(){Id=5, Name="Lucy", Roll=10005}
        };

        
        //Get all students
        [HttpGet]
        public IActionResult Gets()
        {
            if (_oStudents.Count == 0)
            {
                return NotFound("No List found");
            }
            return Ok(_oStudents);
        }
        // Get student by Id
        [HttpGet("GetStudent")]
        public IActionResult Get(int id)
        {

            var _oStudent = _oStudents.SingleOrDefault(x =>x.Id== id);
            if (_oStudent == null)
            {
                return NotFound("Student whose Id is "+id +" not found");
            }
            return Ok(_oStudent);

        }

        //Add one student
        [HttpPost]
        public IActionResult Save(Student _oStudent)
        {

            _oStudents.Add(_oStudent);
            if (_oStudents.Count == 0)
            {
                return NotFound("No List Found");
            }
            return Ok(_oStudents);
        }
        
        //Delete one student
        [HttpDelete]
        public IActionResult Deletetudent(int id)
        {

            var _oStudent = _oStudents.SingleOrDefault(x =>x.Id== id);
            if(_oStudent==null)
            {
                return NotFound("student whoese Id is "+ id +" noyt found");
            }
            _oStudents.Remove(_oStudent);
            if (_oStudents.Count == 0)
            {
                return NotFound("No List Found");
            }
            return Ok(_oStudents);
        }

    }
}

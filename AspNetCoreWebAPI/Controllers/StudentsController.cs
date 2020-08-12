using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreWebAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        List<Student> _oStudents = new List<Student>()
        {
            new Student(){Id=1, Name="Felix", Roll=1001},
            new Student(){Id=2, Name="Eric", Roll=1002},
            new Student(){Id=3, Name="Tom", Roll=1003},
            new Student(){Id=4, Name="Peter", Roll=1004},
            new Student(){Id=5, Name="Jack", Roll=1005}
        };
        
        //Get all students
        [HttpGet]
        public IActionResult Gets()
        {
            if (_oStudents.Count == 0)
            {
                return NotFound("No List Found");
            }
            return Ok(_oStudents);
        }

        // Get student by Id
        [HttpGet("GetStudent")]
        public IActionResult Get(int id)
        {
            var _oStudent = _oStudents.SingleOrDefault(x => x.Id == id);
            if (_oStudent == null)
            {
                return NotFound("No Student Found");
            }
            return Ok(_oStudent);

        }

        //Update one student
        [HttpPost]
        public IActionResult Save(Student _oStudent)
        {
            _oStudents.Add(_oStudent);
            if (_oStudents.Count == 0)
            {
                return NotFound("No List found");
            }
            return Ok(_oStudents);
        }
        
        //Delete one student
        [HttpDelete]
        public IActionResult Deletetudent(int id)
        {
            var _oStudent = _oStudents.SingleOrDefault(x => x.Id == id);
            if (_oStudent == null)
            {
                return NotFound("No Student whose id is " + id +" Found");
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

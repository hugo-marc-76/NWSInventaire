using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NWSInventaire.Server.Repository;
using NWSInventaire.Shared.Models;

namespace NWSInventaire.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {

        private readonly ILogger<StudentController> _logger;
        private readonly StudentRepository Students;

        public StudentController(ILogger<StudentController> logger, StudentRepository sRepository)
        {
            _logger = logger;
            Students = sRepository;
        }

        [HttpGet("GetAllStudent")]
        public List<Student> GetAllStudent()
        {
            return Students.GetAllStudent();
        }

        [HttpGet("GetStudent/{id}")]
        public Student GetStudent(int id)
        {
            return Students.GetStudent(id);
        }

        [HttpPost("AddStudent")]
        public IActionResult AddStudent(Student student)
        {
            return Students.AddStudent(student);
        }

        [HttpDelete("DeleteStudent/{id}")]
        public IActionResult DeleteStudent(int id)
        {
            return Students.DeleteStudent(id);
        }

        [HttpPut("PutStudent")]
        public IActionResult PutStudent(Student student)
        {
            return Students.PutStudent(student);
        }

    }
}

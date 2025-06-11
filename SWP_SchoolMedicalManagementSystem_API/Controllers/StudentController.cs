using Microsoft.AspNetCore.Mvc;
using SWP_SchoolMedicalManagementSystem_BussinessOject.DTO.Request;
using SWP_SchoolMedicalManagementSystem_BussinessOject.Service;

namespace SWP_SchoolMedicalManagementSystem_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        //1. Get all students
        [HttpGet("get-all-students")]
        public async Task<IActionResult> GetStudents()
        {
            var students = await _studentService.GetAllStudentsAsync();
            return Ok(students);
        }

        //2. Get student by ID
        [HttpGet("get-student-by-id/{studentId}")]
        public async Task<IActionResult> GetStudent(Guid studentId)
        {
            var student = await _studentService.GetStudentByIdAsync(studentId);
            return Ok(student);
        }

        //3. Get student by student code
        [HttpGet("get-student-by-student-code/{studentCode}")]
        public async Task<IActionResult> GetStudentByCode(string studentCode)
        {
            var student = await _studentService.GetStudentByStudentCodeAsync(studentCode);
            return Ok(student);
        }

        //4. Get students by parent ID
        [HttpGet("get-student-by-parent-id/{parentId}")]
        public async Task<IActionResult> GetStudentsByParent(Guid parentId)
        {
            var students = await _studentService.GetStudentsByParentIdAsync(parentId);
            return Ok(students);
        }

        //5. Get students by class
        [HttpGet("get-students-by-class-name/{className}")]
        public async Task<IActionResult> GetStudentsByClass(string className)
        {
            var students = await _studentService.GetStudentsByClassAsync(className);
            return Ok(students);
        }

        //6. Get students by school year
        [HttpGet("get-students-by-school-year/{schoolYear}")]
        public async Task<IActionResult> GetStudentsBySchoolYear(string schoolYear)
        {
            var students = await _studentService.GetStudentsBySchoolYearAsync(schoolYear);
            return Ok(students);
        }

        //7. Create a new student
        [HttpPost("create-student")]
        public async Task<IActionResult> CreateStudent([FromBody] StudentRequest request)
        {
            await _studentService.CreateStudentAsync(request);
            return Ok("Student created successfully.");

        }

        //8. Update an existing student
        [HttpPut("update-student/{studentId}")]
        public async Task<IActionResult> UpdateStudent(Guid studentId, [FromBody] StudentRequest request)
        {
            if (request == null)
            {
                return BadRequest("Invalid request data");
            }

            await _studentService.UpdateStudentAsync(studentId, request);
            return Ok("Student updated successfully.");
        }

        //9. Delete a student
        [HttpDelete("delete-student/{studentId}")]
        public async Task<IActionResult> DeleteStudent(Guid studentId)
        {
            await _studentService.DeleteStudentAsync(studentId);
            return Ok("Student deleted successfully.");
        }
    }
}

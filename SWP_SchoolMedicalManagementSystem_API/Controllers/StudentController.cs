using Microsoft.AspNetCore.Mvc;
using SWP_SchoolMedicalManagementSystem_BussinessOject.DTO.Request;
using SWP_SchoolMedicalManagementSystem_BussinessOject.DTO.Response;
using SWP_SchoolMedicalManagementSystem_BussinessOject.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SWP_SchoolMedicalManagementSystem_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        /// <summary>
        /// Get all students
        /// </summary>
        /// <returns>List of students</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<StudentResponse>), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<IEnumerable<StudentResponse>>> GetStudents()
        {
            var students = await _studentService.GetAllStudentsAsync();
            if (students == null || !students.Any())
            {
                return NotFound("No students found");
            }
            return Ok(students);
        }

        /// <summary>
        /// Get student by ID
        /// </summary>
        /// <param name="id">Student ID</param>
        /// <returns>Student object</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(StudentResponse), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<StudentResponse>> GetStudent(Guid id)
        {
            var student = await _studentService.GetStudentByIdAsync(id);
            if (student == null)
            {
                return NotFound($"Student with ID {id} not found");
            }
            return Ok(student);
        }

        /// <summary>
        /// Create a new student
        /// </summary>
        /// <param name="request">Student creation request</param>
        /// <returns>Created student</returns>
        [HttpPost]
        [ProducesResponseType(typeof(StudentResponse), 201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<StudentResponse>> CreateStudent([FromBody] StudentRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var createdStudent = await _studentService.CreateStudentAsync(request, User.Identity?.Name ?? "System");
                return CreatedAtAction(nameof(GetStudent), new { id = createdStudent.Id }, createdStudent);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Update an existing student
        /// </summary>
        /// <param name="id">Student ID</param>
        /// <param name="request">Updated student information</param>
        /// <returns>Updated student</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(StudentResponse), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<StudentResponse>> UpdateStudent(Guid id, [FromBody] StudentRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var updatedStudent = await _studentService.UpdateStudentAsync(id, request, User.Identity?.Name ?? "System");
                return Ok(updatedStudent);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Delete a student
        /// </summary>
        /// <param name="id">Student ID</param>
        /// <returns>No content</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteStudent(Guid id)
        {
            var exists = await _studentService.StudentExistsAsync(id);
            if (!exists)
            {
                return NotFound($"Student with ID {id} not found");
            }

            var result = await _studentService.DeleteStudentAsync(id);
            if (!result)
            {
                return NotFound($"Student with ID {id} not found");
            }

            return NoContent();
        }

        /// <summary>
        /// Get students by parent ID
        /// </summary>
        /// <param name="parentId">Parent ID</param>
        /// <returns>List of students</returns>
        [HttpGet("parent/{parentId}")]
        [ProducesResponseType(typeof(IEnumerable<StudentResponse>), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<IEnumerable<StudentResponse>>> GetStudentsByParent(Guid parentId)
        {
            var students = await _studentService.GetStudentsByParentIdAsync(parentId);
            if (students == null || !students.Any())
            {
                return NotFound($"No students found for parent ID {parentId}");
            }
            return Ok(students);
        }

        /// <summary>
        /// Get students by class
        /// </summary>
        /// <param name="className">Class name</param>
        /// <returns>List of students</returns>
        [HttpGet("class/{className}")]
        [ProducesResponseType(typeof(IEnumerable<StudentResponse>), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<IEnumerable<StudentResponse>>> GetStudentsByClass(string className)
        {
            var students = await _studentService.GetStudentsByClassAsync(className);
            if (students == null || !students.Any())
            {
                return NotFound($"No students found in class {className}");
            }
            return Ok(students);
        }

        /// <summary>
        /// Get students by school year
        /// </summary>
        /// <param name="schoolYear">School year</param>
        /// <returns>List of students</returns>
        [HttpGet("year/{schoolYear}")]
        [ProducesResponseType(typeof(IEnumerable<StudentResponse>), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<IEnumerable<StudentResponse>>> GetStudentsBySchoolYear(string schoolYear)
        {
            var students = await _studentService.GetStudentsBySchoolYearAsync(schoolYear);
            if (students == null || !students.Any())
            {
                return NotFound($"No students found for school year {schoolYear}");
            }
            return Ok(students);
        }

        /// <summary>
        /// Get student by student code
        /// </summary>
        /// <param name="studentCode">Student code</param>
        /// <returns>Student object</returns>
        [HttpGet("code/{studentCode}")]
        [ProducesResponseType(typeof(StudentResponse), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<StudentResponse>> GetStudentByCode(string studentCode)
        {
            var student = await _studentService.GetStudentByStudentCodeAsync(studentCode);
            if (student == null)
            {
                return NotFound($"Student with code {studentCode} not found");
            }
            return Ok(student);
        }
    }
}

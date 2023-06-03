using Curs.Constants;
using Curs.Contract;
using Curs.Repository.Users;
using Domain.Constants;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Contracts;

namespace Curs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService studentService;

        public StudentController(IStudentService studentService)
        {
            this.studentService = studentService;
        }

        [Authorize(Policy = "Student")]
        [HttpPost("AddExamPass")]
        public async Task<IActionResult> AddExamPass(AddExamContract contract)
        {
            if (!contract.SubjectId.HasValue
                || !contract.Result.HasValue
                || !Enum.IsDefined(typeof(SubjectId), contract.SubjectId.Value))
            {
                return BadRequest();
            }

            var studentIdString = User.Claims.First(c => c.Type == CustomClaimTypes.StudentId).Value;
            var studentId = int.Parse(studentIdString);
            await studentService.AddExamResult(studentId, (SubjectId)contract.SubjectId.Value, contract.Result.Value);
            return Ok();
        }

        [Authorize(Policy = "Student")]
        [HttpGet("Result")]
        public async Task<IActionResult> Result(
            [FromQuery] int? studyFieldId,
            [FromQuery] ICollection<int>? subjectsIdsContract)
        {
            if (!studyFieldId.HasValue
                || subjectsIdsContract == null
                || subjectsIdsContract.Distinct().Count() != 3
                || subjectsIdsContract.Any(id => !Enum.IsDefined(typeof(SubjectId), id)))
            {
                return BadRequest();
            }

            var studentIdString = User.Claims.First(c => c.Type == CustomClaimTypes.StudentId).Value;
            var studentId = int.Parse(studentIdString);
            var subjectsIds = subjectsIdsContract.Select(id => (SubjectId)id).ToList();
            var result = await studentService.CalculateCost(studentId, studyFieldId.Value, subjectsIds);
            return Ok(result);
        }
    }
}

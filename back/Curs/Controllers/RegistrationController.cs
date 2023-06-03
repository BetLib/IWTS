using Curs.Contract;
using Microsoft.AspNetCore.Mvc;
using Curs.Repository.Users;
using Curs.Infrastracture.Exceptions;

namespace Curs.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class RegistrationController: ControllerBase
    {

        private readonly IStudentService studentService;

        public RegistrationController(IStudentService studentService)
        {
            this.studentService = studentService;
        }

        [HttpPost("Student")]
        public async Task<ActionResult> Post([FromBody] RegistrationContract contract)
        {

            if (string.IsNullOrEmpty(contract.Password?.Trim())
                || string.IsNullOrEmpty(contract.Login?.Trim()))
            {
                return BadRequest();
            }
            try
            {
                await studentService.Registration(contract.Login, contract.Password);
            } catch (IwtsException ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }
    }
}

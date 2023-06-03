using Curs.Contract;
using Curs.Infrastracture.Exceptions;
using Curs.Repository.Users;
using Curs.Services.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Curs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly IAuthorizationService autorizetionService;

        public AuthorizationController(IAuthorizationService autorizetionService)
        {
            this.autorizetionService = autorizetionService;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] RegistrationContract contract) {
            if (string.IsNullOrEmpty(contract.Password?.Trim())
                || string.IsNullOrEmpty(contract.Login?.Trim()))
            {
                return BadRequest();
            }

            try
            {
                var token = await autorizetionService.Authorization(contract.Login, contract.Password);
                return Ok(token);
            }
            catch (IwtsException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

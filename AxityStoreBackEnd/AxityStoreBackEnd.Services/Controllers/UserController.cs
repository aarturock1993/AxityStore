using AxityStoreBackEnd.Infrastructure.Interfaces;
using AxityStoreBackEnd.Services.Model.Request;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AxityStoreBackEnd.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController: ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult> Login([FromBody] ModelLogin login)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var user = await _userService.Login(login.Name, login.LastName);

            if (user == null)
                return NotFound();

            return Ok(user);
        }
    }
}

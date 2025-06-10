using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using todo.list.application.Services.Contracs;
using todo.list.common.Models.Requests;

namespace todo.list.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController(IUserService service) : ControllerBase
    {
        public IUserService Service { get; } = service;

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] AccountRegisterRequest request)
        {
            var result = await Service.RegisterAsync(request);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        } 
    }
}

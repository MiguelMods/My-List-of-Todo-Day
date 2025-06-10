using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using todo.list.application.Services.Contracs;
using todo.list.common.Extensions;
using todo.list.domain.Entities;

namespace todo.list.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController(IUserService userService) : ControllerBase
    {
        public IUserService UserService { get; } = userService;

        [HttpGet("")]
        public async Task<IActionResult> Get()
        {
            var users = await UserService.GetAllAsync();
            return Ok(users.IsASuccess());
        }

        [HttpGet("{rowguid}")]
        public async Task<IActionResult> Get(string rowguid)
        {
            var user = await UserService.GetByRowGuidAsync(rowguid);

            if (user == null)
                return NotFound();

            return Ok(user.IsASuccess());
        }

        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody] UserEntity user)
        {
            if (user == null)
                return BadRequest("User cannot be null");
            
            var createdUser = await UserService.AddAsync(user);
            
            return CreatedAtAction(nameof(Get), new { rowguid = createdUser.RowGuid }, createdUser.IsASuccess());
        }

        [HttpPut("")]
        public async Task<IActionResult> Put([FromBody] UserEntity user)
        {
            if (user == null)
                return BadRequest("User cannot be null");

            var updateResult = await UserService.UpdateAsync(user);

            if(updateResult is null)
                return NotFound("User not found");

            return CreatedAtAction(nameof(Get), new { rowguid = updateResult.RowGuid }, updateResult.IsASuccess());
        }
    }
}

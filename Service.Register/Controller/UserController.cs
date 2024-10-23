using Microsoft.AspNetCore.Mvc;
using Service.Register.Application.Abstractions;
using Service.Register.Application.Abstractions.Features;
using Service.Register.Application.Abstractions.Features.Request;

namespace Service.Register.API.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsersService _userService;

        public UsuarioController(IUsersService userService)
        {
            _userService = userService;
        }

        [HttpPost("createUser")]
        public async Task<IActionResult> Create([FromBody] UserViewModel user)
        {
            var userCreateRequest = new UserCreateRequest
            {
                Name = user.Name,
                Senha = user.Senha
            };

            var response = await _userService.Create(userCreateRequest);

            if (response.IsValid)
            {
                // Retorna 201 Created com a URL para o novo recurso
                return CreatedAtAction(nameof(GetUserById), new { id = response }, new { message = response.Message });
            }
            else
            {
                // Retorna 400 Bad Request com os erros
                return BadRequest(new { errors = response.Notifications });
            }
        }

        [HttpGet("users/{id}")]
        public async Task<IActionResult> GetUserById(string Id)
        {
            var user = await _userService.GetUserById(Id);
            if (user != null)
            {
                return Ok(user.Data);
            }
            return NotFound();
        }

        [HttpPost("login")]
        public async Task<IActionResult> ValidarUser([FromBody] LoginRequest user)
        {
            var usuario = await _userService.ValidarUser(user);

            if (usuario != null)
            {
                return Ok(new { success = true, data = usuario.Data });
            }

            return Unauthorized(new { success = false, message = "Usuário ou senha inválidos." });
        }



    }

}

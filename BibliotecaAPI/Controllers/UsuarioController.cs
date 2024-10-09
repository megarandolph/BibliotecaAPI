using BibliotecaAPI.DTO;
using BibliotecaAPI.Models;
using BibliotecaAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;



namespace BibliotecaAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {

        private readonly IUsuarioServices _services;
        public UsuarioController(IUsuarioServices UsuarioServices)
        {
            _services = UsuarioServices;
        }

        [HttpGet]
        public async Task<ActionResult<Response<Usuario>>> Get(int type = 0, int UsuarioId = 0)
        {

            if (!ModelState.IsValid)
            {
                var validationErrors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage);
                return BadRequest(validationErrors); // Código 400 Bad Request
            }

            var result = _services.Get(type, UsuarioId);

            if (result.DataList == null)
            {
                return NotFound(result); // Código 404 Not Found
            }

            if (result.Succeded)
            {
                return Ok(result); // Código 200 OK
            }
            else
            {
                return StatusCode(500, "Internal server error"); // Código 500 Internal Server Error
            }
        }

        [HttpPost]
        public async Task<ActionResult<Response>> Post(UsuarioDTO param)
        {

            if (param == null)
            {
                return BadRequest("Invalid input data"); // Código 400 Bad Request
            }

            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid input data"); // Código 400 Bad Request
            }

            var result = _services.Post(param);

            if (result == null)
            {
                return NotFound("Resource not found"); // Código 404 Not Found
            }

            if (result.Succeded)
            {
                return StatusCode(201, result); // Código 200 OK
            }
            else
            {
                return StatusCode(500, result); // Código 500 Internal Server Error
            }
        }

        [HttpPut]
        public async Task<ActionResult<Response>> Put(UsuarioDTO param)
        {

            if (param == null)
            {
                return BadRequest("Invalid input data"); // Código 400 Bad Request
            }

            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid input data"); // Código 400 Bad Request
            }

            var result = _services.Put(param);

            if (result == null)
            {
                return NotFound("Resource not found"); // Código 404 Not Found
            }

            if (result.Succeded)
            {
                return StatusCode(202, result); // Código 200 OK
            }
            else
            {
                return StatusCode(500, result); // Código 500 Internal Server Error
            }
        }

        [HttpDelete]
        public async Task<ActionResult<Response>> Delete(int UsuarioId)
        {

            if (UsuarioId == null)
            {
                return BadRequest("Invalid input data"); // Código 400 Bad Request
            }

            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid input data"); // Código 400 Bad Request
            }

            var result = _services.Delete(UsuarioId);

            if (result == null)
            {
                return NotFound("Resource not found"); // Código 404 Not Found
            }

            if (result.Succeded)
            {
                return StatusCode(201, result); // Código 200 OK
            }
            else
            {
                return StatusCode(500, result); // Código 500 Internal Server Error
            }
        }
    }
}

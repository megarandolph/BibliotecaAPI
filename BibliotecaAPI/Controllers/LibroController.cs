using BibliotecaAPI.DTO;
using BibliotecaAPI.Models;
using BibliotecaAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;



namespace BibliotecaAPI.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class LibroController : ControllerBase
    {

        private readonly ILibroServices _services;
        public LibroController(ILibroServices LibroServices)
        {
            _services = LibroServices;
        }

        [HttpGet]
        public async Task<ActionResult<Response<LibroDTO>>> Get(int type = 0, int LibroId = 0)
        {

            if (!ModelState.IsValid)
            {
                var validationErrors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage);
                return BadRequest(validationErrors); // Código 400 Bad Request
            }

            var result = _services.Get(type, LibroId);

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
        //[Authorize]
        [HttpPost]
        public async Task<ActionResult<Response>> Post(LibroDTO param)
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
        [Authorize]
        [HttpPut]
        public async Task<ActionResult<Response>> Put(LibroDTO param)
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
        [Authorize]
        [HttpDelete]
        public async Task<ActionResult<Response>> Delete(int LibroId)
        {

            if (LibroId == null)
            {
                return BadRequest("Invalid input data"); // Código 400 Bad Request
            }

            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid input data"); // Código 400 Bad Request
            }

            var result = _services.Delete(LibroId);

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

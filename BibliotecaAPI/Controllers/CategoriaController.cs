using BibliotecaAPI.DTO;
using BibliotecaAPI.Models;
using BibliotecaAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;



namespace BibliotecaAPI.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CategoriaController : ControllerBase
    {

        private readonly ICategoriaServices _services;
        public CategoriaController(ICategoriaServices CategoriaServices)
        {
            _services = CategoriaServices;
        }

        [HttpGet]
        public async Task<ActionResult<Response<Categorium>>> Get(int type = 0, int CategoriaId = 0)
        {

            if (!ModelState.IsValid)
            {
                var validationErrors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage);
                return BadRequest(validationErrors); // Código 400 Bad Request
            }

            var result = _services.Get(type, CategoriaId);

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
        public async Task<ActionResult<Response>> Post(CategoriaDTO param)
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
        public async Task<ActionResult<Response>> Put(CategoriaDTO param)
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
        public async Task<ActionResult<Response>> Delete(int CategoriaId)
        {

            if (CategoriaId == null)
            {
                return BadRequest("Invalid input data"); // Código 400 Bad Request
            }

            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid input data"); // Código 400 Bad Request
            }

            var result = _services.Delete(CategoriaId);

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

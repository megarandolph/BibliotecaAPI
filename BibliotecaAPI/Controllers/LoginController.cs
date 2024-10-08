using BibliotecaAPI.DTO;
using BibliotecaAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BibliotecaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioServices _usuarioServices;
        private readonly IConfiguration _configuration;

        public LoginController(IUsuarioServices usuarioServices, IConfiguration configuration)
        {
            _usuarioServices = usuarioServices;
            _configuration = configuration;

        }

        [HttpPost]
        public IActionResult Login(LoginModel login)
        {

            var usuario = _usuarioServices.GetUsuario(login.Email).SingleData;


            if (usuario != null)
            {
                var secretKey = _configuration["JwtSettings:SecretKey"];

                // Crear un token JWT
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(secretKey); // La misma clave utilizada en la configuración del token
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("Email", usuario.Email),
                        new Claim("RolId", usuario.RolId.ToString())                        
                    }),
                    Expires = DateTime.UtcNow.AddHours(1), // Tiempo de expiración del token
                    Issuer = "BibliotecaFront", // Emisor válido
                    Audience = "BibliotecaApi", // Audiencia válida
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);

                // Retornar el token en la respuesta
                return Ok(new { Token = tokenString, usuario = usuario });
            }
            else
            {
                return Unauthorized(new { error = "Usuario o contraseña invalida, por favor intentelo de nuevo." });
            }
        }
    }
}

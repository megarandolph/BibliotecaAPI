using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaAPI.DTO
{
    public class UsuarioDTO
    {
        [Key]
        public int UsuarioId { get; set; }

        [StringLength(200)]
        [Unicode(false)]
        public string? Email { get; set; }

        public int? RolId { get; set; }
        public bool? Status { get; set; }
    }
}

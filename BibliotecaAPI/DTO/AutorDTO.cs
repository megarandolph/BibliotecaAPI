using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaAPI.DTO
{
    public class AutorDTO
    {
        [Key]
        public int AutorId { get; set; }

        [StringLength(200)]
        [Unicode(false)]
        public string? Nombre { get; set; }
        public bool? Status { get; set; }
    }
}

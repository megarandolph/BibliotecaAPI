using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaAPI.DTO
{
    public class CategoriaDTO
    {
        [Key]
        public int CategoriaId { get; set; }

        [StringLength(200)]
        [Unicode(false)]
        public string? Nombre { get; set; }
        public bool? Status { get; set; }
    }
}

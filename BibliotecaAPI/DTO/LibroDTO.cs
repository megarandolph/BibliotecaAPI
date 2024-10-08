using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaAPI.DTO
{
    public class LibroDTO
    {
        [Key]
        public int LibroId { get; set; }

        [StringLength(200)]
        [Unicode(false)]
        public string? Titulo { get; set; }

        [Unicode(false)]
        public string? Descripcion { get; set; }

        [Column("Fecha_publicacion", TypeName = "datetime")]
        public DateTime? FechaPublicacion { get; set; }
        public bool? Status { get; set; }

        public List<int?> Categorias { get; set; }
        public List<int?> Autores { get; set; }
    }
}

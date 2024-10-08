using System.ComponentModel.DataAnnotations;

namespace BibliotecaAPI.DTO
{
    public class LibroCategoriaDTO
    {
        [Key]
        public int LibroCategoriaId { get; set; }

        public int? LibroId { get; set; }

        public int? CategoriaId { get; set; }
        public bool? Status { get; set; }
    }
}

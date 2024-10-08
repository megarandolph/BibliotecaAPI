using System.ComponentModel.DataAnnotations;

namespace BibliotecaAPI.DTO
{
    public class LibroAutorDTO
    {
        [Key]
        public int LibroAutorId { get; set; }

        public int? LibroId { get; set; }

        public int? AutorId { get; set; }
        public bool? Status { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaAPI.Models;

[Table("Libro")]
public partial class Libro
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

    [InverseProperty("Libro")]
    public virtual ICollection<LibroAutor> LibroAutors { get; set; } = new List<LibroAutor>();

    [InverseProperty("Libro")]
    public virtual ICollection<LibroCategorium> LibroCategoria { get; set; } = new List<LibroCategorium>();
}

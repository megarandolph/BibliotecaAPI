using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaAPI.Models;

[Table("LibroAutor")]
public partial class LibroAutor
{
    [Key]
    public int LibroAutorId { get; set; }

    public int? LibroId { get; set; }

    public int? AutorId { get; set; }

    public bool? Status { get; set; }

    [ForeignKey("AutorId")]
    [InverseProperty("LibroAutors")]
    public virtual Autor? Autor { get; set; }

    [ForeignKey("LibroId")]
    [InverseProperty("LibroAutors")]
    public virtual Libro? Libro { get; set; }
}

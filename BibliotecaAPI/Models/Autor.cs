using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaAPI.Models;

[Table("Autor")]
public partial class Autor
{
    [Key]
    public int AutorId { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string? Nombre { get; set; }

    public bool? Status { get; set; }

    [InverseProperty("Autor")]
    public virtual ICollection<LibroAutor> LibroAutors { get; set; } = new List<LibroAutor>();
}

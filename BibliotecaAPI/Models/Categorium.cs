using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaAPI.Models;

public partial class Categorium
{
    [Key]
    public int CategoriaId { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string? Nombre { get; set; }

    public bool? Status { get; set; }

    [InverseProperty("Categoria")]
    public virtual ICollection<LibroCategorium> LibroCategoria { get; set; } = new List<LibroCategorium>();
}

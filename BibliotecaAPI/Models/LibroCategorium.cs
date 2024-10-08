using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaAPI.Models;

public partial class LibroCategorium
{
    [Key]
    public int LibroCategoriaId { get; set; }

    public int? LibroId { get; set; }

    public int? CategoriaId { get; set; }

    public bool? Status { get; set; }

    [ForeignKey("CategoriaId")]
    [InverseProperty("LibroCategoria")]
    public virtual Categorium? Categoria { get; set; }

    [ForeignKey("LibroId")]
    [InverseProperty("LibroCategoria")]
    public virtual Libro? Libro { get; set; }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaAPI.Models;

[Table("usuario")]
public partial class Usuario
{
    [Key]
    public int UsuarioId { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string? Email { get; set; }

    public int? RolId { get; set; }

    public bool? Status { get; set; }
}

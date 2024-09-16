using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ZZZZRegistroArticulos.Models;

public partial class Articulo
{
    
    public int IdArticulo { get; set; }
    [Required(ErrorMessage = "El nombre es obligatorio.")]
    public string? Nombre { get; set; }
    [Required(ErrorMessage = "La descripcion es obligatoria.")]
    public string? Descripcion { get; set; }
    [Required(ErrorMessage = "El precio es obligatorio.")]
    public int? Precio { get; set; }
    [Required(ErrorMessage = "El lote es obligatorio.")]
    public int? Lote { get; set; }
}

using System;
using System.Collections.Generic;

namespace ChillTechnologies.Domain.Entities;

public partial class Aliado
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Ruc { get; set; }

    public int CategoriaId { get; set; }

    public string? Direccion { get; set; }

    public string? Distrito { get; set; }

    public string? Telefono { get; set; }

    public string? Email { get; set; }

    public string? Logo { get; set; }

    public string? Descripcion { get; set; }

    public decimal ComisionPorcentaje { get; set; }

    public string Estado { get; set; } = null!;

    public DateTime FechaRegistro { get; set; }

    public virtual CategoriasAliado Categoria { get; set; } = null!;

    public virtual ICollection<Premio> Premios { get; set; } = new List<Premio>();
}

using System;
using System.Collections.Generic;

namespace ChillTechnologies.Domain.Entities;

/// <summary>
/// Agrupacion de vehiculos dentro de una empresa cliente
/// </summary>
public partial class Flota
{
    public int Id { get; set; }

    public int EmpresaId { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public string Estado { get; set; } = null!;

    public DateTime FechaRegistro { get; set; }

    public virtual Empresa Empresa { get; set; } = null!;

    public virtual ICollection<Vehiculo> Vehiculos { get; set; } = new List<Vehiculo>();
}

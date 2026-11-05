using System;
using System.Collections.Generic;

namespace ChillTechnologies.Domain.Entities;

public partial class Poliza
{
    public int Id { get; set; }

    public int AseguradoraId { get; set; }

    public int VehiculoId { get; set; }

    public string Numero { get; set; } = null!;

    public DateOnly FechaInicio { get; set; }

    public DateOnly FechaFin { get; set; }

    public decimal PrimaSoles { get; set; }

    public string? Cobertura { get; set; }

    public string Estado { get; set; } = null!;

    public DateTime FechaRegistro { get; set; }

    public virtual Aseguradora Aseguradora { get; set; } = null!;

    public virtual ICollection<DescuentosPoliza> DescuentosPolizas { get; set; } = new List<DescuentosPoliza>();

    public virtual Vehiculo Vehiculo { get; set; } = null!;
}

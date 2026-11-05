using System;
using System.Collections.Generic;

namespace ChillTechnologies.Domain.Entities;

public partial class Mantenimiento
{
    public int Id { get; set; }

    public int VehiculoId { get; set; }

    public int TipoMantenimientoId { get; set; }

    public DateOnly? FechaProgramada { get; set; }

    public DateOnly? FechaRealizado { get; set; }

    public int? Kilometraje { get; set; }

    public decimal? CostoSoles { get; set; }

    public string? Taller { get; set; }

    public string? Observaciones { get; set; }

    public string Estado { get; set; } = null!;

    public DateTime FechaRegistro { get; set; }

    public virtual TiposMantenimiento TipoMantenimiento { get; set; } = null!;

    public virtual Vehiculo Vehiculo { get; set; } = null!;
}

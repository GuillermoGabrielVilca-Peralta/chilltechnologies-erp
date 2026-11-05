using System;
using System.Collections.Generic;

namespace ChillTechnologies.Domain.Entities;

/// <summary>
/// Historial de que conductor maneja que vehiculo de flota
/// </summary>
public partial class AsignacionesVehiculo
{
    public int Id { get; set; }

    public int VehiculoId { get; set; }

    public int UsuarioId { get; set; }

    public DateTime FechaInicio { get; set; }

    public DateTime? FechaFin { get; set; }

    public string Estado { get; set; } = null!;

    public virtual Usuario Usuario { get; set; } = null!;

    public virtual Vehiculo Vehiculo { get; set; } = null!;
}

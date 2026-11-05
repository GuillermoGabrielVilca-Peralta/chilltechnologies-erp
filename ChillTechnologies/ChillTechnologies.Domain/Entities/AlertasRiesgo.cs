using System;
using System.Collections.Generic;

namespace ChillTechnologies.Domain.Entities;

public partial class AlertasRiesgo
{
    public int Id { get; set; }

    public int UsuarioId { get; set; }

    public int? VehiculoId { get; set; }

    public int? ViajeId { get; set; }

    public string Motivo { get; set; } = null!;

    public string Severidad { get; set; } = null!;

    public string Estado { get; set; } = null!;

    public DateTime FechaAlerta { get; set; }

    public virtual Usuario Usuario { get; set; } = null!;

    public virtual Vehiculo? Vehiculo { get; set; }

    public virtual Viaje? Viaje { get; set; }
}

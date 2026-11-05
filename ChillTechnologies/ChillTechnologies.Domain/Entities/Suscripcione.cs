using System;
using System.Collections.Generic;

namespace ChillTechnologies.Domain.Entities;

/// <summary>
/// Ciclos de pago del plan Profesional
/// </summary>
public partial class Suscripcione
{
    public int Id { get; set; }

    public int UsuarioId { get; set; }

    public DateOnly FechaInicio { get; set; }

    public DateOnly FechaFin { get; set; }

    public decimal MontoSoles { get; set; }

    public int MetodoPagoId { get; set; }

    public string Estado { get; set; } = null!;

    public string? ReferenciaPago { get; set; }

    public DateTime FechaRegistro { get; set; }

    public virtual MetodosPago MetodoPago { get; set; } = null!;

    public virtual Usuario Usuario { get; set; } = null!;
}

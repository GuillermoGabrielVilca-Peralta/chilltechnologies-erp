using System;
using System.Collections.Generic;

namespace ChillTechnologies.Domain.Entities;

/// <summary>
/// Libro mayor inmutable: cada fila es una transaccion de puntos
/// </summary>
public partial class MovimientosPunto
{
    public int Id { get; set; }

    public int UsuarioId { get; set; }

    public string Tipo { get; set; } = null!;

    public int Puntos { get; set; }

    public string? Descripcion { get; set; }

    public int? ViajeId { get; set; }

    public int? CanjeId { get; set; }

    public DateTime FechaMovimiento { get; set; }

    public virtual Canje? Canje { get; set; }

    public virtual Usuario Usuario { get; set; } = null!;

    public virtual Viaje? Viaje { get; set; }
}

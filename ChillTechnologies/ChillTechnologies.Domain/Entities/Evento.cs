using System;
using System.Collections.Generic;

namespace ChillTechnologies.Domain.Entities;

public partial class Evento
{
    public int Id { get; set; }

    /// <summary>
    /// NULL si la deteccion ocurre fuera de un viaje activo
    /// </summary>
    public int? ViajeId { get; set; }

    public int CamaraId { get; set; }

    public int TipoEventoId { get; set; }

    public int ImpactoPuntaje { get; set; }

    public decimal? Latitud { get; set; }

    public decimal? Longitud { get; set; }

    public string? FotoEvidencia { get; set; }

    public DateTime FechaEvento { get; set; }

    public string? ClienteEventoId { get; set; }

    public virtual Camara Camara { get; set; } = null!;

    public virtual TiposEvento TipoEvento { get; set; } = null!;

    public virtual Viaje? Viaje { get; set; }
}

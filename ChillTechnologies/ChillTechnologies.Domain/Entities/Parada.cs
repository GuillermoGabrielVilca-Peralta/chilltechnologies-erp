using System;
using System.Collections.Generic;

namespace ChillTechnologies.Domain.Entities;

public partial class Parada
{
    public int Id { get; set; }

    public int ViajeId { get; set; }

    public int? GeocercaId { get; set; }

    public decimal? Latitud { get; set; }

    public decimal? Longitud { get; set; }

    public DateTime HoraInicio { get; set; }

    public DateTime? HoraFin { get; set; }

    public int? DuracionMinutos { get; set; }

    public virtual Geocerca? Geocerca { get; set; }

    public virtual Viaje Viaje { get; set; } = null!;
}

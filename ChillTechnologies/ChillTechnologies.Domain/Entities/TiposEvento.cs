using System;
using System.Collections.Generic;

namespace ChillTechnologies.Domain.Entities;

public partial class TiposEvento
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public int ImpactoPuntajeDefault { get; set; }

    public virtual ICollection<Evento> Eventos { get; set; } = new List<Evento>();
}

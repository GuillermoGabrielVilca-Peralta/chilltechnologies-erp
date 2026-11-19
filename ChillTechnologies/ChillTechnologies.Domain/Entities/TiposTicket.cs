using System;
using System.Collections.Generic;

namespace ChillTechnologies.Domain.Entities;

public partial class TiposTicket
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public bool Facturable { get; set; }

    public virtual ICollection<TicketsSoporte> TicketsSoportes { get; set; } = new List<TicketsSoporte>();
}

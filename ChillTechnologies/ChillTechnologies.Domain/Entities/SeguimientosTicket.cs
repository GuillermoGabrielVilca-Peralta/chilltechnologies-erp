using System;
using System.Collections.Generic;

namespace ChillTechnologies.Domain.Entities;

public partial class SeguimientosTicket
{
    public int Id { get; set; }

    public int TicketId { get; set; }

    public int? EmpleadoId { get; set; }

    public string Comentario { get; set; } = null!;

    public bool VisibleCliente { get; set; }

    public decimal HorasInvertidas { get; set; }

    public DateTime FechaSeguimiento { get; set; }

    public virtual Empleado? Empleado { get; set; }

    public virtual TicketsSoporte Ticket { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace ChillTechnologies.Domain.Entities;

public partial class TicketsSoporte
{
    public int Id { get; set; }

    public string Codigo { get; set; } = null!;

    public int ClienteId { get; set; }

    public int? ProductoSoftwareId { get; set; }

    public int TipoTicketId { get; set; }

    public int? AcuerdoServicioId { get; set; }

    public string Asunto { get; set; } = null!;

    public string? Descripcion { get; set; }

    public string Severidad { get; set; } = null!;

    public int? AsignadoAId { get; set; }

    public int? DefectoId { get; set; }

    public string Estado { get; set; } = null!;

    public DateTime FechaApertura { get; set; }

    public DateTime? FechaPrimeraRespuesta { get; set; }

    public DateTime? FechaCierre { get; set; }

    public virtual AcuerdosServicio? AcuerdoServicio { get; set; }

    public virtual Empleado? AsignadoA { get; set; }

    public virtual Cliente Cliente { get; set; } = null!;

    public virtual Defecto? Defecto { get; set; }

    public virtual ProductosSoftware? ProductoSoftware { get; set; }

    public virtual ICollection<SeguimientosTicket> SeguimientosTickets { get; set; } = new List<SeguimientosTicket>();

    public virtual TiposTicket TipoTicket { get; set; } = null!;
}

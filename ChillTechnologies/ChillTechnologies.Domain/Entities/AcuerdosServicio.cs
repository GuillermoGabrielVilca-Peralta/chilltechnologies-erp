using System;
using System.Collections.Generic;

namespace ChillTechnologies.Domain.Entities;

public partial class AcuerdosServicio
{
    public int Id { get; set; }

    public int ContratoId { get; set; }

    public string Nombre { get; set; } = null!;

    public decimal HorasRespuestaCritica { get; set; }

    public decimal HorasRespuestaAlta { get; set; }

    public decimal HorasRespuestaNormal { get; set; }

    public decimal HorasResolucion { get; set; }

    public decimal DisponibilidadPorcentaje { get; set; }

    public DateOnly VigenteDesde { get; set; }

    public DateOnly? VigenteHasta { get; set; }

    public virtual ContratosDesarrollo Contrato { get; set; } = null!;

    public virtual ICollection<TicketsSoporte> TicketsSoportes { get; set; } = new List<TicketsSoporte>();
}

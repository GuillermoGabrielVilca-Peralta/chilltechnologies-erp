using System;
using System.Collections.Generic;

namespace ChillTechnologies.Domain.Entities;

public partial class ContratosDesarrollo
{
    public int Id { get; set; }

    public string Numero { get; set; } = null!;

    public int ClienteId { get; set; }

    public string Descripcion { get; set; } = null!;

    public DateOnly FechaInicio { get; set; }

    public DateOnly? FechaFin { get; set; }

    public decimal MontoTotal { get; set; }

    public string Moneda { get; set; } = null!;

    public string CondicionPago { get; set; } = null!;

    public string Estado { get; set; } = null!;

    public DateTime FechaRegistro { get; set; }

    public virtual ICollection<AcuerdosServicio> AcuerdosServicios { get; set; } = new List<AcuerdosServicio>();

    public virtual Cliente Cliente { get; set; } = null!;

    public virtual ICollection<Proyecto> Proyectos { get; set; } = new List<Proyecto>();
}

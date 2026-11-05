using System;
using System.Collections.Generic;

namespace ChillTechnologies.Domain.Entities;

public partial class DescuentosPoliza
{
    public int Id { get; set; }

    public int PolizaId { get; set; }

    public DateOnly PeriodoInicio { get; set; }

    public DateOnly PeriodoFin { get; set; }

    public decimal PuntajePromedio { get; set; }

    public decimal PorcentajeDescuento { get; set; }

    public decimal? MontoDescontado { get; set; }

    public string Estado { get; set; } = null!;

    public DateTime FechaCalculo { get; set; }

    public virtual Poliza Poliza { get; set; } = null!;
}

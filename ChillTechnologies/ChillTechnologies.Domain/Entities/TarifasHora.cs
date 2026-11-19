using System;
using System.Collections.Generic;

namespace ChillTechnologies.Domain.Entities;

public partial class TarifasHora
{
    public int Id { get; set; }

    public int CargoId { get; set; }

    public int? ProyectoId { get; set; }

    public decimal Tarifa { get; set; }

    public string Moneda { get; set; } = null!;

    public DateOnly VigenteDesde { get; set; }

    public DateOnly? VigenteHasta { get; set; }

    public virtual Cargo Cargo { get; set; } = null!;

    public virtual Proyecto? Proyecto { get; set; }
}

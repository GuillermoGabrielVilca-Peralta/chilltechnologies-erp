using System;
using System.Collections.Generic;

namespace ChillTechnologies.Domain.Entities;

public partial class HitosProyecto
{
    public int Id { get; set; }

    public int ProyectoId { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public DateOnly FechaObjetivo { get; set; }

    public DateOnly? FechaEntrega { get; set; }

    public decimal Monto { get; set; }

    public string Estado { get; set; } = null!;

    public DateTime FechaRegistro { get; set; }

    public virtual Proyecto Proyecto { get; set; } = null!;
}

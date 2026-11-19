using System;
using System.Collections.Generic;

namespace ChillTechnologies.Domain.Entities;

public partial class EquiposProyecto
{
    public int Id { get; set; }

    public int ProyectoId { get; set; }

    public int EmpleadoId { get; set; }

    public string Rol { get; set; } = null!;

    public decimal DedicacionPorcentaje { get; set; }

    public DateOnly FechaIngreso { get; set; }

    public DateOnly? FechaSalida { get; set; }

    public virtual Empleado Empleado { get; set; } = null!;

    public virtual Proyecto Proyecto { get; set; } = null!;
}

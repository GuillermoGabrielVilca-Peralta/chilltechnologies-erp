using System;
using System.Collections.Generic;

namespace ChillTechnologies.Domain.Entities;

public partial class Planilla
{
    public int Id { get; set; }

    public int EmpleadoId { get; set; }

    public int Anio { get; set; }

    public int Mes { get; set; }

    public decimal SueldoBasico { get; set; }

    public decimal Bonificaciones { get; set; }

    public decimal Descuentos { get; set; }

    public decimal NetoPagar { get; set; }

    public string Estado { get; set; } = null!;

    public DateOnly? FechaPago { get; set; }

    public DateTime FechaRegistro { get; set; }

    public virtual Empleado Empleado { get; set; } = null!;
}

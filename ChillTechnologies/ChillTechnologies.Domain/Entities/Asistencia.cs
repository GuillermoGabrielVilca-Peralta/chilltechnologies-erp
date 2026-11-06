using System;
using System.Collections.Generic;

namespace ChillTechnologies.Domain.Entities;

public partial class Asistencia
{
    public int Id { get; set; }

    public int EmpleadoId { get; set; }

    public DateOnly Fecha { get; set; }

    public TimeOnly? HoraEntrada { get; set; }

    public TimeOnly? HoraSalida { get; set; }

    public decimal? HorasTrabajadas { get; set; }

    public string Estado { get; set; } = null!;

    public string? Observacion { get; set; }

    public virtual Empleado Empleado { get; set; } = null!;
}

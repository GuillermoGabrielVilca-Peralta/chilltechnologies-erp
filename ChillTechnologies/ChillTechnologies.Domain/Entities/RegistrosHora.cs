using System;
using System.Collections.Generic;

namespace ChillTechnologies.Domain.Entities;

public partial class RegistrosHora
{
    public int Id { get; set; }

    public int EmpleadoId { get; set; }

    public int ProyectoId { get; set; }

    public int? TareaId { get; set; }

    public DateOnly Fecha { get; set; }

    public decimal Horas { get; set; }

    public string? Descripcion { get; set; }

    public bool Facturable { get; set; }

    public bool Aprobado { get; set; }

    public DateTime FechaRegistro { get; set; }

    public virtual Empleado Empleado { get; set; } = null!;

    public virtual Proyecto Proyecto { get; set; } = null!;

    public virtual Tarea? Tarea { get; set; }
}

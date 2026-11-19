using System;
using System.Collections.Generic;

namespace ChillTechnologies.Domain.Entities;

public partial class Tarea
{
    public int Id { get; set; }

    public int HistoriaId { get; set; }

    public string Titulo { get; set; } = null!;

    public string? Descripcion { get; set; }

    public int? EmpleadoId { get; set; }

    public decimal HorasEstimadas { get; set; }

    public decimal HorasReales { get; set; }

    public string Estado { get; set; } = null!;

    public DateTime FechaRegistro { get; set; }

    public DateTime? FechaCierre { get; set; }

    public virtual Empleado? Empleado { get; set; }

    public virtual HistoriasUsuario Historia { get; set; } = null!;

    public virtual ICollection<RegistrosHora> RegistrosHoras { get; set; } = new List<RegistrosHora>();
}

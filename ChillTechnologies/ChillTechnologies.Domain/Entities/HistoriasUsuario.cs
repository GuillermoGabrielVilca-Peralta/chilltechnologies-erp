using System;
using System.Collections.Generic;

namespace ChillTechnologies.Domain.Entities;

public partial class HistoriasUsuario
{
    public int Id { get; set; }

    public int ProyectoId { get; set; }

    public int? SprintId { get; set; }

    public string Codigo { get; set; } = null!;

    public string Titulo { get; set; } = null!;

    public string? Descripcion { get; set; }

    public string? CriteriosAceptacion { get; set; }

    public int PuntosHistoria { get; set; }

    public string Prioridad { get; set; } = null!;

    public string Estado { get; set; } = null!;

    public DateTime FechaRegistro { get; set; }

    public virtual ICollection<CasosPrueba> CasosPruebas { get; set; } = new List<CasosPrueba>();

    public virtual ICollection<Defecto> Defectos { get; set; } = new List<Defecto>();

    public virtual Proyecto Proyecto { get; set; } = null!;

    public virtual Sprint? Sprint { get; set; }

    public virtual ICollection<Tarea> Tareas { get; set; } = new List<Tarea>();
}

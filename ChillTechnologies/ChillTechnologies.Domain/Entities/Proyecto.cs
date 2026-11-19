using System;
using System.Collections.Generic;

namespace ChillTechnologies.Domain.Entities;

public partial class Proyecto
{
    public int Id { get; set; }

    public string Codigo { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public int TipoProyectoId { get; set; }

    public int? ContratoId { get; set; }

    public int? ProductoSoftwareId { get; set; }

    public int? JefeProyectoId { get; set; }

    public DateOnly FechaInicio { get; set; }

    public DateOnly? FechaFinEstimada { get; set; }

    public DateOnly? FechaFinReal { get; set; }

    public decimal Presupuesto { get; set; }

    public decimal HorasEstimadas { get; set; }

    public decimal AvancePorcentaje { get; set; }

    public string Estado { get; set; } = null!;

    public DateTime FechaRegistro { get; set; }

    public virtual ContratosDesarrollo? Contrato { get; set; }

    public virtual ICollection<Defecto> Defectos { get; set; } = new List<Defecto>();

    public virtual ICollection<EquiposProyecto> EquiposProyectos { get; set; } = new List<EquiposProyecto>();

    public virtual ICollection<HistoriasUsuario> HistoriasUsuarios { get; set; } = new List<HistoriasUsuario>();

    public virtual ICollection<HitosProyecto> HitosProyectos { get; set; } = new List<HitosProyecto>();

    public virtual Empleado? JefeProyecto { get; set; }

    public virtual ProductosSoftware? ProductoSoftware { get; set; }

    public virtual ICollection<RegistrosHora> RegistrosHoras { get; set; } = new List<RegistrosHora>();

    public virtual ICollection<Sprint> Sprints { get; set; } = new List<Sprint>();

    public virtual ICollection<TarifasHora> TarifasHoras { get; set; } = new List<TarifasHora>();

    public virtual TiposProyecto TipoProyecto { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace ChillTechnologies.Domain.Entities;

public partial class Geocerca
{
    public int Id { get; set; }

    /// <summary>
    /// NULL = geocerca global del sistema
    /// </summary>
    public int? EmpresaId { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public decimal Latitud { get; set; }

    public decimal Longitud { get; set; }

    public int RadioMetros { get; set; }

    public string Tipo { get; set; } = null!;

    public string Estado { get; set; } = null!;

    public DateTime FechaRegistro { get; set; }

    public virtual Empresa? Empresa { get; set; }

    public virtual ICollection<Parada> Parada { get; set; } = new List<Parada>();
}

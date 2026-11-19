using System;
using System.Collections.Generic;

namespace ChillTechnologies.Domain.Entities;

public partial class ProductosSoftware
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public string Tipo { get; set; } = null!;

    public DateOnly? FechaLanzamiento { get; set; }

    public string Estado { get; set; } = null!;

    public DateTime FechaRegistro { get; set; }

    public virtual ICollection<Proyecto> Proyectos { get; set; } = new List<Proyecto>();

    public virtual ICollection<Repositorio> Repositorios { get; set; } = new List<Repositorio>();

    public virtual ICollection<TicketsSoporte> TicketsSoportes { get; set; } = new List<TicketsSoporte>();

    public virtual ICollection<VersionesProducto> VersionesProductos { get; set; } = new List<VersionesProducto>();
}

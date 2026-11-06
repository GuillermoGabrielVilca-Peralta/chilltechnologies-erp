using System;
using System.Collections.Generic;

namespace ChillTechnologies.Domain.Entities;

public partial class Almacene
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Direccion { get; set; }

    public int? ResponsableEmpleadoId { get; set; }

    public string Estado { get; set; } = null!;

    public DateTime FechaRegistro { get; set; }

    public virtual ICollection<Inventario> Inventarios { get; set; } = new List<Inventario>();

    public virtual ICollection<MovimientosInventario> MovimientosInventarioAlmacenDestinos { get; set; } = new List<MovimientosInventario>();

    public virtual ICollection<MovimientosInventario> MovimientosInventarioAlmacenOrigens { get; set; } = new List<MovimientosInventario>();

    public virtual ICollection<Recepcione> Recepciones { get; set; } = new List<Recepcione>();

    public virtual Empleado? ResponsableEmpleado { get; set; }
}

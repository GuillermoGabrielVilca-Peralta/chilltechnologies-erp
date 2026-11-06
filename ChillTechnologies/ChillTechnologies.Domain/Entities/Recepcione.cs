using System;
using System.Collections.Generic;

namespace ChillTechnologies.Domain.Entities;

public partial class Recepcione
{
    public int Id { get; set; }

    public int OrdenCompraId { get; set; }

    public int AlmacenId { get; set; }

    public string? NumeroGuia { get; set; }

    public DateOnly FechaRecepcion { get; set; }

    public int? EmpleadoId { get; set; }

    public string Estado { get; set; } = null!;

    public string? Observaciones { get; set; }

    public DateTime FechaRegistro { get; set; }

    public virtual Almacene Almacen { get; set; } = null!;

    public virtual Empleado? Empleado { get; set; }

    public virtual OrdenesCompra OrdenCompra { get; set; } = null!;
}

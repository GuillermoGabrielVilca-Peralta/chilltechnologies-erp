using System;
using System.Collections.Generic;

namespace ChillTechnologies.Domain.Entities;

public partial class Empleado
{
    public int Id { get; set; }

    public string Nombres { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public string Dni { get; set; } = null!;

    public string? Email { get; set; }

    public string? Telefono { get; set; }

    public int AreaId { get; set; }

    public int CargoId { get; set; }

    /// <summary>
    /// Jefe directo, para el organigrama
    /// </summary>
    public int? JefeId { get; set; }

    public DateOnly FechaIngreso { get; set; }

    public DateOnly? FechaCese { get; set; }

    public decimal SueldoBasico { get; set; }

    public string Estado { get; set; } = null!;

    public DateTime FechaRegistro { get; set; }

    public virtual ICollection<Almacene> Almacenes { get; set; } = new List<Almacene>();

    public virtual Area Area { get; set; } = null!;

    public virtual ICollection<AsientosContable> AsientosContables { get; set; } = new List<AsientosContable>();

    public virtual ICollection<Asistencia> Asistencia { get; set; } = new List<Asistencia>();

    public virtual ICollection<Caja> Cajas { get; set; } = new List<Caja>();

    public virtual Cargo Cargo { get; set; } = null!;

    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();

    public virtual ICollection<Cotizacione> Cotizaciones { get; set; } = new List<Cotizacione>();

    public virtual ICollection<Empleado> InverseJefe { get; set; } = new List<Empleado>();

    public virtual Empleado? Jefe { get; set; }

    public virtual ICollection<MovimientosCaja> MovimientosCajas { get; set; } = new List<MovimientosCaja>();

    public virtual ICollection<MovimientosInventario> MovimientosInventarios { get; set; } = new List<MovimientosInventario>();

    public virtual ICollection<OrdenesCompra> OrdenesCompras { get; set; } = new List<OrdenesCompra>();

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();

    public virtual ICollection<Planilla> Planillas { get; set; } = new List<Planilla>();

    public virtual ICollection<Recepcione> Recepciones { get; set; } = new List<Recepcione>();

    public virtual ICollection<SolicitudesAusencium> SolicitudesAusenciumAprobadoPorNavigations { get; set; } = new List<SolicitudesAusencium>();

    public virtual ICollection<SolicitudesAusencium> SolicitudesAusenciumEmpleados { get; set; } = new List<SolicitudesAusencium>();

    public virtual UsuariosSistema? UsuariosSistema { get; set; }
}

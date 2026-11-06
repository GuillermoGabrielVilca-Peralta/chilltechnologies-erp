using System;
using System.Collections.Generic;

namespace ChillTechnologies.Domain.Entities;

/// <summary>
/// Conductores registrados en ChillDrive
/// </summary>
public partial class Usuario
{
    public int Id { get; set; }

    public string Nombres { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string? Telefono { get; set; }

    public string? FotoPerfil { get; set; }

    public int PlanId { get; set; }

    public int TipoConductorId { get; set; }

    public string Estado { get; set; } = null!;

    public DateTime? UltimoAcceso { get; set; }

    public DateTime FechaRegistro { get; set; }

    /// <summary>
    /// NULL = conductor independiente (B2C)
    /// </summary>
    public int? EmpresaId { get; set; }

    public virtual ICollection<AlertasRiesgo> AlertasRiesgos { get; set; } = new List<AlertasRiesgo>();

    public virtual ICollection<AsignacionesVehiculo> AsignacionesVehiculos { get; set; } = new List<AsignacionesVehiculo>();

    public virtual ICollection<Canje> Canjes { get; set; } = new List<Canje>();

    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();

    public virtual Empresa? Empresa { get; set; }

    public virtual ICollection<Evento> Eventos { get; set; } = new List<Evento>();

    public virtual ICollection<MovimientosPunto> MovimientosPuntos { get; set; } = new List<MovimientosPunto>();

    public virtual ICollection<Notificacione> Notificaciones { get; set; } = new List<Notificacione>();

    public virtual Plane Plan { get; set; } = null!;

    public virtual PuntosUsuario? PuntosUsuario { get; set; }

    public virtual ICollection<Suscripcione> Suscripciones { get; set; } = new List<Suscripcione>();

    public virtual TiposConductor TipoConductor { get; set; } = null!;

    public virtual ICollection<Vehiculo> Vehiculos { get; set; } = new List<Vehiculo>();

    public virtual ICollection<Viaje> Viajes { get; set; } = new List<Viaje>();
}

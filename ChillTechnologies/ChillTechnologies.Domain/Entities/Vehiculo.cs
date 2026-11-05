using System;
using System.Collections.Generic;

namespace ChillTechnologies.Domain.Entities;

/// <summary>
/// Vehiculos registrados por cada conductor
/// </summary>
public partial class Vehiculo
{
    public int Id { get; set; }

    public int? UsuarioId { get; set; }

    public string Placa { get; set; } = null!;

    public string? Marca { get; set; }

    public string? Modelo { get; set; }

    public int? Anio { get; set; }

    public string? Color { get; set; }

    public int TipoVehiculoId { get; set; }

    public string Estado { get; set; } = null!;

    public DateTime FechaRegistro { get; set; }

    public int? FlotaId { get; set; }

    public virtual ICollection<AlertasRiesgo> AlertasRiesgos { get; set; } = new List<AlertasRiesgo>();

    public virtual ICollection<AsignacionesVehiculo> AsignacionesVehiculos { get; set; } = new List<AsignacionesVehiculo>();

    public virtual ICollection<Camara> Camaras { get; set; } = new List<Camara>();

    public virtual ICollection<DocumentosVehiculo> DocumentosVehiculos { get; set; } = new List<DocumentosVehiculo>();

    public virtual Flota? Flota { get; set; }

    public virtual ICollection<Mantenimiento> Mantenimientos { get; set; } = new List<Mantenimiento>();

    public virtual ICollection<Poliza> Polizas { get; set; } = new List<Poliza>();

    public virtual TiposVehiculo TipoVehiculo { get; set; } = null!;

    public virtual Usuario? Usuario { get; set; }

    public virtual ICollection<Viaje> Viajes { get; set; } = new List<Viaje>();
}

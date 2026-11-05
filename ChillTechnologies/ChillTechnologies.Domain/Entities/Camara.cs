using System;
using System.Collections.Generic;

namespace ChillTechnologies.Domain.Entities;

/// <summary>
/// Dispositivos de captura de video por vehiculo
/// </summary>
public partial class Camara
{
    public int Id { get; set; }

    public int VehiculoId { get; set; }

    public string? Nombre { get; set; }

    public string? DireccionIp { get; set; }

    public int PosicionId { get; set; }

    public string Estado { get; set; } = null!;

    public DateTime FechaRegistro { get; set; }

    public virtual ICollection<Evento> Eventos { get; set; } = new List<Evento>();

    public virtual PosicionesCamara Posicion { get; set; } = null!;

    public virtual Vehiculo Vehiculo { get; set; } = null!;
}

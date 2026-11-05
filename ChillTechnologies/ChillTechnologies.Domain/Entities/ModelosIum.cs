using System;
using System.Collections.Generic;

namespace ChillTechnologies.Domain.Entities;

public partial class ModelosIum
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Version { get; set; } = null!;

    public string Arquitectura { get; set; } = null!;

    public decimal? PrecisionPromedio { get; set; }

    public DateOnly? FechaEntrenamiento { get; set; }

    public bool Activo { get; set; }

    public DateTime FechaRegistro { get; set; }

    public virtual ICollection<Evento> Eventos { get; set; } = new List<Evento>();

    public virtual ICollection<UmbralesDeteccion> UmbralesDeteccions { get; set; } = new List<UmbralesDeteccion>();
}

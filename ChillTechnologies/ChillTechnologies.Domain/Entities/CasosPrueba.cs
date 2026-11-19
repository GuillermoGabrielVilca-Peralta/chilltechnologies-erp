using System;
using System.Collections.Generic;

namespace ChillTechnologies.Domain.Entities;

public partial class CasosPrueba
{
    public int Id { get; set; }

    public int HistoriaId { get; set; }

    public string Codigo { get; set; } = null!;

    public string Titulo { get; set; } = null!;

    public string? Precondiciones { get; set; }

    public string Pasos { get; set; } = null!;

    public string ResultadoEsperado { get; set; } = null!;

    public string Tipo { get; set; } = null!;

    public bool Automatizado { get; set; }

    public DateTime FechaRegistro { get; set; }

    public virtual ICollection<EjecucionesPrueba> EjecucionesPruebas { get; set; } = new List<EjecucionesPrueba>();

    public virtual HistoriasUsuario Historia { get; set; } = null!;
}

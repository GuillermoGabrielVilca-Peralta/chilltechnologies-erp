using System;
using System.Collections.Generic;

namespace ChillTechnologies.Domain.Entities;

public partial class Canje
{
    public int Id { get; set; }

    public int UsuarioId { get; set; }

    public int PremioId { get; set; }

    public int PuntosUtilizados { get; set; }

    public string CodigoQr { get; set; } = null!;

    public DateTime FechaCanje { get; set; }

    public DateTime? FechaUso { get; set; }

    public string Estado { get; set; } = null!;

    public virtual ICollection<MovimientosPunto> MovimientosPuntos { get; set; } = new List<MovimientosPunto>();

    public virtual Premio Premio { get; set; } = null!;

    public virtual Usuario Usuario { get; set; } = null!;
}

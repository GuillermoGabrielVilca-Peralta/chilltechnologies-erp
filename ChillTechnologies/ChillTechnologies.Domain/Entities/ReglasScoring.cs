using System;
using System.Collections.Generic;

namespace ChillTechnologies.Domain.Entities;

public partial class ReglasScoring
{
    public int Id { get; set; }

    public int? EmpresaId { get; set; }

    public int TipoEventoId { get; set; }

    public int ImpactoPuntaje { get; set; }

    public decimal Peso { get; set; }

    public bool Activa { get; set; }

    public DateTime FechaRegistro { get; set; }

    public virtual Empresa? Empresa { get; set; }

    public virtual TiposEvento TipoEvento { get; set; } = null!;
}

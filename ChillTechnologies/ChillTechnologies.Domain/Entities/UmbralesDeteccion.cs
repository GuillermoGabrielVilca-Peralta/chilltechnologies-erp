using System;
using System.Collections.Generic;

namespace ChillTechnologies.Domain.Entities;

public partial class UmbralesDeteccion
{
    public int Id { get; set; }

    public int ModeloIaId { get; set; }

    public int TipoEventoId { get; set; }

    public decimal ConfianzaMinima { get; set; }

    public virtual ModelosIum ModeloIa { get; set; } = null!;

    public virtual TiposEvento TipoEvento { get; set; } = null!;
}

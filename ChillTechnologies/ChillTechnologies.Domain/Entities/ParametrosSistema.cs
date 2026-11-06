using System;
using System.Collections.Generic;

namespace ChillTechnologies.Domain.Entities;

public partial class ParametrosSistema
{
    public int Id { get; set; }

    public string Clave { get; set; } = null!;

    public string Valor { get; set; } = null!;

    public string? Descripcion { get; set; }

    public string TipoDato { get; set; } = null!;

    public bool Editable { get; set; }
}

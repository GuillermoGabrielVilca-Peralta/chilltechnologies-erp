using System;
using System.Collections.Generic;

namespace ChillTechnologies.Domain.Entities;

public partial class Permiso
{
    public int Id { get; set; }

    /// <summary>
    /// Identificador tecnico, por ejemplo vehiculos.crear
    /// </summary>
    public string Codigo { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string Modulo { get; set; } = null!;

    public virtual ICollection<RolPermiso> RolPermisos { get; set; } = new List<RolPermiso>();
}

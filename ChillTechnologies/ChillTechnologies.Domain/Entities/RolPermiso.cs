using System;
using System.Collections.Generic;

namespace ChillTechnologies.Domain.Entities;

public partial class RolPermiso
{
    public int RolId { get; set; }

    public int PermisoId { get; set; }

    /// <summary>
    /// Momento en que se otorgo el permiso al rol
    /// </summary>
    public DateTime FechaAsignacion { get; set; }

    public virtual Permiso Permiso { get; set; } = null!;

    public virtual RolesSistema Rol { get; set; } = null!;
}

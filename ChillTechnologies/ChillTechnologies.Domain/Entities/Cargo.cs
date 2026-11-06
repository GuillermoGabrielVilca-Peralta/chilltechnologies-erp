using System;
using System.Collections.Generic;

namespace ChillTechnologies.Domain.Entities;

public partial class Cargo
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Nivel { get; set; } = null!;

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
}

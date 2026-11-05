using System;
using System.Collections.Generic;

namespace ChillTechnologies.Domain.Entities;

public partial class TiposVehiculo
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    /// <summary>
    /// Gramos de CO2 por kilometro segun tipo de vehiculo
    /// </summary>
    public decimal FactorEmisionGKm { get; set; }

    public virtual ICollection<Vehiculo> Vehiculos { get; set; } = new List<Vehiculo>();
}

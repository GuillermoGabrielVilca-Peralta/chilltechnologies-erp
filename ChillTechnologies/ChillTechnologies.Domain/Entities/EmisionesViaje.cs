using System;
using System.Collections.Generic;

namespace ChillTechnologies.Domain.Entities;

public partial class EmisionesViaje
{
    public int Id { get; set; }

    public int ViajeId { get; set; }

    public decimal Co2Kg { get; set; }

    public decimal? CombustibleLitros { get; set; }

    /// <summary>
    /// CO2 no emitido gracias a la buena conduccion frente al promedio
    /// </summary>
    public decimal? AhorroEstimadoKg { get; set; }

    public DateTime FechaCalculo { get; set; }

    public virtual Viaje Viaje { get; set; } = null!;
}

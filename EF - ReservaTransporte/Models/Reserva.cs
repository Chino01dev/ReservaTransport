using System;
using System.Collections.Generic;

namespace EF___ReservaTransporte.Models;

public partial class Reserva
{
    public int ReservaId { get; set; }

    public int VehiculoId { get; set; }

    public int ConductorId { get; set; }

    public DateTime FechaHora { get; set; }

    public string UbicacionOrigen { get; set; } = null!;

    public string UbicacionDestino { get; set; } = null!;

    public bool Confirmada { get; set; }
    public string? TransportType { get; set; }

    public virtual Conductor Conductor { get; set; } = null!;

    public virtual Vehiculo Vehiculo { get; set; } = null!;
}

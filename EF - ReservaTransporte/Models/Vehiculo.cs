using System;
using System.Collections.Generic;

namespace EF___ReservaTransporte.Models;

public partial class Vehiculo
{
    public int VehiculoId { get; set; }

    public string Marca { get; set; } = null!;

    public string Modelo { get; set; } = null!;

    public string Placa { get; set; } = null!;

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}

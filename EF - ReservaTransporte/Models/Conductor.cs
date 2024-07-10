using System;
using System.Collections.Generic;

namespace EF___ReservaTransporte.Models;

public partial class Conductor
{
    public int ConductorId { get; set; }

    public string Nombre { get; set; } = null!;

    public string Licencia { get; set; } = null!;

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}

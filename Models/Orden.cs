using System;
using System.Collections.Generic;

namespace Lab04_Osis.Models;

public partial class Orden
{
    public int OrdenId { get; set; }

    public int? ClienteId { get; set; }

    public DateTime? FechaOrden { get; set; }

    public decimal Total { get; set; }

    public virtual Cliente? Cliente { get; set; }

    public virtual ICollection<DetallesOrden> DetallesOrdens { get; set; } = new List<DetallesOrden>();

    public virtual ICollection<Pago> Pagos { get; set; } = new List<Pago>();
}

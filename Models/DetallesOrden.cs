using System;
using System.Collections.Generic;

namespace Lab04_Osis.Models;

public partial class DetallesOrden
{
    public int DetalleId { get; set; }

    public int? OrdenId { get; set; }

    public int? ProductoId { get; set; }

    public int Cantidad { get; set; }

    public decimal Precio { get; set; }

    public virtual Orden? Orden { get; set; }

    public virtual Producto? Producto { get; set; }
}

using System;
using System.Collections.Generic;

namespace Lab04_Osis.Models;

public partial class Cliente
{
    public int ClienteId { get; set; }

    public string Nombre { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public DateTime? FechaCreacion { get; set; }

    public virtual ICollection<Orden> Ordenes { get; set; } = new List<Orden>();
}

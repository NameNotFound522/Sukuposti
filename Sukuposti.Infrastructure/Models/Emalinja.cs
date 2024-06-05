using System;
using System.Collections.Generic;

namespace Sukuposti.Infrastructure.Models;

public partial class Emalinja
{
    public uint Id { get; set; }

    public string? Nimi { get; set; }

    public uint? RotuId { get; set; }

    public virtual ICollection<Hevonen> Hevonens { get; set; } = new List<Hevonen>();
}

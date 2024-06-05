using System;
using System.Collections.Generic;

namespace Sukuposti.Infrastructure.Models;

public partial class HevonenOmistaja
{
    public uint Id { get; set; }

    public uint Spnro { get; set; }

    public string? Omistaja { get; set; }

    public short? Alkupvm { get; set; }

    public short? Loppupvm { get; set; }

    public string? Paikkakunta { get; set; }

    public int Maa { get; set; }

    public virtual Hevonen SpnroNavigation { get; set; } = null!;
}

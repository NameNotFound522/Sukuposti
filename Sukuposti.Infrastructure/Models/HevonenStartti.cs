using System;
using System.Collections.Generic;

namespace Sukuposti.Infrastructure.Models;

public partial class HevonenStartti
{
    public uint Spnro { get; set; }

    public int? Kaikki { get; set; }

    public uint? Eka { get; set; }

    public uint? Toka { get; set; }

    public uint? Kolmas { get; set; }

    public virtual Hevonen SpnroNavigation { get; set; } = null!;
}

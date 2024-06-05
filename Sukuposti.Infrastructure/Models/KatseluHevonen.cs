using System;
using System.Collections.Generic;

namespace Sukuposti.Infrastructure.Models;

public partial class KatseluHevonen
{
    public uint Id { get; set; }

    public uint Spnro { get; set; }

    public DateTime Aika { get; set; }

    public string? Referer { get; set; }

    public virtual Hevonen SpnroNavigation { get; set; } = null!;
}

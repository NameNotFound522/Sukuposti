using System;
using System.Collections.Generic;

namespace Sukuposti.Infrastructure.Models;

public partial class HevonenPalkinto
{
    public uint Id { get; set; }

    public uint Spnro { get; set; }

    public uint Palkinto { get; set; }

    public DateTime? Pvm { get; set; }

    public virtual Hevonen SpnroNavigation { get; set; } = null!;
}

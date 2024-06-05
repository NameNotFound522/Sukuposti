using System;
using System.Collections.Generic;

namespace Sukuposti.Infrastructure.Models;

public partial class HevonenKuva
{
    public uint Spnro { get; set; }

    public uint KuvaId { get; set; }

    public virtual Hevonen SpnroNavigation { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace Sukuposti.Infrastructure.Models;

public partial class HevonenRotuKtk
{
    public uint Spnro { get; set; }

    public uint RotuKtkId { get; set; }

    public virtual Hevonen SpnroNavigation { get; set; } = null!;
}

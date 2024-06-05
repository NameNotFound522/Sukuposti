using System;
using System.Collections.Generic;

namespace Sukuposti.Infrastructure.Models;

public partial class HevonenGeeni
{
    public ulong MyRowId { get; set; }

    public uint Spnro { get; set; }

    public ushort GeeniId { get; set; }

    public virtual Geeni Geeni { get; set; } = null!;

    public virtual Hevonen SpnroNavigation { get; set; } = null!;
}

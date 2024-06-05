using System;
using System.Collections.Generic;

namespace Sukuposti.Infrastructure.Models;

public partial class HevonenReknro
{
    public uint Id { get; set; }

    public uint Spnro { get; set; }

    public string Reknro { get; set; } = null!;

    public virtual Hevonen SpnroNavigation { get; set; } = null!;
}

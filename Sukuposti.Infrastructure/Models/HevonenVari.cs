using System;
using System.Collections.Generic;

namespace Sukuposti.Infrastructure.Models;

public partial class HevonenVari
{
    public uint Id { get; set; }

    public uint Spnro { get; set; }

    public uint Vari { get; set; }

    public short? Vaihtoehto { get; set; }

    public virtual Hevonen SpnroNavigation { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace Sukuposti.Infrastructure.Models;

public partial class HevonenSiirto
{
    public uint Id { get; set; }

    public uint Spnro { get; set; }

    public int Mista { get; set; }

    public int Mihin { get; set; }

    public DateOnly? Vuosi { get; set; }

    public virtual Hevonen SpnroNavigation { get; set; } = null!;
}

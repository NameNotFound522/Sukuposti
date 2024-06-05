using System;
using System.Collections.Generic;

namespace Sukuposti.Infrastructure.Models;

public partial class HevonenMuutum
{
    public uint Spnro { get; set; }

    public string? Teksti { get; set; }

    public virtual Hevonen SpnroNavigation { get; set; } = null!;
}

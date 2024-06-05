using System;
using System.Collections.Generic;

namespace Sukuposti.Infrastructure.Models;

public partial class HevonenNimi
{
    public uint Id { get; set; }

    public uint Spnro { get; set; }

    public string Nimi { get; set; } = null!;

    public string Tyyppi { get; set; } = null!;

    public virtual Hevonen SpnroNavigation { get; set; } = null!;
}

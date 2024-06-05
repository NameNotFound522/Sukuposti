using System;
using System.Collections.Generic;

namespace Sukuposti.Infrastructure.Models;

public partial class HevonenMetum
{
    public uint Spnro { get; set; }

    public DateTime? Lisatty { get; set; }

    public DateTime? Muokattu { get; set; }

    public uint? Lisaaja { get; set; }

    public uint? Muokkaaja { get; set; }

    public string? Kommentti { get; set; }

    public virtual Hevonen SpnroNavigation { get; set; } = null!;
}

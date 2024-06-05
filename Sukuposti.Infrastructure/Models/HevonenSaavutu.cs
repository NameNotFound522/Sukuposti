using System;
using System.Collections.Generic;

namespace Sukuposti.Infrastructure.Models;

public partial class HevonenSaavutu
{
    public uint Id { get; set; }

    public uint Spnro { get; set; }

    public string? Tyyppi { get; set; }

    public uint? Ktk { get; set; }

    public uint? Nayttely { get; set; }

    public DateTime? Pvm { get; set; }

    public virtual Hevonen SpnroNavigation { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace Sukuposti.Infrastructure.Models;

public partial class HevonenEnnaty
{
    public uint Id { get; set; }

    public uint Spnro { get; set; }

    public string? Tyyppi { get; set; }

    public string? Matka { get; set; }

    public decimal? Aika { get; set; }

    public int? Ika { get; set; }

    public bool? Autolahto { get; set; }

    public string? Selitys { get; set; }

    public virtual Hevonen SpnroNavigation { get; set; } = null!;
}

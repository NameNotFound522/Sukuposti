using System;
using System.Collections.Generic;

namespace Sukuposti.Infrastructure.Models;

public partial class HevonenKilpailuvoitto
{
    public ulong MyRowId { get; set; }

    public uint Spnro { get; set; }

    public uint Kisa { get; set; }

    public string? Paikka { get; set; }

    public int? Vuosi { get; set; }

    public int? Sija { get; set; }

    public decimal? Aika { get; set; }

    public int? Matka { get; set; }

    public string? Kuski { get; set; }

    public string? Ennatys { get; set; }

    public int? Voittosumma { get; set; }

    public virtual Hevonen SpnroNavigation { get; set; } = null!;
}

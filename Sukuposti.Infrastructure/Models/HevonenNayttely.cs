using System;
using System.Collections.Generic;

namespace Sukuposti.Infrastructure.Models;

public partial class HevonenNayttely
{
    public uint Id { get; set; }

    public uint? Spnro { get; set; }

    public string? Pisteet { get; set; }

    public decimal? Sakakorkeus { get; set; }

    public decimal? Lautaskorkeus { get; set; }

    public int? Sija { get; set; }

    public int? Luokankoko { get; set; }

    public string? Sekalaiset { get; set; }

    public uint? Tapahtuma { get; set; }
}

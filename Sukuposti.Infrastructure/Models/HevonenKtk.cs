using System;
using System.Collections.Generic;

namespace Sukuposti.Infrastructure.Models;

public partial class HevonenKtk
{
    public uint Id { get; set; }

    public uint Spnro { get; set; }

    public string? Lausunto { get; set; }

    public string? Pisteet { get; set; }

    public uint? Palkinto { get; set; }

    public string? Paikka { get; set; }

    public DateOnly? Pvm { get; set; }

    public decimal? Sakakorkeus { get; set; }

    public decimal? Lautaskorkeus { get; set; }

    public decimal? Rungonpituus { get; set; }

    public decimal? Rungonymparys { get; set; }

    public decimal? Rungonleveys { get; set; }

    public decimal? Etusaarenymparys { get; set; }

    public string? Mitat { get; set; }

    public string? Sekalaiset { get; set; }

    public string? Kuntoluokka { get; set; }

    public uint? Nayttely { get; set; }

    public decimal? Rungonsyvyys { get; set; }

    public decimal? Etusaarenleveys { get; set; }

    public string? Suunta { get; set; }

    public string Tyyppi { get; set; } = null!;

    public virtual Hevonen SpnroNavigation { get; set; } = null!;
}

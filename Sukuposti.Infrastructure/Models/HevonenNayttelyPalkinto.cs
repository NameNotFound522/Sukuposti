using System;
using System.Collections.Generic;

namespace Sukuposti.Infrastructure.Models;

public partial class HevonenNayttelyPalkinto
{
    public uint Id { get; set; }

    public uint HevonenNayttely { get; set; }

    public uint? Palkinto { get; set; }

    public uint? TuomariMaa { get; set; }
}

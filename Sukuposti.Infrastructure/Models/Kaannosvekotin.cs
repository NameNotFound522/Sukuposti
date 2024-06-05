using System;
using System.Collections.Generic;

namespace Sukuposti.Infrastructure.Models;

public partial class Kaannosvekotin
{
    public uint Id { get; set; }

    public string? Kieli { get; set; }

    public string? Lahde { get; set; }

    public string? Kohde { get; set; }
}

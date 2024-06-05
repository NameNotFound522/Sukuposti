using System;
using System.Collections.Generic;

namespace Sukuposti.Infrastructure.Models;

public partial class HevonenVanhaktk
{
    public ulong MyRowId { get; set; }

    public uint Spnro { get; set; }

    public string? Ktkpist { get; set; }

    public string? Ktkpalk { get; set; }

    public string? Ktklaus { get; set; }
}

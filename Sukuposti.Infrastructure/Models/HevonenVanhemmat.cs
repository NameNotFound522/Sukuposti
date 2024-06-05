using System;
using System.Collections.Generic;

namespace Sukuposti.Infrastructure.Models;

public partial class HevonenVanhemmat
{
    public uint Spnro { get; set; }

    public uint? IsanSpnro { get; set; }

    public uint? EmanSpnro { get; set; }

    public float? Ssprosentti { get; set; }

    public virtual Hevonen SpnroNavigation { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace Sukuposti.Infrastructure.Models;

public partial class HevonenSukutiedot
{
    public uint Spnro { get; set; }

    public sbyte? Polvia { get; set; }

    public sbyte? Taysia { get; set; }

    public byte[]? Tulosdata { get; set; }
}

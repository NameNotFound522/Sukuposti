using System;
using System.Collections.Generic;

namespace Sukuposti.Infrastructure.Models;

public partial class Geeni
{
    public ushort Id { get; set; }

    public string? Lyhenne { get; set; }

    public string? Selitys { get; set; }

    public virtual ICollection<HevonenGeeni> HevonenGeenis { get; set; } = new List<HevonenGeeni>();
}

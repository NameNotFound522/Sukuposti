using System;
using System.Collections.Generic;

namespace Sukuposti.Infrastructure.Models;

public partial class GallupVaihtoehto
{
    public uint GallupId { get; set; }

    public uint VaihtoehtoId { get; set; }

    public string? Selitys { get; set; }

    public uint? Valittu { get; set; }

    public virtual Gallup Gallup { get; set; } = null!;
}

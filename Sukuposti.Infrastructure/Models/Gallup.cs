using System;
using System.Collections.Generic;

namespace Sukuposti.Infrastructure.Models;

public partial class Gallup
{
    public uint Id { get; set; }

    public string? Otsikko { get; set; }

    public bool Julkinen { get; set; }

    public DateOnly? Voimassaolo { get; set; }

    public virtual ICollection<GallupVaihtoehto> GallupVaihtoehtos { get; set; } = new List<GallupVaihtoehto>();
}

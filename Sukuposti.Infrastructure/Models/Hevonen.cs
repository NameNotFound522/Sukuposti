using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sukuposti.Infrastructure.Extensions;

namespace Sukuposti.Infrastructure.Models;

public partial class Hevonen
{
    public uint Spnro { get; set; }

    public string? Sukupuoli { get; set; }

    public bool Julkinen { get; set; }

    public uint? Nimi { get; set; }

    public uint? Reknro { get; set; }

    public uint? Rotu { get; set; }

    public uint? RotuArvio { get; set; }

    public decimal? Saka { get; set; }

    public bool? SakaArvio { get; set; }

    public uint? Voittosumma { get; set; }

    public DateOnly? VoittosummaMennessa { get; set; }

    public short? VoittosummaValuutta { get; set; }

    public bool VoittosummaLopullinen { get; set; }

    public DateOnly? Syntaika { get; set; }

    public bool? SyntaikaArvio { get; set; }

    public uint? Syntmaa { get; set; }

    public bool? Kuollut { get; set; }

    public DateOnly? Kuolinaika { get; set; }

    public string? Kuolinsyy { get; set; }

    public string? Merkit { get; set; }

    public string? Kasvattaja { get; set; }

    public string? Omistaja { get; set; }

    public string? Muuta { get; set; }

    public bool EiKilpaillut { get; set; }

    public bool KuolinaikaArvio { get; set; }

    public bool EiKtkKelp { get; set; }

    public uint? EmalinjaId { get; set; }

    public uint? Lisaaja { get; set; }

    public uint? Muokkaaja { get; set; }

    public string? Kommentti { get; set; }

    public DateTime? Lisatty { get; set; }

    public DateTime? Muokattu { get; set; }

    public virtual Emalinja? Emalinja { get; set; }

    public virtual ICollection<HevonenEnnaty> HevonenEnnaties { get; set; } = new List<HevonenEnnaty>();

    public virtual ICollection<HevonenGeeni> HevonenGeenis { get; set; } = new List<HevonenGeeni>();

    public virtual ICollection<HevonenKilpailuvoitto> HevonenKilpailuvoittos { get; set; } = new List<HevonenKilpailuvoitto>();

    public virtual ICollection<HevonenKtk> HevonenKtks { get; set; } = new List<HevonenKtk>();

    public virtual ICollection<HevonenKuva> HevonenKuvas { get; set; } = new List<HevonenKuva>();

    public virtual HevonenMetum? HevonenMetum { get; set; }

    public virtual ICollection<HevonenMuuNayttelytulo> HevonenMuuNayttelytulos { get; set; } = new List<HevonenMuuNayttelytulo>();

    public virtual HevonenMuutum? HevonenMuutum { get; set; }

    public virtual ICollection<HevonenNimi> HevonenNimis { get; set; } = new List<HevonenNimi>();

    public virtual ICollection<HevonenOmistaja> HevonenOmistajas { get; set; } = new List<HevonenOmistaja>();

    public virtual ICollection<HevonenPalkinto> HevonenPalkintos { get; set; } = new List<HevonenPalkinto>();

    public virtual ICollection<HevonenReknro> HevonenReknros { get; set; } = new List<HevonenReknro>();

    public virtual ICollection<HevonenRotuKtk> HevonenRotuKtks { get; set; } = new List<HevonenRotuKtk>();

    public virtual ICollection<HevonenSaavutu> HevonenSaavutus { get; set; } = new List<HevonenSaavutu>();

    public virtual ICollection<HevonenSiirto> HevonenSiirtos { get; set; } = new List<HevonenSiirto>();

    public virtual HevonenStartti? HevonenStartti { get; set; }

    public virtual HevonenVanhemmat? HevonenVanhemmat { get; set; }

    public virtual ICollection<HevonenVari> HevonenVaris { get; set; } = new List<HevonenVari>();

    public virtual ICollection<KatseluHevonen> KatseluHevonens { get; set; } = new List<KatseluHevonen>();
}

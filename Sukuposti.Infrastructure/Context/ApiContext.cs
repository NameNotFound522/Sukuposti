using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Logging;
using MySqlConnector;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;
using Sukuposti.Infrastructure.Extensions;
using Sukuposti.Infrastructure.Models;

namespace Sukuposti.Infrastructure.Context;

public partial class ApiContext : DbContext
{
    public ApiContext()
    {
    }

    public ApiContext(DbContextOptions<ApiContext> options)
        : base(options)
    {
    }
    
    public virtual DbSet<Audit> Audits { get; set; }

    public virtual DbSet<EfmigrationsHistory> EfmigrationsHistories { get; set; }

    public virtual DbSet<Emalinja> Emalinjas { get; set; }

    public virtual DbSet<Gallup> Gallups { get; set; }

    public virtual DbSet<GallupVaihtoehto> GallupVaihtoehtos { get; set; }

    public virtual DbSet<Geeni> Geenis { get; set; }

    public virtual DbSet<Hevonen> Hevonens { get; set; }

    public virtual DbSet<HevonenEnnaty> HevonenEnnatys { get; set; }

    public virtual DbSet<HevonenGeeni> HevonenGeenis { get; set; }

    public virtual DbSet<HevonenKilpailuvoitto> HevonenKilpailuvoittos { get; set; }

    public virtual DbSet<HevonenKtk> HevonenKtks { get; set; }

    public virtual DbSet<HevonenKuva> HevonenKuvas { get; set; }

    public virtual DbSet<HevonenMetum> HevonenMeta { get; set; }

    public virtual DbSet<HevonenMuuNayttelytulo> HevonenMuuNayttelytulos { get; set; }

    public virtual DbSet<HevonenMuutum> HevonenMuuta { get; set; }

    public virtual DbSet<HevonenNayttely> HevonenNayttelies { get; set; }

    public virtual DbSet<HevonenNayttelyPalkinto> HevonenNayttelyPalkintos { get; set; }

    public virtual DbSet<HevonenNimi> HevonenNimis { get; set; }

    public virtual DbSet<HevonenOmistaja> HevonenOmistajas { get; set; }

    public virtual DbSet<HevonenPalkinto> HevonenPalkintos { get; set; }

    public virtual DbSet<HevonenReknro> HevonenReknros { get; set; }

    public virtual DbSet<HevonenRotuKtk> HevonenRotuKtks { get; set; }

    public virtual DbSet<HevonenSaavutu> HevonenSaavutus { get; set; }

    public virtual DbSet<HevonenSiirto> HevonenSiirtos { get; set; }

    public virtual DbSet<HevonenStartti> HevonenStarttis { get; set; }

    public virtual DbSet<HevonenSukutiedot> HevonenSukutiedots { get; set; }

    public virtual DbSet<HevonenVanhaktk> HevonenVanhaktks { get; set; }

    public virtual DbSet<HevonenVanhemmat> HevonenVanhemmats { get; set; }

    public virtual DbSet<HevonenVari> HevonenVaris { get; set; }

    public virtual DbSet<Kaannosvekotin> Kaannosvekotins { get; set; }

    public virtual DbSet<KatseluHevonen> KatseluHevonens { get; set; }

protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");
        

        modelBuilder.Entity<Audit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("audit")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => new { e.TargetClass, e.TargetId }, "target_class");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Changes)
                .HasColumnType("blob")
                .HasColumnName("changes");
            entity.Property(e => e.OperationTime)
                .HasColumnType("datetime")
                .HasColumnName("operation_time");
            entity.Property(e => e.TargetClass)
                .HasMaxLength(50)
                .HasColumnName("target_class");
            entity.Property(e => e.TargetId).HasColumnName("target_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<EfmigrationsHistory>(entity =>
        {
            entity.HasKey(e => e.MigrationId).HasName("PRIMARY");

            entity.ToTable("__EFMigrationsHistory");

            entity.Property(e => e.MigrationId).HasMaxLength(150);
            entity.Property(e => e.ProductVersion).HasMaxLength(32);
        });

        modelBuilder.Entity<Emalinja>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("emalinja")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.RotuId, "rotu_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nimi)
                .HasMaxLength(100)
                .HasColumnName("nimi");
            entity.Property(e => e.RotuId).HasColumnName("rotu_id");
        });

        modelBuilder.Entity<Gallup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("gallup")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Julkinen).HasColumnName("julkinen");
            entity.Property(e => e.Otsikko)
                .HasColumnType("text")
                .HasColumnName("otsikko");
            entity.Property(e => e.Voimassaolo).HasColumnName("voimassaolo");
        });

        modelBuilder.Entity<GallupVaihtoehto>(entity =>
        {
            entity.HasKey(e => new { e.GallupId, e.VaihtoehtoId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity
                .ToTable("gallup_vaihtoehto")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.Property(e => e.GallupId).HasColumnName("gallup_id");
            entity.Property(e => e.VaihtoehtoId).HasColumnName("vaihtoehto_id");
            entity.Property(e => e.Selitys)
                .HasColumnType("text")
                .HasColumnName("selitys");
            entity.Property(e => e.Valittu).HasColumnName("valittu");

            entity.HasOne(d => d.Gallup).WithMany(p => p.GallupVaihtoehtos)
                .HasForeignKey(d => d.GallupId)
                .HasConstraintName("gallup_vaihtoehto_ibfk_1");
        });

        modelBuilder.Entity<Geeni>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("geeni")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Lyhenne)
                .HasMaxLength(30)
                .HasColumnName("lyhenne");
            entity.Property(e => e.Selitys)
                .HasMaxLength(200)
                .HasColumnName("selitys");
        });

        modelBuilder.Entity<Hevonen>(entity =>
        {
            entity.HasKey(e => e.Spnro).HasName("PRIMARY");

            entity
                .ToTable("hevonen")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_unicode_ci");

            entity.HasIndex(e => e.EmalinjaId, "emalinja_id");

            entity.HasIndex(e => e.Julkinen, "julkinen");

            entity.HasIndex(e => e.Nimi, "nimi");

            entity.HasIndex(e => e.Reknro, "reknro");

            entity.HasIndex(e => e.Rotu, "rotu");

            entity.HasIndex(e => e.Saka, "saka");

            entity.HasIndex(e => e.Sukupuoli, "sukupuoli");

            entity.HasIndex(e => e.Syntaika, "syntaika");

            entity.HasIndex(e => e.Syntmaa, "syntmaa");

            entity.HasIndex(e => e.Voittosumma, "voittosumma");

            entity.HasIndex(e => e.VoittosummaValuutta, "voittosumma_valuutta");

            entity.Property(e => e.Spnro).HasColumnName("spnro");
            entity.Property(e => e.EiKilpaillut).HasColumnName("ei_kilpaillut");
            entity.Property(e => e.EiKtkKelp).HasColumnName("ei_ktk_kelp");
            entity.Property(e => e.EmalinjaId).HasColumnName("emalinja_id");
            entity.Property(e => e.Julkinen).HasColumnName("julkinen");
            entity.Property(e => e.Kasvattaja)
                .HasMaxLength(255)
                .HasColumnName("kasvattaja");
            entity.Property(e => e.Kommentti)
                .HasColumnType("text")
                .HasColumnName("kommentti");
            entity.Property(e => e.Kuolinaika).HasColumnName("kuolinaika");
            entity.Property(e => e.KuolinaikaArvio).HasColumnName("kuolinaika_arvio");
            entity.Property(e => e.Kuolinsyy)
                .HasMaxLength(255)
                .HasColumnName("kuolinsyy");
            entity.Property(e => e.Kuollut).HasColumnName("kuollut");
            entity.Property(e => e.Lisaaja).HasColumnName("lisaaja");
            entity.Property(e => e.Lisatty)
                .HasColumnType("datetime")
                .HasColumnName("lisatty");
            entity.Property(e => e.Merkit)
                .HasMaxLength(255)
                .HasColumnName("merkit");
            entity.Property(e => e.Muokattu)
                .HasColumnType("datetime")
                .HasColumnName("muokattu");
            entity.Property(e => e.Muokkaaja).HasColumnName("muokkaaja");
            entity.Property(e => e.Muuta)
                .HasColumnType("text")
                .HasColumnName("muuta");
            entity.Property(e => e.Nimi).HasColumnName("nimi");
            entity.Property(e => e.Omistaja)
                .HasMaxLength(255)
                .HasColumnName("omistaja");
            entity.Property(e => e.Reknro).HasColumnName("reknro");
            entity.Property(e => e.Rotu).HasColumnName("rotu");
            entity.Property(e => e.RotuArvio).HasColumnName("rotu_arvio");
            entity.Property(e => e.Saka)
                .HasPrecision(4, 1)
                .HasColumnName("saka");
            entity.Property(e => e.SakaArvio).HasColumnName("saka_arvio");
            entity.Property(e => e.Sukupuoli)
                .HasColumnType("enum('ori','tamma','ruuna')")
                .HasColumnName("sukupuoli");
            entity.Property(e => e.Syntaika).HasColumnName("syntaika");
            entity.Property(e => e.SyntaikaArvio).HasColumnName("syntaika_arvio");
            entity.Property(e => e.Syntmaa).HasColumnName("syntmaa");
            entity.Property(e => e.Voittosumma).HasColumnName("voittosumma");
            entity.Property(e => e.VoittosummaLopullinen).HasColumnName("voittosumma_lopullinen");
            entity.Property(e => e.VoittosummaMennessa).HasColumnName("voittosumma_mennessa");
            entity.Property(e => e.VoittosummaValuutta).HasColumnName("voittosumma_valuutta");

            entity.HasOne(d => d.Emalinja).WithMany(p => p.Hevonens)
                .HasForeignKey(d => d.EmalinjaId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("hevonen_ibfk_3");
        });

        modelBuilder.Entity<HevonenEnnaty>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("hevonen_ennatys")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_unicode_ci");

            entity.HasIndex(e => e.Aika, "aika");

            entity.HasIndex(e => e.Spnro, "spnro");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Aika)
                .HasPrecision(4, 1)
                .HasColumnName("aika");
            entity.Property(e => e.Autolahto).HasColumnName("autolahto");
            entity.Property(e => e.Ika).HasColumnName("ika");
            entity.Property(e => e.Matka)
                .HasDefaultValueSql("'tuntematon'")
                .HasColumnType("enum('tuntematon','ly','ke','kp','pi')")
                .HasColumnName("matka");
            entity.Property(e => e.Selitys)
                .HasMaxLength(255)
                .HasColumnName("selitys");
            entity.Property(e => e.Spnro).HasColumnName("spnro");
            entity.Property(e => e.Tyyppi)
                .HasDefaultValueSql("'normaali'")
                .HasColumnType("enum('normaali','tt','p','m','kl','epavirallinen','muu','voittoaika','opetuslahto')")
                .HasColumnName("tyyppi");

            entity.HasOne(d => d.SpnroNavigation).WithMany(p => p.HevonenEnnaties)
                .HasForeignKey(d => d.Spnro)
                .HasConstraintName("hevonen_ennatys_ibfk_3");
        });

        modelBuilder.Entity<HevonenGeeni>(entity =>
        {
            entity.HasKey(e => e.MyRowId).HasName("PRIMARY");

            entity
                .ToTable("hevonen_geeni")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.GeeniId, "geeni_id");

            entity.HasIndex(e => e.Spnro, "spnro");

            entity.Property(e => e.MyRowId).HasColumnName("my_row_id");
            entity.Property(e => e.GeeniId).HasColumnName("geeni_id");
            entity.Property(e => e.Spnro).HasColumnName("spnro");

            entity.HasOne(d => d.Geeni).WithMany(p => p.HevonenGeenis)
                .HasForeignKey(d => d.GeeniId)
                .HasConstraintName("hevonen_geeni_ibfk_2");

            entity.HasOne(d => d.SpnroNavigation).WithMany(p => p.HevonenGeenis)
                .HasForeignKey(d => d.Spnro)
                .HasConstraintName("hevonen_geeni_ibfk_1");
        });

        modelBuilder.Entity<HevonenKilpailuvoitto>(entity =>
        {
            entity.HasKey(e => e.MyRowId).HasName("PRIMARY");

            entity
                .ToTable("hevonen_kilpailuvoitto")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_unicode_ci");

            entity.HasIndex(e => e.Kisa, "kisa");

            entity.HasIndex(e => e.Spnro, "spnro");

            entity.Property(e => e.MyRowId).HasColumnName("my_row_id");
            entity.Property(e => e.Aika)
                .HasPrecision(3, 1)
                .HasColumnName("aika");
            entity.Property(e => e.Ennatys)
                .HasColumnType("enum('SE','EE','ME')")
                .HasColumnName("ennatys");
            entity.Property(e => e.Kisa).HasColumnName("kisa");
            entity.Property(e => e.Kuski)
                .HasMaxLength(255)
                .HasColumnName("kuski");
            entity.Property(e => e.Matka).HasColumnName("matka");
            entity.Property(e => e.Paikka)
                .HasMaxLength(255)
                .HasColumnName("paikka");
            entity.Property(e => e.Sija).HasColumnName("sija");
            entity.Property(e => e.Spnro).HasColumnName("spnro");
            entity.Property(e => e.Voittosumma).HasColumnName("voittosumma");
            entity.Property(e => e.Vuosi).HasColumnName("vuosi");

            entity.HasOne(d => d.SpnroNavigation).WithMany(p => p.HevonenKilpailuvoittos)
                .HasForeignKey(d => d.Spnro)
                .HasConstraintName("hevonen_kilpailuvoitto_ibfk_1");
        });

        modelBuilder.Entity<HevonenKtk>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("hevonen_ktk")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_unicode_ci");

            entity.HasIndex(e => e.Nayttely, "nayttely");

            entity.HasIndex(e => e.Pvm, "pvm");

            entity.HasIndex(e => e.Spnro, "spnro");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Etusaarenleveys)
                .HasPrecision(3, 1)
                .HasColumnName("etusaarenleveys");
            entity.Property(e => e.Etusaarenymparys)
                .HasPrecision(5, 2)
                .HasColumnName("etusaarenymparys");
            entity.Property(e => e.Kuntoluokka)
                .HasMaxLength(2)
                .HasColumnName("kuntoluokka");
            entity.Property(e => e.Lausunto)
                .HasColumnType("text")
                .HasColumnName("lausunto");
            entity.Property(e => e.Lautaskorkeus)
                .HasPrecision(5, 2)
                .HasColumnName("lautaskorkeus");
            entity.Property(e => e.Mitat)
                .HasMaxLength(255)
                .HasColumnName("mitat");
            entity.Property(e => e.Nayttely).HasColumnName("nayttely");
            entity.Property(e => e.Paikka)
                .HasMaxLength(255)
                .HasColumnName("paikka");
            entity.Property(e => e.Palkinto).HasColumnName("palkinto");
            entity.Property(e => e.Pisteet)
                .HasMaxLength(255)
                .HasColumnName("pisteet");
            entity.Property(e => e.Pvm).HasColumnName("pvm");
            entity.Property(e => e.Rungonleveys)
                .HasPrecision(5, 2)
                .HasColumnName("rungonleveys");
            entity.Property(e => e.Rungonpituus)
                .HasPrecision(5, 2)
                .HasColumnName("rungonpituus");
            entity.Property(e => e.Rungonsyvyys)
                .HasPrecision(4, 1)
                .HasColumnName("rungonsyvyys");
            entity.Property(e => e.Rungonymparys)
                .HasPrecision(5, 2)
                .HasColumnName("rungonymparys");
            entity.Property(e => e.Sakakorkeus)
                .HasPrecision(5, 2)
                .HasColumnName("sakakorkeus");
            entity.Property(e => e.Sekalaiset)
                .HasColumnType("text")
                .HasColumnName("sekalaiset");
            entity.Property(e => e.Spnro).HasColumnName("spnro");
            entity.Property(e => e.Suunta)
                .HasMaxLength(2)
                .HasColumnName("suunta");
            entity.Property(e => e.Tyyppi)
                .HasDefaultValueSql("'ktk'")
                .HasColumnType("enum('ktk','2tark','3tark','uusinta','esi')")
                .HasColumnName("tyyppi");

            entity.HasOne(d => d.SpnroNavigation).WithMany(p => p.HevonenKtks)
                .HasForeignKey(d => d.Spnro)
                .HasConstraintName("hevonen_ktk_ibfk_1");
        });

        modelBuilder.Entity<HevonenKuva>(entity =>
        {
            entity.HasKey(e => new { e.Spnro, e.KuvaId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity
                .ToTable("hevonen_kuva")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.KuvaId, "kuva_id");

            entity.Property(e => e.Spnro).HasColumnName("spnro");
            entity.Property(e => e.KuvaId).HasColumnName("kuva_id");

            entity.HasOne(d => d.SpnroNavigation).WithMany(p => p.HevonenKuvas)
                .HasForeignKey(d => d.Spnro)
                .HasConstraintName("hevonen_kuva_ibfk_1");
        });

        modelBuilder.Entity<HevonenMetum>(entity =>
        {
            entity.HasKey(e => e.Spnro).HasName("PRIMARY");

            entity
                .ToTable("hevonen_meta")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_unicode_ci");

            entity.HasIndex(e => e.Lisaaja, "lisaaja");

            entity.HasIndex(e => e.Muokkaaja, "muokkaaja");

            entity.HasIndex(e => e.Spnro, "spnro");

            entity.Property(e => e.Spnro)
                .ValueGeneratedNever()
                .HasColumnName("spnro");
            entity.Property(e => e.Kommentti)
                .HasColumnType("text")
                .HasColumnName("kommentti");
            entity.Property(e => e.Lisaaja).HasColumnName("lisaaja");
            entity.Property(e => e.Lisatty)
                .HasColumnType("datetime")
                .HasColumnName("lisatty");
            entity.Property(e => e.Muokattu)
                .HasColumnType("datetime")
                .HasColumnName("muokattu");
            entity.Property(e => e.Muokkaaja).HasColumnName("muokkaaja");

            entity.HasOne(d => d.SpnroNavigation).WithOne(p => p.HevonenMetum)
                .HasForeignKey<HevonenMetum>(d => d.Spnro)
                .HasConstraintName("hevonen_meta_ibfk_1");
        });

        modelBuilder.Entity<HevonenMuuNayttelytulo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("hevonen_muu_nayttelytulos")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_unicode_ci");

            entity.HasIndex(e => e.Spnro, "spnro");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Spnro).HasColumnName("spnro");
            entity.Property(e => e.Teksti)
                .HasMaxLength(255)
                .HasColumnName("teksti");

            entity.HasOne(d => d.SpnroNavigation).WithMany(p => p.HevonenMuuNayttelytulos)
                .HasForeignKey(d => d.Spnro)
                .HasConstraintName("hevonen_muu_nayttelytulos_ibfk_1");
        });

        modelBuilder.Entity<HevonenMuutum>(entity =>
        {
            entity.HasKey(e => e.Spnro).HasName("PRIMARY");

            entity
                .ToTable("hevonen_muuta")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_unicode_ci");

            entity.Property(e => e.Spnro)
                .ValueGeneratedNever()
                .HasColumnName("spnro");
            entity.Property(e => e.Teksti)
                .HasColumnType("text")
                .HasColumnName("teksti")
                .UseCollation("latin1_swedish_ci")
                .HasCharSet("latin1");

            entity.HasOne(d => d.SpnroNavigation).WithOne(p => p.HevonenMuutum)
                .HasForeignKey<HevonenMuutum>(d => d.Spnro)
                .HasConstraintName("hevonen_muuta_ibfk_1");
        });

        modelBuilder.Entity<HevonenNayttely>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("hevonen_nayttely")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_unicode_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Lautaskorkeus)
                .HasPrecision(4, 1)
                .HasColumnName("lautaskorkeus");
            entity.Property(e => e.Luokankoko).HasColumnName("luokankoko");
            entity.Property(e => e.Pisteet)
                .HasMaxLength(255)
                .HasColumnName("pisteet");
            entity.Property(e => e.Sakakorkeus)
                .HasPrecision(4, 1)
                .HasColumnName("sakakorkeus");
            entity.Property(e => e.Sekalaiset)
                .HasColumnType("text")
                .HasColumnName("sekalaiset");
            entity.Property(e => e.Sija).HasColumnName("sija");
            entity.Property(e => e.Spnro).HasColumnName("spnro");
            entity.Property(e => e.Tapahtuma).HasColumnName("tapahtuma");
        });

        modelBuilder.Entity<HevonenNayttelyPalkinto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("hevonen_nayttely_palkinto")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_unicode_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.HevonenNayttely).HasColumnName("hevonen_nayttely");
            entity.Property(e => e.Palkinto).HasColumnName("palkinto");
            entity.Property(e => e.TuomariMaa).HasColumnName("tuomari_maa");
        });

        modelBuilder.Entity<HevonenNimi>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("hevonen_nimi")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_unicode_ci");

            entity.HasIndex(e => e.Nimi, "nimi");

            entity.HasIndex(e => e.Spnro, "spnro");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nimi)
                .HasMaxLength(100)
                .HasColumnName("nimi");
            entity.Property(e => e.Spnro).HasColumnName("spnro");
            entity.Property(e => e.Tyyppi)
                .HasDefaultValueSql("'normaali'")
                .HasColumnType("enum('normaali','kilpailunimi','alias','ex-nimi')")
                .HasColumnName("tyyppi");

            entity.HasOne(d => d.SpnroNavigation).WithMany(p => p.HevonenNimis)
                .HasForeignKey(d => d.Spnro)
                .HasConstraintName("hevonen_nimi_ibfk_1");
        });

        modelBuilder.Entity<HevonenOmistaja>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("hevonen_omistaja")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.Maa, "maa");

            entity.HasIndex(e => e.Spnro, "spnro");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Alkupvm).HasColumnName("alkupvm");
            entity.Property(e => e.Loppupvm).HasColumnName("loppupvm");
            entity.Property(e => e.Maa).HasColumnName("maa");
            entity.Property(e => e.Omistaja)
                .HasMaxLength(255)
                .HasColumnName("omistaja");
            entity.Property(e => e.Paikkakunta)
                .HasColumnType("tinytext")
                .HasColumnName("paikkakunta");
            entity.Property(e => e.Spnro).HasColumnName("spnro");

            entity.HasOne(d => d.SpnroNavigation).WithMany(p => p.HevonenOmistajas)
                .HasForeignKey(d => d.Spnro)
                .HasConstraintName("hevonen_omistaja_ibfk_1");
        });

        modelBuilder.Entity<HevonenPalkinto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("hevonen_palkinto")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.Palkinto, "palkinto");

            entity.HasIndex(e => e.Spnro, "spnro");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Palkinto).HasColumnName("palkinto");
            entity.Property(e => e.Pvm)
                .HasColumnType("datetime")
                .HasColumnName("pvm");
            entity.Property(e => e.Spnro).HasColumnName("spnro");

            entity.HasOne(d => d.SpnroNavigation).WithMany(p => p.HevonenPalkintos)
                .HasForeignKey(d => d.Spnro)
                .HasConstraintName("hevonen_palkinto_ibfk_1");
        });

        modelBuilder.Entity<HevonenReknro>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("hevonen_reknro")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_unicode_ci");

            entity.HasIndex(e => e.Reknro, "reknro");

            entity.HasIndex(e => e.Spnro, "spnro");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Reknro)
                .HasMaxLength(50)
                .HasColumnName("reknro");
            entity.Property(e => e.Spnro).HasColumnName("spnro");

            entity.HasOne(d => d.SpnroNavigation).WithMany(p => p.HevonenReknros)
                .HasForeignKey(d => d.Spnro)
                .HasConstraintName("hevonen_reknro_ibfk_1");
        });

        modelBuilder.Entity<HevonenRotuKtk>(entity =>
        {
            entity.HasKey(e => new { e.Spnro, e.RotuKtkId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity
                .ToTable("hevonen_rotu_ktk")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.RotuKtkId, "rotu_ktk_id");

            entity.Property(e => e.Spnro).HasColumnName("spnro");
            entity.Property(e => e.RotuKtkId).HasColumnName("rotu_ktk_id");

            entity.HasOne(d => d.SpnroNavigation).WithMany(p => p.HevonenRotuKtks)
                .HasForeignKey(d => d.Spnro)
                .HasConstraintName("hevonen_rotu_ktk_ibfk_1");
        });

        modelBuilder.Entity<HevonenSaavutu>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("hevonen_saavutus")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_unicode_ci");

            entity.HasIndex(e => e.Spnro, "spnro");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Ktk).HasColumnName("ktk");
            entity.Property(e => e.Nayttely).HasColumnName("nayttely");
            entity.Property(e => e.Pvm)
                .HasColumnType("datetime")
                .HasColumnName("pvm");
            entity.Property(e => e.Spnro).HasColumnName("spnro");
            entity.Property(e => e.Tyyppi)
                .HasColumnType("enum('ktk','korotus','uusintatarkastus','nayttely')")
                .HasColumnName("tyyppi");

            entity.HasOne(d => d.SpnroNavigation).WithMany(p => p.HevonenSaavutus)
                .HasForeignKey(d => d.Spnro)
                .HasConstraintName("hevonen_saavutus_ibfk_1");
        });

        modelBuilder.Entity<HevonenSiirto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("hevonen_siirto")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_unicode_ci");

            entity.HasIndex(e => e.Spnro, "spnro");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Mihin).HasColumnName("mihin");
            entity.Property(e => e.Mista).HasColumnName("mista");
            entity.Property(e => e.Spnro).HasColumnName("spnro");
            entity.Property(e => e.Vuosi).HasColumnName("vuosi");

            entity.HasOne(d => d.SpnroNavigation).WithMany(p => p.HevonenSiirtos)
                .HasForeignKey(d => d.Spnro)
                .HasConstraintName("hevonen_siirto_ibfk_1");
        });

        modelBuilder.Entity<HevonenStartti>(entity =>
        {
            entity.HasKey(e => e.Spnro).HasName("PRIMARY");

            entity
                .ToTable("hevonen_startti")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_unicode_ci");

            entity.Property(e => e.Spnro)
                .ValueGeneratedNever()
                .HasColumnName("spnro");
            entity.Property(e => e.Eka).HasColumnName("eka");
            entity.Property(e => e.Kaikki).HasColumnName("kaikki");
            entity.Property(e => e.Kolmas).HasColumnName("kolmas");
            entity.Property(e => e.Toka).HasColumnName("toka");

            entity.HasOne(d => d.SpnroNavigation).WithOne(p => p.HevonenStartti)
                .HasForeignKey<HevonenStartti>(d => d.Spnro)
                .HasConstraintName("hevonen_startti_ibfk_1");
        });

        modelBuilder.Entity<HevonenSukutiedot>(entity =>
        {
            entity.HasKey(e => e.Spnro).HasName("PRIMARY");

            entity
                .ToTable("hevonen_sukutiedot")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.Property(e => e.Spnro)
                .ValueGeneratedNever()
                .HasColumnName("spnro");
            entity.Property(e => e.Polvia).HasColumnName("polvia");
            entity.Property(e => e.Taysia).HasColumnName("taysia");
            entity.Property(e => e.Tulosdata)
                .HasColumnType("blob")
                .HasColumnName("tulosdata");
        });

        modelBuilder.Entity<HevonenVanhaktk>(entity =>
        {
            entity.HasKey(e => e.MyRowId).HasName("PRIMARY");

            entity
                .ToTable("hevonen_vanhaktk")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.Property(e => e.MyRowId).HasColumnName("my_row_id");
            entity.Property(e => e.Ktklaus)
                .HasColumnType("text")
                .HasColumnName("ktklaus");
            entity.Property(e => e.Ktkpalk)
                .HasColumnType("text")
                .HasColumnName("ktkpalk");
            entity.Property(e => e.Ktkpist)
                .HasColumnType("text")
                .HasColumnName("ktkpist");
            entity.Property(e => e.Spnro).HasColumnName("spnro");
        });

        modelBuilder.Entity<HevonenVanhemmat>(entity =>
        {
            entity.HasKey(e => e.Spnro).HasName("PRIMARY");

            entity
                .ToTable("hevonen_vanhemmat")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_unicode_ci");

            entity.HasIndex(e => e.EmanSpnro, "eman_spnro");

            entity.HasIndex(e => e.IsanSpnro, "isan_spnro");

            entity.Property(e => e.Spnro)
                .ValueGeneratedNever()
                .HasColumnName("spnro");
            entity.Property(e => e.EmanSpnro).HasColumnName("eman_spnro");
            entity.Property(e => e.IsanSpnro).HasColumnName("isan_spnro");
            entity.Property(e => e.Ssprosentti).HasColumnName("ssprosentti");

            entity.HasOne(d => d.SpnroNavigation).WithOne(p => p.HevonenVanhemmat)
                .HasForeignKey<HevonenVanhemmat>(d => d.Spnro)
                .HasConstraintName("hevonen_vanhemmat_ibfk_1");
        });

        modelBuilder.Entity<HevonenVari>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("hevonen_vari")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_unicode_ci");

            entity.HasIndex(e => e.Spnro, "spnro");

            entity.HasIndex(e => e.Vari, "vari");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Spnro).HasColumnName("spnro");
            entity.Property(e => e.Vaihtoehto).HasColumnName("vaihtoehto");
            entity.Property(e => e.Vari).HasColumnName("vari");

            entity.HasOne(d => d.SpnroNavigation).WithMany(p => p.HevonenVaris)
                .HasForeignKey(d => d.Spnro)
                .HasConstraintName("hevonen_vari_ibfk_1");
        });

        modelBuilder.Entity<Kaannosvekotin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("kaannosvekotin")
                .HasCharSet("latin1")
                .UseCollation("latin1_swedish_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Kieli)
                .HasMaxLength(2)
                .HasColumnName("kieli");
            entity.Property(e => e.Kohde)
                .HasColumnType("text")
                .HasColumnName("kohde");
            entity.Property(e => e.Lahde)
                .HasColumnType("text")
                .HasColumnName("lahde");
        });

        modelBuilder.Entity<KatseluHevonen>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("katselu_hevonen")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.Spnro, "spnro");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Aika)
                .HasColumnType("datetime")
                .HasColumnName("aika");
            entity.Property(e => e.Referer)
                .HasMaxLength(255)
                .HasColumnName("referer");
            entity.Property(e => e.Spnro).HasColumnName("spnro");

            entity.HasOne(d => d.SpnroNavigation).WithMany(p => p.KatseluHevonens)
                .HasForeignKey(d => d.Spnro)
                .HasConstraintName("katselu_hevonen_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    
}

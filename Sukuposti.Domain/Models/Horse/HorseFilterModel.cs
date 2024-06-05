namespace Sukuposti.Infrastructure;

public class HorseFilterModel
{
    //Breed
    public uint? Rotu { get; set; }

    //Sexual
    public string? Sukupuoli { get; set; }
    
    //maternial line
    public uint? EmalinjaId { get; set; }
    
    
    //Breed ancestors  RotuKtk
    public uint? Kantakarja { get; set; }
    
    //Color  merkit
    public string? Vari { get; set; }
    
    //Name
    public string? Nimi { get; set; }
    
    //Reknro registration number
    public string? Rekisterinumero { get; set; }
    
    //Country of birth 
    public uint? Syntymamaa { get; set; }
    
    
    //Date of birth / syntaika
    public DateOnly? Syntymaaika { get; set; }
    
    // the highest part of horse back / saka
    public decimal? Sakakorkeus { get; set; }

    //money prize / voitosumma
    public string? VoittosummaVahintaan { get; set; }
    
    //record best perfomance
    public string? Ennatys { get; set; }

    //text input search
    public string? kantakarja { get; set; }
    
    public DateOnly? YearOfKantakarja { get; set; }
    
    //palkinto
    public string? Kantakirjausluokka { get; set; }
    
    
    //naytelytylous
    public string? Jälkeläiset { get; set; }
    
    public bool? WithImages { get; set; }





}
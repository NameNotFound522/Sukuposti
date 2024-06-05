namespace Sukuposti.Domain.Entities;

public class Horse
{
    public string Breed { get; set; }
    public string MaternalLine { get; set; }
    public string Kantakirja { get; set; }
    public string Gender { get; set; }
    public string Colour { get; set; }
    public string HorseName { get; set; }
    public string RegistrationNumber { get; set; }
    public string CountryOfBirth { get; set; }
    public DateTime? FoalingDate { get; set; }
    public double? WitherHeight { get; set; }
    public decimal? Winnings { get; set; }
    public string Record { get; set; }
    public DateTime? BreedRegistryYear { get; set; }
    public string BreedRegistryClass { get; set; }
    public string OffspringRating { get; set; }
    public bool HasImage { get; set; }
}
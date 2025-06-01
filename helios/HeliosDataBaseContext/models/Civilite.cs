namespace Helios.Context.Models
{
    public class Civilite : ModelBase
    {
        public required Civilites Code { get; set; }
        public string? Description { get; set; }
    }
    public enum Civilites
    {
        Monsieur = 100,
        Madame = 200,
    }
}

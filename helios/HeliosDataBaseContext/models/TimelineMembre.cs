namespace Helios.Context.Models
{
    public class TimelineMembre : ModelBase
    {
        public required Membre Membre { get; set; }
        public required DateTime Date { get; set; }
        public required TimelineMembreType Type { get; set; }
        public string? Commentaires { get; set; }
    }


}

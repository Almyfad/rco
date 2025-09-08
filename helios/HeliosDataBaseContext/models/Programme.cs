namespace Helios.Context.Models
{
    public class Programme : ModelBase
    {
        public required string Libelle { get; set; }
        public string? Description { get; set; }
        public string? couleur { get; set; }
        public virtual ICollection<Centre>? Centres { get; set; }
        public virtual ICollection<TypeMembre>? Aspects { get; set; }
        public virtual ICollection<Activitee>? Activitees { get; set; }
    }
}

namespace Helios.Context.Models
{
    public class Activitee : ModelBase
    {
        public required string Libelle { get; set; }
        public required DateTime DateDebut { get; set; }
        public required DateTime DateFin { get; set; }
        public string? Description { get; set; }
        public Boolean Public { get; set; } = false;
        public Boolean IsAllday { get; set; } = false;
        public required virtual TypeActivitee TypeActivitee { get; set; }
        public  virtual Centre? Centre { get; set; }
        public  virtual Programme? Programme { get; set; }
        public virtual ICollection<TypeMembre>? Aspects { get; set; }
        public virtual ICollection<Inscription>? Inscriptions { get; set; }

    }
}

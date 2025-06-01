namespace Helios.Context.Models
{
    public class Centre : ModelBase,  IEquatable<Centre>
    {
        public required string Code { get; set; }
        public virtual required TypeCentre TypeCentre { get; set; }
        public required string Libelle { get; set; }
        public string? Description { get; set; }
        public string? Adresse { get; set; }
        public string? CodePostal { get; set; }
        public string? Ville { get; set; }
        public string? Pays { get; set; }
        public int? Capacite { get; set; }
        public long? brevoFolderId { get; set; }
        public virtual ICollection<Membre>? Membres { get; set; }      
        public virtual ICollection<Activitee>? Activites { get; set; }
        public virtual ICollection<MailingList>? MailingLists { get; set; }

        public bool Equals(Centre? other)
        {
            return this.Code == other?.Code;
        }



    }

    public class CentreEqualityComparer : IEqualityComparer<Centre>
    {
        public bool Equals(Centre? x, Centre? y)
        {
            return x?.Id == y?.Id;
        }

        public int GetHashCode(Centre obj)
        {
            return obj.Id;
        }
    }
}

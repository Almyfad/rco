namespace Helios.Context.Models
{
    public class MailingList : ModelBase
    {
        public required string Libelle { get; set; }
        public required Centre Centre { get; set; }
        public long? brevoListId { get; set; }
        public virtual ICollection<Membre>? Membres { get; set; }

    }
}

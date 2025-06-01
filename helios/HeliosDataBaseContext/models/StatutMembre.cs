using System.ComponentModel;

namespace Helios.Context.Models
{
    public class StatutMembre : ModelEnumBase<StatutsMembres>
    {
        public virtual ICollection<Membre>? Membres { get; set; }
    }

    public enum StatutsMembres
    {
        [Description("Présent")]
        Present = 100,
        [Description("Suivi")]
        Suivi = 200,
        [Description("Absent")]
        Absent = 300,
        [Description("Démissionnaire")]
        Demissionnaire = 400,
        [Description("Décédé")]
        Decede = 500,

    }
}

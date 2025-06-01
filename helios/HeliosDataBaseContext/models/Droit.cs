using System.ComponentModel;

namespace Helios.Context.Models
{
    public partial class Droit : ModelEnumBase<Droits>
    {
        public virtual Utilisateur? utilisateur { get; set; }
        public virtual Centre? Centre { get; set; }
        public required virtual Module Module { get; set; }
    }

    public enum Droits
    {
        [Description("Public")]
        PUBLIC = 1,
        [Description("Lecture")]
        LECTURE = 100,
        [Description("Ajout")]
        AJOUT = 200,
        [Description("Modification")]
        MODIFICATION = 300
    }
}

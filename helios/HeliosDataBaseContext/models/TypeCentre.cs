using System.ComponentModel;

namespace Helios.Context.Models
{
    public class TypeCentre : ModelEnumBase<TypeCentres>
    {
        public virtual ICollection<Centre>? Centres { get; set; }
    }

    public enum TypeCentres
    {
        [Description("Centre de Renouvellement")]
        Renouvellement = 100,
        [Description("Centre de ville")]
        Ville = 200,
    }
}

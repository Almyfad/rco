using System.ComponentModel;

namespace Helios.Context.Models
{
    public class TypeMembre : ModelEnumBase<TypesMembres>
    {
        public virtual ICollection<Membre>? Membres { get; set; }
        public virtual ICollection<Activitee>? Activitees { get; set; }

    }

    public enum TypesMembres
    {
        [Description("Premier Aspect")]
        PremierAspect = 100,
        [Description("Deuxieme Aspect")]
        DeuxiemeAspect = 200,
        [Description("Ecole de Conscience Supérieure")]
        ECS = 300,
        [Description("Ecclesia")]
        ECCLESIA = 400,
        [Description("Graal")]
        GRAAL = 500,
        [Description("Cinquieme Aspect")]
        CinquiemeAspect = 600,
        [Description("Sixieme Aspect")]
        SixiemeAspect = 700,
        [Description("Septieme Aspect")]
        SeptiemeAspect = 800,
        [Description("Interessé")]
        Interesse = 900,
        [Description("Jeunesse")]
        Jeunesse = 1000,
    }
}

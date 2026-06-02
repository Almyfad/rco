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
        [Description("Sympathisant")]
        Interesse = 900,
        [Description("Contact")]
        Contact = 950,
        [Description("Enfant bébé")]
        Jeunesse = 1000,
        [Description("Enfant groupe pré-A")]
        EnfantGroupePreA = 1050,
        [Description("Enfant groupe A")]
        EnfantGroupeA = 1100,
        [Description("Enfant groupe B")]
        EnfantGroupeB = 1200,
        [Description("Enfant groupe C")]
        EnfantGroupeC = 1300,
        [Description("Enfant groupe D")]
        EnfantGroupeD = 1400,
        [Description("Enfant hors groupe")]
        EnfantHorsGroupe = 1500,
        [Description("Groupe D")]
        GroupeD = 1600,
        [Description("Groupe D+")]
        GroupeDPlus = 1700,
    }
}

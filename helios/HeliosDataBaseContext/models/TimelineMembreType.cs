using System.ComponentModel;

namespace Helios.Context.Models
{
    public class TimelineMembreType : ModelEnumBase<TimelineMembreTypes>
    {
    }

    public enum TimelineMembreTypes
    {
        [Description("Premier Contact")]
        PremierContact = 100,
        [Description("Baptème")]
        Bapteme = 200,
        [Description("Mariage Bénédiction")]
        MariageBenediction = 300,
        [Description("Mariage Sacrement")]
        MariageSacrement = 400,
        [Description("Sociétaire")]
        Societaire = 500,
        [Description("1er Aspect")]
        PremierAspect = 600,
        [Description("2e Aspect")]
        DeuxiemeAspect = 700,
        [Description("ECS")]
        ECS = 800,
        [Description("Ecclesia")]
        Ecclesia = 900,
        [Description("Graal")]
        Graal = 1000,
        [Description("Tête d'or")]
        TeteDor = 1100,
        [Description("6e Aspect")]
        SixiemeAspect = 1200,
        [Description("Codicile")]
        Codicile = 1300,
        [Description("Démission")]
        Demission = 1400,
        [Description("Décès")]
        Deces = 1500

    }
}

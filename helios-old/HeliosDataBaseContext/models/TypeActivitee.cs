using System.ComponentModel;

namespace Helios.Context.Models
{
    public class TypeActivitee : ModelEnumBase<TypesActivitees>
    {
        public virtual ICollection<Activitee>? Activites { get; set; }
    }

    public enum TypesActivitees
    {
        [Description("Service du Temple pour membres interessés")]
        ServiceTempleInteresse = 100,
        [Description("Service du Temple d'approfondissement")]
        ServiceApprofondissement = 200,
        [Description("Week-end Ville")]
        WeekEndVille = 300,
        [Description("Conférence Renouvellement")]
        ConferenceRenouvellement = 400,
        [Description("Conférence ECS")]
        ConferenceECS = 500,
        [Description("Conférence ECC")]
        ConferenceECC = 600,
        [Description("Conférence ECS/ECC")]
        ConferenceECS_ECC = 700,
        [Description("Conférence Convent Graal CTO")]
        ConventGraalCTO = 800,
    }
}

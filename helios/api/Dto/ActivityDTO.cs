using Helios.Context.Models;

public record ActivityDTO(
 int Id,
 string Libelle,
 DateTime debut,
 DateTime fin,
 TypeActiviteDTO TypeActivite,
 ProgrammeDTO? Programme,
 int? ProgrammeId,
 int? CentreId,
 string? CentreNom,
 string? Description)
{
    public static implicit operator ActivityDTO(Activitee activity) =>
        new ActivityDTO(
            Id: activity.Id,
            Libelle: activity.Libelle,
            debut: activity.DateDebut,
            fin: activity.DateFin,
            TypeActivite: activity.TypeActivitee,
            CentreId: activity.Centre?.Id,
            CentreNom: activity.Centre?.Libelle,
            Programme: activity.Programme,
            ProgrammeId : activity.Programme?.Id,
            Description: activity.Description
        );
}

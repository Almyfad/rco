namespace Helios.Dto
{
    public record CreateActivityDTO(
        string Libelle,
        string? Description,
        DateTime DateDebut,
        DateTime DateFin,
        bool IsAllDay,
        int TypeActiviteeId,
        int CentreId,
        int ProgrammeId
    );

    public record UpdateActivityHoursDTO(
        DateTime DateDebut,
        DateTime DateFin
    );
}
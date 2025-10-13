namespace Helios.Dto
{
    public record CreateActivityDTO(
        string Libelle,
        string? Description,
        DateTime DateDebut,
        DateTime DateFin,
        int TypeActiviteeId,
        int CentreId,
        int ProgrammeId
    );
}
using Helios.Context.Models;

public record ProgrammeDTO(
 int Id,
 string Libelle,
 string? Description,
 string? couleur,
 IEnumerable<CentreDTO>? Centres
 )
{
    public static implicit operator ProgrammeDTO?(Programme? programme) => programme is null ? null :
        new ProgrammeDTO(
            Id: programme.Id,
            Libelle: programme.Libelle,
            Description: programme.Description,
            couleur: programme.couleur,
            Centres: programme.Centres?.Select(c => (CentreDTO)c)
        );
}
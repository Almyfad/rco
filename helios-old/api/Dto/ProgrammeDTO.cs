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


public record FlatProgrammeDTO(
 int Id,
 string Libelle,
 string? Description,
 string? couleur,
 int? CentreId,
 string? CentreLibelle
 )
{
}

static public class ProgrammeExtensions
{
    public static IEnumerable<FlatProgrammeDTO>? ToFlatDTO(this Programme? programme) => programme is null ? null :
        programme.Centres?.Select(c => new FlatProgrammeDTO(
            Id: programme.Id,
            Libelle: programme.Libelle,
            Description: programme.Description,
            couleur: programme.couleur,
            CentreId: c.Id,
            CentreLibelle: c.Libelle
        ));
}
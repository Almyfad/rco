using Helios.Context.Models;

public record TypeActiviteDTO(
 int Id,
 string? Description,
 TypesActivitees Code
 )
{
    public static implicit operator TypeActiviteDTO(TypeActivitee typeActivity) =>
        new TypeActiviteDTO(
            Id: typeActivity.Id,
            Description: typeActivity.Description,
            Code: typeActivity.Code
        );
}

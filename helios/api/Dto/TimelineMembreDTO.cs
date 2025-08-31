using Helios.Context.Models;

public record TimelineMembreDTO(
    int Id,
    TimelineMembreType Type,
    DateTime Date,
    string? Commentaire
)
{
    public static explicit operator TimelineMembreDTO(TimelineMembre entity) => new(
       Id: entity.Id,
       Type: entity.Type,
       Date: entity.Date,
       Commentaire: entity.Commentaires
    );

}
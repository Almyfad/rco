public record CentreDTO(int? Id, String? Libelle)
{
    public static explicit operator CentreDTO(Helios.Context.Models.Centre? c) => new(
       Id: c?.Id,
       Libelle: c?.Libelle
        );
}

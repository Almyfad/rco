using Helios.Context.Models;

public record TypeMembreDTO(int? Id, String? Libelle, TypesMembres? types)
{
    public static explicit operator TypeMembreDTO(Helios.Context.Models.TypeMembre? t) => new(
       Id: t?.Id,
       Libelle: t?.Description,
       types: t?.Code
        );
}
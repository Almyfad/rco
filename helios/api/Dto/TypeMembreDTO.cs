using Helios.Context.Models;

public record TypeMembreDTO(int? Id, String? Libelle, TypesMembres? code)
{
    public static implicit operator TypeMembreDTO(Helios.Context.Models.TypeMembre? t) => new(
       Id: t?.Id,
       Libelle: t?.Description,
       code: t?.Code
        );
}

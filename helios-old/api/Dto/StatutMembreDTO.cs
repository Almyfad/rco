using Helios.Context.Models;

public record StatutMembreDTO(int? Id, String? Libelle, StatutsMembres? code)
{
    public static implicit operator StatutMembreDTO(Helios.Context.Models.StatutMembre? s) => new(
        Id: s?.Id,
        Libelle: s?.Description,
        code: s?.Code
        );
}


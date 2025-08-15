using Helios.Context.Models;

public record StatutMembreDTO(int? Id, String? Libelle, StatutsMembres? code)
{
    public static explicit operator StatutMembreDTO(Helios.Context.Models.StatutMembre? s) => new(
        Id: s?.Id,
        Libelle: s?.Description,
        code: s?.Code
        );
}

//[JsonConverter(typeof(JsonStringEnumConverter<statuttest>))]

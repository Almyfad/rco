using Helios.Context.Models;

public record CiviliteDTO(int? Id, string? Libelle,Civilites? code)
{
    public static implicit operator CiviliteDTO(Civilite? c) => new(
        Id: c?.Id,
        Libelle: c?.Description,
        code: c?.Code
    );
}
public record SearchMembreDTO(int Id,
        string Nom,
        string Prenom)
{
    public static implicit operator SearchMembreDTO(Helios.Context.Models.Membre m) =>
        new(
           Id: m.Id,
           Nom: m.Nom,
           Prenom: m.Prenom
        );
}


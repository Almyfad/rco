


using Helios.Context.Models;

public record MembreDTO(
        int Id,
        string Nom,
        string Prenom,
        TypeMembreDTO TypeMembre,
        CentreDTO Centre,
        StatutMembreDTO Statut,
        string? Email,
        string? Telephone,
        string? Portable,
        string? Adresse,
        string? CodePostal,
        string? Ville,
        string? Pays,
        IEnumerable<int>? Parents = null,
        IEnumerable<int>? Enfants = null
    )
{
    public static MembreDTO FromMembre(Helios.Context.Models.Membre m) =>
        (MembreDTO)m;

    public static explicit operator MembreDTO(Helios.Context.Models.Membre m) =>
        new(
           Id: m.Id,
           Nom: m.Nom,
           Prenom: m.Prenom,
           TypeMembre: (TypeMembreDTO)m.TypeMembre,
           Centre: (CentreDTO)m.Centre,
           Statut: (StatutMembreDTO)m.StatutMembre,
           Email: m.Email,
           Telephone: m.Telephone,
           Portable: m.Portable,
           Adresse: m.Adresse,
           CodePostal: m.CodePostal,
           Ville: m.Ville,
           Pays: m.Pays,
           Parents: m.Parents?.Select(x => x.Id),
           Enfants: m.Enfants?.Select(x => x.Id)
        );
}

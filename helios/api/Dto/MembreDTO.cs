



public record MembreDTO(
        int Id,
        string Nom,
        string Prenom,
        CiviliteDTO Civilite,
        TypeMembreDTO TypeMembre,
        CentreDTO Centre,
        StatutMembreDTO Statut,
        string? Email,
        string? Telephone,
        string? Portable,
        string? Adresse,
        string? CodePostal,
        string? Ville,
        string? Pays
    )
{
    public static MembreDTO FromMembre(Helios.Context.Models.Membre m) =>
        (MembreDTO)m;

    public static implicit operator MembreDTO(Helios.Context.Models.Membre m) =>
        new(
           Id: m.Id,
           Nom: m.Nom,
           Prenom: m.Prenom,
           Civilite: m.Civilite,
           TypeMembre: m.TypeMembre,
           Centre: m.Centre,
           Statut: m.StatutMembre,
           Email: m.Email,
           Telephone: m.Telephone,
           Portable: m.Portable,
           Adresse: m.Adresse,
           CodePostal: m.CodePostal,
           Ville: m.Ville,
           Pays: m.Pays
        );
}

public record FamilyDTO(IEnumerable<MembreDTO> Parents, IEnumerable<MembreDTO> Enfants)
{
    public static implicit operator FamilyDTO(Helios.Context.Models.Membre m) =>
        new(
            Parents: m.Parents?.Select(x => (MembreDTO)x) ?? [],
            Enfants: m.Enfants?.Select(x => (MembreDTO)x) ?? []
        );
}


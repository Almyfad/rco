



public record MembreDTO(
        int Id,
        string Nom,
        string Prenom,
        DateOnly? DateNaissance,
        CiviliteDTO Civilite,
        TypeMembreDTO TypeMembre,
        CentreDTO Centre,
        StatutMembreDTO Statut,
        string? Email,
        Boolean EmailValide,
        string? Telephone,
        string? Portable,
        string? Adresse,
        string? CodePostal,
        string? Ville,
        string? Pays,
        string? Commentaires,
        string? Connaissances,
        string? Profession
    )
{
    public static MembreDTO FromMembre(Helios.Context.Models.Membre m) =>
        (MembreDTO)m;

    public static implicit operator MembreDTO(Helios.Context.Models.Membre m) =>
        new(
           Id: m.Id,
           Nom: m.Nom,
           Prenom: m.Prenom,
           DateNaissance: m.DateNaissance,
           Civilite: m.Civilite,
           TypeMembre: m.TypeMembre,
           Centre: m.Centre,
           Statut: m.StatutMembre,
           Email: m.Email,
           EmailValide : m.EmailValide,
           Telephone: m.Telephone,
           Portable: m.Portable,
           Adresse: m.Adresse,
           CodePostal: m.CodePostal,
           Ville: m.Ville,
           Pays: m.Pays,
           Commentaires: m.Commentaires,
           Connaissances: m.Connaissances,
           Profession: m.Profession
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


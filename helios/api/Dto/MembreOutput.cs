public record MembreOutput(
        int Id,
        string Nom,
        string Prenom,
        string? Email = null,
        string? Telephone = null,
        string? Adresse = null,
        string? CodePostal = null,
        string? Ville = null,
        string? Pays = null,
        IEnumerable<MembreOutput>? Parents = null,
        IEnumerable<MembreOutput>? Enfants = null,
        TypeMembreOutput TypeMembre = null!,
        CentreOutput? Centre = null
    )
    {
        public static MembreOutput FromMembre(Helios.Context.Models.Membre m) =>
            (MembreOutput)m;

        public static explicit operator MembreOutput(Helios.Context.Models.Membre m) =>
            new(
                m.Id,
                m.Nom,
                m.Prenom,
                m.Email,
                m.Telephone,
                m.Adresse,
                m.CodePostal,
                m.Ville,
                m.Pays,
                m.Parents?.Select(x => (MembreOutput)x),
                m.Enfants?.Select(x => (MembreOutput)x),
                (TypeMembreOutput)m.TypeMembre!,
                m.Centre != null ? (CentreOutput)m.Centre : null
            );
    }

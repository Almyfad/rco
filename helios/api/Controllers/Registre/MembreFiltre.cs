using Helios.Context.Models;

public record MembreFiltre(
        string? Nom = null,
        string? Prenom = null,
        string? Email = null,
        string? Ville = null,
        string? Pays = null,
        string? Centre = null,
        string? Aspect = null,
        string[]? L_villes = null,
        string[]? L_pays = null,
        string[]? L_centres = null,
        TypesMembres[]? L_aspects = null
    );

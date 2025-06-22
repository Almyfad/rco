namespace Helios.Context.Models
{
    public partial class Membre : ModelBase
    {
        public required Civilite Civilite { get; set; }
        public required string Nom { get; set; }
        public required string Prenom { get; set; }
        public required virtual TypeMembre TypeMembre { get; set; }
        public required virtual StatutMembre StatutMembre { get; set; }
        public virtual Centre? Centre { get; set; }
        public string? Email { get; set; }
        public string? Profession { get; set; }
        public string? Telephone { get; set; }
        public string? Adresse { get; set; }
        public string? CodePostal { get; set; }
        public string? Ville { get; set; }
        public string? Pays { get; set; }
        public bool EmailValide { get; set; }
        public string? Connaissances { get; set; }
        public string? Commentaires { get; set; }
        public DateOnly? DateNaissance { get; set; }
       // public virtual ICollection<Membre>? Enfants { get; set; }
        public virtual Utilisateur? Utilisateur { get; set; }
        public virtual ICollection<Membre>? Parents { get; set; }
        public virtual ICollection<Membre>? Enfants { get; set; }


    }
}

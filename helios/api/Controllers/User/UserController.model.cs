using Helios.Context.Models;
using System.Text.Json.Serialization;

namespace Helios.Controllers.User
{
    public record class UserInfo
    {
        public int Id { get; set; }
        public string? Email { get; set; }
        public string? Nom { get; set; }
        public string? Prenom { get; set; }
        public Boolean IsConnected { get; set; } = false;
        public IEnumerable<CentreModule>? CentreModules { get; set; }
        public IEnumerable<Module>? SysAdminModules { get; set; }
        public IEnumerable<Module>? AdminModules { get; set; }
        public TypesMembres? TypeMembre { get; set; }
    }

    public record CentreInfos(String Code, String Libelle)
    {
        public static implicit operator CentreInfos(Centre centre) => new CentreInfos(centre.Code, centre.Libelle);

        public static implicit operator CentreInfos((string Code, string Libelle) tuple) => new CentreInfos(tuple.Code, tuple.Libelle);

    }
    public record CentreModule(CentreInfos Centre, IEnumerable<Module>? Modules);
    public record CreateUser(Civilites Civilite, string Nom, string Prenom, string Email, TypesMembres TypeMembre, string MotDePasse, string? Telephone, string? Adresse, string? CodePostal, string? Ville, string? Pays, ICollection<Roles> Roles);
}


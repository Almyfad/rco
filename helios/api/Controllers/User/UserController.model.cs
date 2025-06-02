using Helios.Context.Models;
using System.Text.Json.Serialization;

namespace Helios.Controllers.User
{
    public record class UserInfo
    {
        [JsonIgnore]
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

    public record CentreInfos(String Code,String Libelle)
    {
        public static explicit operator CentreInfos(Centre centre)
        {
            return new CentreInfos(centre.Code, centre.Libelle);
        }
        public static explicit operator CentreInfos((string Code, string Libelle) tuple)
        {
            return new CentreInfos(tuple.Code, tuple.Libelle);
        }
    }


    public record CentreModule
    {
        public required CentreInfos Centre { get; set; }
        public IEnumerable<Module>? Modules { get; set; }
    }


    public record CreateUser
    {
        public required Civilites Civilite { get; set; }
        public required string Nom { get; set; }
        public required string Prenom { get; set; }
        public required string Email { get; set; }
        public TypesMembres TypeMembre { get; set; }
        public required string MotDePasse { get; set; }
        public string? Telephone { get; set; }
        public string? Adresse { get; set; }
        public string? CodePostal { get; set; }
        public string? Ville { get; set; }
        public string? Pays { get; set; }
        public required ICollection<Roles> Roles { get; set; }

    }
}


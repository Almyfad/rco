using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Helios.Context.Models
{
    public partial class Utilisateur : ModelBase
    {
        public required String Email { get; set; }
        [JsonIgnore]
        public string? MotDePasse { get; set; }
        public virtual Membre? Membre { get; set; }
        public virtual int? MembreId { get; set; }
        public virtual ICollection<Droit>? Droits { get; set; }
        public virtual ICollection<Role>? Roles { get; set; }
    }
}

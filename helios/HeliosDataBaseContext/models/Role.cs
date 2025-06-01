using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helios.Context.Models
{
    public class Role : ModelEnumBase<Roles> { 
    public virtual ICollection<Utilisateur>? Utilisateurs { get; set; }
    }

    public enum Roles
    {
        [Description("Administrateur Systeme Full access")]
        SYSADMIN = 100,
        [Description("Administrateur Full access")]
        ADMIN_FULL_ACCESS = 200,
        [Description("Manager des droits utilisateurs")]
        USER_MANAGER = 300,
    }

}

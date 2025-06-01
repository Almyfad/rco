using System.ComponentModel.DataAnnotations;

namespace Helios.Context.Models
{
    public class Inscription : ModelBase
    {
        public virtual required Utilisateur Utilisateur { get; set; }  
        public int? UtilisateurId { get; set; }
        public  virtual required Activitee Activitee { get; set; }
        public int? ActiviteeId { get; set; }
        public String? Infos { get; set; }

    }
}

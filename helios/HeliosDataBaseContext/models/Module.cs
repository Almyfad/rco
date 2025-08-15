using System.Text.Json.Serialization;

namespace Helios.Context.Models
{
    public class Module : ModelEnumBase<Modules>
    {
        public required string Label { get; set; }
        public required string Path { get; set; }
        public virtual int? ParentId { get; set; }
        [JsonIgnore]
        public virtual Module? Parent { get; set; }
        public virtual ICollection<Module>? SousMenus { get; set; }
        public String? Icon { get; set; }
        public String? Title { get; set; }
        public string? PrefixIcon { get; set; }
        public string? SuffixIcon { get; set; }


        public static IEnumerable<Module> InitModules()
        {
            var menus = new List<Module>()
            {
                //----------------------
                //Accueil
                //----------------------
                new Module
                {
                    Id =(int) Modules.Accueil,
                    Code = Modules.Accueil,
                    Label = "Accueil",
                    Title = "Bienvenue dans votre Espace Intranet",
                    PrefixIcon = "grass",
                    SuffixIcon = "grass",
                    Icon = "home",
                    Path = "/",

                },
                //----------------------
                //Mailing
                //----------------------
                new Module
                {
                    Id=(int) Modules.Mailing,
                    Code = Modules.Mailing,
                    Label = "Mailing",
                    Icon = "brand-gmail",
                    Path = "/mailing",
                },
                new Module
                {
                    Id =(int) Modules.MailingListes,
                    Code = Modules.MailingListes,
                    ParentId = (int)Modules.Mailing,
                    Label = "Listes",
                    Icon = "message-share",
                    Path = "/mailing/listes",
                },


                //----------------------
                //Conference
                //----------------------
                 new Module
                    {
                        Id =(int) Modules.Conferences,
                        Code = Modules.Conferences,
                        Label = "Conférence",
                        Icon = "building-church",
                        Path = "/conferences",
                    },
                 new Module
                 {
                     Id =(int) Modules.CreateConference,
                     Code = Modules.CreateConference,
                     ParentId = (int)Modules.Conferences,
                     Label = "Créer Conférence",
                     Icon = "calendar-plus",
                     Path = "/creer/conference",
                 },
                 new Module
                    {
                        Id =(int) Modules.ConferencesInscriptions,
                        Code = Modules.ConferencesInscriptions,
                        ParentId = (int)Modules.Conferences,
                        Label = "Inscription",
                        Icon = "calendar-up",
                        Path = "/conferences/inscription",
                    },
                 new Module
                        {
                            Id =(int) Modules.ConferencesUserInscriptions,
                            Code = Modules.ConferencesUserInscriptions,
                            ParentId = (int)Modules.Conferences,
                            Label = "Mes Inscriptions",
                            Icon = "checklist",
                            Path = "/mesinscriptions",
                        },

                //----------------------
                //Registre
                //----------------------
                new Module
                 {
                        Id =(int) Modules.Registre,
                        Code = Modules.Registre,
                        Label = "Registre",
                        Icon = "book",
                        Path = "/registre",
                  },
                new Module
                 {
                     Id =(int) Modules.RegistreFicheEleves,
                     Code = Modules.RegistreFicheEleves,
                     ParentId = (int)Modules.Registre,
                     Label = "Fiches Elèves",
                     Icon = "id",
                     Path = "/registre/fiches/eleves",
                 },
                new Module
                    {
                        Id =(int) Modules.RegistreFicheParvis,
                        Code = Modules.RegistreFicheParvis,
                        ParentId = (int)Modules.Registre,
                        Label = "Fiches Parvis",
                        Icon = "parking-circle",
                        Path = "/registre/fiches-parvis",
                    },
                new Module
                    {
                        Id =(int) Modules.RegistreFicheContacts,
                        Code = Modules.RegistreFicheContacts,
                        ParentId = (int)Modules.Registre,
                        Label = "Fiches Contacts",
                        Icon = "users-group",
                        Path = "/registre/fiches-contacts",
                    },
                new Module
                    {
                        Id =(int) Modules.RegistreFicheJeunesses,
                        Code = Modules.RegistreFicheJeunesses,
                        ParentId = (int)Modules.Registre,
                        Label = "Fiches Jeunesses",
                        Icon = "baby-carriage",
                        Path = "/registre/fiches-jeunesses",
                    },
                new Module
                    {
                        Id =(int) Modules.RegistreFicheJeunesRosicruciens,
                        Code = Modules.RegistreFicheJeunesRosicruciens,
                        ParentId = (int)Modules.Registre,
                        Label = "Fiches Jeunes Rosicruciens",
                        Icon = "horse-toy",
                        Path = "/registre/fiches-jeunes-rosicruciens",
                        },
                new Module
                {
                    Id =(int) Modules.RegistreSaisiePresences,
                    Code = Modules.RegistreSaisiePresences,
                    ParentId = (int)Modules.Registre,
                    Label = "Saisie Présences",
                    Icon = "checklist",
                    Path = "/registre/traitements",
                },
                new Module
                {
                    Id =(int) Modules.RegistreSaisiePresencesVilles,
                    Code = Modules.RegistreSaisiePresencesVilles,
                    ParentId = (int)Modules.RegistreSaisiePresences,
                    Label = "Présence Villes",
                    Icon = "clipboard-smile",
                    Path = "/registre/traitements/encours",
                },
                new Module
                {
                    Id =(int) Modules.RegistreSaisiePresencesCR,
                    Code = Modules.RegistreSaisiePresencesCR,
                    ParentId = (int)Modules.RegistreSaisiePresences,
                    Label = "Présence CR",
                    Icon = "clipboard-heart",
                    Path = "/registre/traitements/termines",
                },
                new Module
                {
                    Id =(int) Modules.RegistreSaisiePresencesEI,
                    Code = Modules.RegistreSaisiePresencesEI,
                    ParentId = (int)Modules.RegistreSaisiePresences,
                    Label = "Présence EI",
                    Icon = "clipboard-check",
                    Path = "/registre/traitements/termines",
                    },
                new Module
                {
                    Id =(int) Modules.RegistreStatistiques,
                    Code = Modules.RegistreStatistiques,
                    ParentId = (int)Modules.Registre,
                    Label = "Statistiques",
                    Icon = "chart-infographic",
                    Path = "/registre/statistiques",
                },
                new Module
                {
                    Id =(int) Modules.RegistreStatistiquesPresences,
                    Code = Modules.RegistreStatistiquesPresences,
                    ParentId = (int)Modules.RegistreStatistiques,
                    Label = "Présences",
                    Icon = "checklist",
                    Path = "/registre/statistiques/villes",
                },
                //----------------------
                //Comptabilite
                //----------------------
                 new Module
                 {
                     Id =(int) Modules.Comptabilite,
                     Code = Modules.Comptabilite,
                     Label = "Comptabilité",
                     Icon = "calculator",
                     Path = "/compta",
                 },
                 new Module
                 {
                        Id =(int) Modules.ComptabiliteEnLigne,
                        Code = Modules.ComptabiliteEnLigne,
                        ParentId = (int)Modules.Comptabilite,
                        Label = "Compta en ligne",
                        Icon = "credit-card-pay",
                        Path = "/compta/comptes",
                 },
                 new Module
                 {
                        Id =(int) Modules.ComptabiliteParametres,
                        Code = Modules.ComptabiliteParametres,
                        ParentId = (int)Modules.Comptabilite,
                        Label = "Paramètre generaux",
                        Icon = "adjustments-alt",
                        Path = "/compta/parametres",
                 },
                 new Module
                 {
                        Id =(int) Modules.ComptabiliteSaisieEcrituresRepetitives,
                        Code = Modules.ComptabiliteSaisieEcrituresRepetitives,
                        ParentId = (int)Modules.Comptabilite,
                        Label = "Sasie écritures répetitives",
                        Icon = "replace",
                        Path = "/compta/ecritures",
                 },
                 new Module
                 {
                        Id =(int) Modules.ComptabiliteComptesCaisse,
                        Code = Modules.ComptabiliteComptesCaisse,
                        ParentId = (int)Modules.Comptabilite,
                        Label = "Comptes/caisse",
                        Icon = "coins",
                        Path = "/compta/comptescaisse",
                 },
                 //----------------------
                 //Developpement
                 //----------------------
                 new Module
                    {
                        Id =(int) Modules.Developpement,
                        Code = Modules.Developpement,
                        Label = "Développement",
                        PrefixIcon= "code",
                        SuffixIcon = "code",
                        Icon = "code",
                        Path = "/developpment",
                    },
                 //----------------------
                 //Administation
                 //----------------------
                 new Module
                        {
                            Id =(int) Modules.Administation,
                            Code = Modules.Administation,
                            Label = "Administation",
                            Icon = "settings",
                            Path = "/administation",
                        },
                 //----------------------
                 //Logout
                 //----------------------
                 new Module
                        {
                            Id =(int) Modules.Logout,
                            Code = Modules.Logout,
                            Label = "Deconnexion",
                            Icon = "logout",
                            Path = "/logout",
                        },


            };
            return menus.Where(x => x.Code != 0);
        }

    }

    public record Menu
    {
        public required List<Module> root { get; set; }
    }


    public enum Modules
    {
        SysAdmin = 1,
        Accueil = 1000,
        Mailing = 6000,
        MailingListes = 6100,
        MailingCampagnes = 6200,
        Conferences = 2000,
        ConferencesInscriptions = 2100,
        ConferencesUserInscriptions = 2200,
        CreateConference = 2300,
        Registre = 3000,
        RegistreFicheEleves = 3010,
        RegistreFicheParvis = 3020,
        RegistreFicheContacts = 3030,
        RegistreFicheJeunesses = 3040,
        RegistreFicheJeunesRosicruciens = 3050,
        RegistreSaisiePresences = 3060,
        RegistreSaisiePresencesVilles = 3061,
        RegistreSaisiePresencesCR = 3062,
        RegistreSaisiePresencesEI = 3063,
        RegistreStatistiques = 3070,
        RegistreStatistiquesPresences = 3071,
        RegistreStatistiquesMouvements = 3072,
        Comptabilite = 4000,
        ComptabiliteEnLigne = 4010,
        ComptabiliteParametres = 4020,
        ComptabiliteSaisieEcrituresRepetitives = 4030,
        ComptabiliteComptesCaisse = 4040,
        Developpement = 10000,
        Administation = 5000,
        Logout = 50000,
    }
}
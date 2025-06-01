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
                    Icon = "email",
                    Path = "/mailing",
                },
                new Module
                {
                    Id =(int) Modules.MailingListes,
                    Code = Modules.MailingListes,
                    ParentId = (int)Modules.Mailing,
                    Label = "Listes",
                    Icon = "list",
                    Path = "/mailing/listes",
                },
                new Module
                {
                    Id =(int) Modules.MailingCampagnes,
                    Code = Modules.MailingCampagnes,
                    ParentId = (int)Modules.Mailing,
                    Label = "Campagnes",
                    Icon = "campaign",
                    Path = "/mailing/campagnes",
                },


                //----------------------
                //Conference
                //----------------------
                 new Module
                    {
                        Id =(int) Modules.Conferences,
                        Code = Modules.Conferences,
                        Label = "Conférence",
                        Icon = "temple_buddhist",
                        Path = "/conferences",
                    },
                 new Module
                 {
                     Id =(int) Modules.CreateConference,
                     Code = Modules.CreateConference,
                     ParentId = (int)Modules.Conferences,
                     Label = "Créer Conférence",
                     Icon = "post_add",
                     Path = "/creer/conference",
                 },
                 new Module
                    {
                        Id =(int) Modules.ConferencesInscriptions,
                        Code = Modules.ConferencesInscriptions,
                        ParentId = (int)Modules.Conferences,
                        Label = "Inscription",
                        Icon = "person_add",
                        Path = "/conferences/inscription",
                    },
                 new Module
                        {
                            Id =(int) Modules.ConferencesUserInscriptions,
                            Code = Modules.ConferencesUserInscriptions,
                            ParentId = (int)Modules.Conferences,
                            Label = "Mes Inscriptions",
                            Icon = "edit",
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
                     Icon = "people",
                     Path = "/registre/fiches/eleves",
                 },
                new Module
                    {
                        Id =(int) Modules.RegistreFicheParvis,
                        Code = Modules.RegistreFicheParvis,
                        ParentId = (int)Modules.Registre,
                        Label = "Fiches Parvis",
                        Icon = "wb_iridescent",
                        Path = "/registre/fiches-parvis",
                    },
                new Module
                    {
                        Id =(int) Modules.RegistreFicheContacts,
                        Code = Modules.RegistreFicheContacts,
                        ParentId = (int)Modules.Registre,
                        Label = "Fiches Contacts",
                        Icon = "contact_page",
                        Path = "/registre/fiches-contacts",
                    },
                new Module
                    {
                        Id =(int) Modules.RegistreFicheJeunesses,
                        Code = Modules.RegistreFicheJeunesses,
                        ParentId = (int)Modules.Registre,
                        Label = "Fiches Jeunesses",
                        Icon = "child_care",
                        Path = "/registre/fiches-jeunesses",
                    },
                new Module
                    {
                        Id =(int) Modules.RegistreFicheJeunesRosicruciens,
                        Code = Modules.RegistreFicheJeunesRosicruciens,
                        ParentId = (int)Modules.Registre,
                        Label = "Fiches Jeunes Rosicruciens",
                        Icon = "settings_accessibility",
                        Path = "/registre/fiches-jeunes-rosicruciens",
                        },
                new Module
                {
                    Id =(int) Modules.RegistreSaisiePresences,
                    Code = Modules.RegistreSaisiePresences,
                    ParentId = (int)Modules.Registre,
                    Label = "Saisie Présences",
                    Icon = "featured_play_list",
                    Path = "/registre/traitements",
                },
                new Module
                {
                    Id =(int) Modules.RegistreSaisiePresencesVilles,
                    Code = Modules.RegistreSaisiePresencesVilles,
                    ParentId = (int)Modules.RegistreSaisiePresences,
                    Label = "Présence Villes",
                    Icon = "list_alt",
                    Path = "/registre/traitements/encours",
                },
                new Module
                {
                    Id =(int) Modules.RegistreSaisiePresencesCR,
                    Code = Modules.RegistreSaisiePresencesCR,
                    ParentId = (int)Modules.RegistreSaisiePresences,
                    Label = "Présence CR",
                    Icon = "fact_check",
                    Path = "/registre/traitements/termines",
                },
                new Module
                {
                    Id =(int) Modules.RegistreSaisiePresencesEI,
                    Code = Modules.RegistreSaisiePresencesEI,
                    ParentId = (int)Modules.RegistreSaisiePresences,
                    Label = "Présence EI",
                    Icon = "receipt_long",
                    Path = "/registre/traitements/termines",
                    },
                new Module
                {
                    Id =(int) Modules.RegistreStatistiques,
                    Code = Modules.RegistreStatistiques,
                    ParentId = (int)Modules.Registre,
                    Label = "Statistiques",
                    Icon = "insert_chart_outlined",
                    Path = "/registre/statistiques",
                },
                new Module
                {
                    Id =(int) Modules.RegistreStatistiquesPresences,
                    Code = Modules.RegistreStatistiquesPresences,
                    ParentId = (int)Modules.RegistreStatistiques,
                    Label = "Présences",
                    Icon = "list_alt",
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
                     Icon = "account_balance",
                     Path = "/compta",
                 },
                 new Module
                 {
                        Id =(int) Modules.ComptabiliteEnLigne,
                        Code = Modules.ComptabiliteEnLigne,
                        ParentId = (int)Modules.Comptabilite,
                        Label = "Compta en ligne",
                        Icon = "account_balance_wallet",
                        Path = "/compta/comptes",
                 },
                 new Module
                 {
                        Id =(int) Modules.ComptabiliteParametres,
                        Code = Modules.ComptabiliteParametres,
                        ParentId = (int)Modules.Comptabilite,
                        Label = "Paramètre generaux",
                        Icon = "settings",
                        Path = "/compta/parametres",
                 },
                 new Module
                 {
                        Id =(int) Modules.ComptabiliteSaisieEcrituresRepetitives,
                        Code = Modules.ComptabiliteSaisieEcrituresRepetitives,
                        ParentId = (int)Modules.Comptabilite,
                        Label = "Sasie écritures répetitives",
                        Icon = "monetization_on",
                        Path = "/compta/ecritures",
                 },
                 new Module
                 {
                        Id =(int) Modules.ComptabiliteComptesCaisse,
                        Code = Modules.ComptabiliteComptesCaisse,
                        ParentId = (int)Modules.Comptabilite,
                        Label = "Comptes/caisse",
                        Icon = "description",
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
                            Icon = "admin_panel_settings",
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
                            Icon = "exit_to_app",
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
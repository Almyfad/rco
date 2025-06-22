using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Helios.Context.Models;
using System.ComponentModel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.Design;


namespace Helios.Context
{
    public class HeliosContext : DbContext
    {
        public DbSet<Module> Modules { get; set; }
        public DbSet<Utilisateur> Utilisateurs { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<TypeActivitee> TypeActivitees { get; set; }
        public DbSet<Activitee> Activitees { get; set; }
        public DbSet<TypeCentre> TypeCentres { get; set; }
        public DbSet<Centre> Centre { get; set; }
        public DbSet<TypeMembre> TypeMembres { get; set; }
        public DbSet<StatutMembre> StatutMembres { get; set; }
        public DbSet<Inscription> Inscriptions { get; set; }
        public DbSet<Civilite> Civilites { get; set; }
        public DbSet<Membre> Membres { get; set; }
        public DbSet<Droit> Droits { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
        public HeliosContext()
        {

        }
        public HeliosContext(DbContextOptions<HeliosContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Module>(e =>
            {
                e.ToTable("Modules");
                e.HasKey(r => r.Id);
                e.HasData(Module.InitModules());
            });
            modelBuilder.Entity<Droit>(e =>
            {
                e.ToTable("Droits");
                e.HasKey(r => r.Id);
                e.HasData(
                    new { Id = 1, ModuleId = (int)Models.Modules.Accueil, Code = Models.Droits.PUBLIC },
                    new { Id = 2, ModuleId = (int)Models.Modules.Conferences, Code = Models.Droits.PUBLIC },
                    new { Id = 3, ModuleId = (int)Models.Modules.ConferencesInscriptions, Code = Models.Droits.PUBLIC },
                    new { Id = 4, ModuleId = (int)Models.Modules.ConferencesUserInscriptions, Code = Models.Droits.PUBLIC },
                    new { Id = 5, ModuleId = (int)Models.Modules.Logout, Code = Models.Droits.PUBLIC },
                    new { Id = 6, CentreId = 1, utilisateurId = 4, ModuleId = (int)Models.Modules.Registre, Code = Models.Droits.AJOUT },
                    new { Id = 7, CentreId = 1, utilisateurId = 4, ModuleId = (int)Models.Modules.RegistreFicheEleves, Code = Models.Droits.AJOUT },
                    new { Id = 8, CentreId = 1, utilisateurId = 4, ModuleId = (int)Models.Modules.Comptabilite, Code = Models.Droits.AJOUT },
                    new { Id = 9, CentreId = 2, utilisateurId = 4, ModuleId = (int)Models.Modules.Registre, Code = Models.Droits.LECTURE },
                    new { Id = 10, CentreId = 2, utilisateurId = 4, ModuleId = (int)Models.Modules.CreateConference, Code = Models.Droits.AJOUT }
                    );
            });
            modelBuilder.Entity<Civilite>(e =>
            {
                e.ToTable("Civilites");
                e.HasKey(r => r.Id);

                e.HasIndex(e => e.Code).IsUnique();
                e.HasDataFromEnum<Civilites, Civilite>();
                e.Property(r => r.Code).HasConversion<string>();
            });
            modelBuilder.Entity<TypeMembre>(e =>
            {
                e.ToTable("TypeMembres");
                e.HasKey(r => r.Id);

                e.HasIndex(e => e.Code).IsUnique();
                e.HasDataFromEnum<TypesMembres, TypeMembre>();
                e.Property(r => r.Code).HasConversion<string>();
            });
            modelBuilder.Entity<StatutMembre>(e =>
            {
                e.ToTable("StatutMembres");
                e.HasKey(r => r.Id);
                e.HasIndex(e => e.Code).IsUnique();
                e.HasDataFromEnum<StatutsMembres, StatutMembre>();
                e.Property(r => r.Code).HasConversion<string>();
            });
            modelBuilder.Entity<Role>(e =>
            {
                e.ToTable("Roles");
                e.HasKey(r => r.Id);

                e.HasIndex(e => e.Code).IsUnique();
                e.HasDataFromEnum<Roles, Role>();
                e.Property(r => r.Code).HasConversion<string>();

            });
            modelBuilder.Entity<Membre>(e =>
            {
                e.ToTable("Membres");
                e.HasKey(u => u.Id);
                e.HasMany(e => e.Parents).WithMany(e => e.Enfants).UsingEntity(et => et.ToTable("ParentsEnfants"));
            });
            modelBuilder.Entity<Utilisateur>(e =>
            {
                e.ToTable("Utilisateurs");
                e.HasKey(u => u.Id);
                // e.HasIndex(e => e.Email).IsUnique();
                e.HasData(new Utilisateur()
                {
                    Email = "admin@rco.com",
                    Id = 1,                  
                    MotDePasse = "AQAAAAIAAYagAAAAEEiNVE7GnBd6NNlBeIh1KHdEWcrYV3GpgaIw5NPr3hQ8LCK30Df1/LgmaUfSBliSLg==",
                });
                e.HasData(new Utilisateur()
                {
                    Email = "admin2@rco.com",
                    Id = 2,
                    MotDePasse = "AQAAAAIAAYagAAAAEEiNVE7GnBd6NNlBeIh1KHdEWcrYV3GpgaIw5NPr3hQ8LCK30Df1/LgmaUfSBliSLg==",
                });
                e.HasData(new Utilisateur()
                {
                    Email = "usermanager@rco.com",
                    Id = 3,
                    MotDePasse = "AQAAAAIAAYagAAAAEEiNVE7GnBd6NNlBeIh1KHdEWcrYV3GpgaIw5NPr3hQ8LCK30Df1/LgmaUfSBliSLg==",
                });
                e.HasData(new Utilisateur()
                {
                    Email = "usercentre@rco.com",
                    Id = 4,
                    MotDePasse = "AQAAAAIAAYagAAAAEEiNVE7GnBd6NNlBeIh1KHdEWcrYV3GpgaIw5NPr3hQ8LCK30Df1/LgmaUfSBliSLg==",
                });
                e.HasMany(e => e.Roles).WithMany(e => e.Utilisateurs)
                .UsingEntity(e => e.HasData(new[]
                {
                     new { UtilisateursId = 1, RolesId = 100 },
                     new { UtilisateursId = 2, RolesId = 200 },
                     new { UtilisateursId = 2, RolesId = 300 },
                }));
            });
            modelBuilder.Entity<TypeActivitee>(e =>
            {
                e.ToTable("TypeActivitees");
                e.HasKey(r => r.Id);

                e.HasIndex(e => e.Code).IsUnique();
                e.HasDataFromEnum<TypesActivitees, TypeActivitee>();
                e.Property(r => r.Code).HasConversion<string>();
            });
            modelBuilder.Entity<TypeCentre>(e =>
            {
                e.ToTable("TypeCentres");
                e.HasKey(r => r.Id);

                e.HasIndex(e => e.Code).IsUnique();
                e.HasDataFromEnum<TypeCentres, TypeCentre>();
                e.Property(r => r.Code).HasConversion<string>();
            });
            modelBuilder.Entity<Centre>(e =>
            {
                e.ToTable("Centres");
                e.HasKey(r => r.Id);

                e.HasIndex(e => e.Code).IsUnique();
                e.HasData(
                    new { Id = 1, Code = "MG", Libelle = "MontGivroux", Pays = "France", CodePostal = "93120", Adresse = "", TypeCentreId = 100 },
                    new { Id = 2, Code = "PO", Libelle = "Poitier", Pays = "France", CodePostal = "93120", Adresse = "", TypeCentreId = 100 },
                    new { Id = 3, Code = "LC", Libelle = "La Licorne", Pays = "France", CodePostal = "93120", Adresse = "", TypeCentreId = 100 },
                    new { Id = 4, Code = "PR", Libelle = "Paris", Pays = "France", CodePostal = "93120", Adresse = "", TypeCentreId = 200 },
                    new { Id = 5, Code = "LY", Libelle = "Lyon", Pays = "France", CodePostal = "69000", Adresse = "", TypeCentreId = 200 },
                    new { Id = 6, Code = "MA", Libelle = "Marseille", Pays = "France", CodePostal = "13000", Adresse = "", TypeCentreId = 200 },
                    new { Id = 7, Code = "TO", Libelle = "Toulouse", Pays = "France", CodePostal = "31000", Adresse = "", TypeCentreId = 200 },
                    new { Id = 8, Code = "GP", Libelle = "Guadeloupe", Pays = "France", CodePostal = "97100", Adresse = "", TypeCentreId = 200 },
                    new { Id = 9, Code = "AX", Libelle = "Aix-en-Provence", Pays = "France", CodePostal = "97100", Adresse = "", TypeCentreId = 200 },
                    new { Id = 10, Code = "LL", Libelle = "Lille", Pays = "France", CodePostal = "97100", Adresse = "", TypeCentreId = 200 },
                    new { Id = 11, Code = "MT", Libelle = "Metz", Pays = "France", CodePostal = "97100", Adresse = "", TypeCentreId = 200 },
                    new { Id = 12, Code = "MP", Libelle = "Montptelier", Pays = "France", CodePostal = "97100", Adresse = "", TypeCentreId = 200 },
                    new { Id = 13, Code = "PP", Libelle = "Perpignan", Pays = "France", CodePostal = "97100", Adresse = "", TypeCentreId = 200 },
                    new { Id = 14, Code = "CA", Libelle = "Côte d'Azure", Pays = "France", CodePostal = "97100", Adresse = "", TypeCentreId = 200 },
                    new { Id = 15, Code = "RE", Libelle = "Rennes", Pays = "France", CodePostal = "97100", Adresse = "", TypeCentreId = 200 },
                    new { Id = 16, Code = "RU", Libelle = "Rouen", Pays = "France", CodePostal = "97100", Adresse = "", TypeCentreId = 200 },
                    new { Id = 17, Code = "SB", Libelle = "Strasbourg", Pays = "France", CodePostal = "97100", Adresse = "", TypeCentreId = 200 }
                );
            });
            modelBuilder.Entity<Activitee>(e =>
            {
                e.ToTable("Activitees");
                e.HasKey(r => r.Id);
            });
            modelBuilder.Entity<Inscription>(e =>
            {
                e.ToTable("Inscriptions");
                e.HasKey(r => r.Id);
            });


            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                // Appliquer à toutes les entités concrètes héritant de ModelBase
                var clrType = entityType.ClrType;
                var ismodelBase = (typeof(ModelBase).IsAssignableFrom(clrType) && clrType.IsClass && !clrType.IsAbstract);


                // Appliquer à toutes les entités héritant de ModelEnumBase<T>
                var baseType = clrType.BaseType;
                ismodelBase = ismodelBase || (baseType != null && baseType.IsGenericType &&
                baseType.GetGenericTypeDefinition() == typeof(ModelEnumBase<>));

                if (ismodelBase)
                {
                    modelBuilder.Entity(clrType)
                        .Property(nameof(ModelBase.Creation))
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    modelBuilder.Entity(clrType)
                    .Property(nameof(ModelBase.Modification))
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
                }
            }


        }

    }

    public static class EntityTypeBuilderExtention
    {

        public static EntityTypeBuilder HasDataFromEnum<TEnum, TClass>(this EntityTypeBuilder e,
            Func<TEnum, int>? idSelector = null,
            Func<TEnum, String>? labelSelector = null,
             string codePropertyName = "Code",
            string labelPropertyName = "Description"
            ) where TEnum : struct, Enum
            where TClass : notnull
        {

            var _idSelector = idSelector ?? ((x) => (int)(object)x);
            var _labelSelector = labelSelector ?? ((x) => GetEnumDescription(x));

            e.HasData(Enum.GetValues<TEnum>().Select((x) =>
                {
                    var properties = new Dictionary<string, object>();
                    properties.Add(codePropertyName, x);
                    properties.Add("Id", _idSelector(x));
                    properties.Add(labelPropertyName, _labelSelector(x));
                    string json = System.Text.Json.JsonSerializer.Serialize(properties);
                    dynamic obj = System.Text.Json.JsonSerializer.Deserialize<TClass>(json) ?? throw (new Exception($"Unable to Deserialise TClass:{typeof(TClass)}"));
                    return obj!;
                }
            ));
            return e;
        }

        public static string GetEnumDescription(Enum value)
        {
            if (value == null) { return ""; }
            return value
                .GetType()
                    .GetField(value.ToString())
                    ?.GetCustomAttributes(typeof(DescriptionAttribute), false)
                    .SingleOrDefault() is not DescriptionAttribute attribute ? value.ToString() : attribute.Description;
        }
    }
    public static class HeliosContextExtensions
    {

        public class ConnectionString
        {
#if RELEASE
            public String? Host => Environment.GetEnvironmentVariable("MYSQL_HOST");
            public String? Port => Environment.GetEnvironmentVariable("MYSQL_PORT");
            public String? User => Environment.GetEnvironmentVariable("MYSQL_USER");
            public String? Password => Environment.GetEnvironmentVariable("MYSQL_PASSWORD");
            public String? Database => Environment.GetEnvironmentVariable("MYSQL_DATABASE");
#endif
#if DEBUG
            public String? Host => Environment.GetEnvironmentVariable("MYSQL_HOST") ?? "mj1848-001.eu.clouddb.ovh.net";
            public String? Port => Environment.GetEnvironmentVariable("MYSQL_PORT") ?? "35117";
            public String? User => Environment.GetEnvironmentVariable("MYSQL_USER") ?? "heliosdev";

            public String? Password => Environment.GetEnvironmentVariable("MYSQL_PASSWORD") ?? "Lm9evzdoNAXNmR0f";
            public String? Database => Environment.GetEnvironmentVariable("MYSQL_DATABASE") ?? "helios-dev";
#endif
            public String CnxString => (Host == null || User == null || Password == null || Database == null || Port == null) ?
                throw new Exception("Illegal Connection String")
                : $"server={Host};port={Port};user={User};password={Password};database={Database};";

        }

        public static DbContextOptionsBuilder UseHeliosContext(this DbContextOptionsBuilder optionsBuilder)
        {
            var cnx = new ConnectionString();
            optionsBuilder.UseMySql(cnx.CnxString, ServerVersion.AutoDetect(cnx.CnxString))
                .UseLazyLoadingProxies(false)
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging(true)
                .EnableDetailedErrors();

            return optionsBuilder;
        }

        public static IServiceCollection AddHeliosContext(this IServiceCollection services)
        {
            var cnx = new ConnectionString();
            services.AddDbContext<HeliosContext>(options =>
            {
                options.UseHeliosContext();
            });
            return services;
        }

    }
    public class HeliosContextFactory : IDesignTimeDbContextFactory<HeliosContext>
    {
        public HeliosContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<HeliosContext>();
            optionsBuilder.UseHeliosContext();
            return new HeliosContext(optionsBuilder.Options);
        }
    }
}

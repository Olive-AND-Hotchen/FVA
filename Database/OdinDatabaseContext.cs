using FVA.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace FVA.Database;

public class OdinDatabaseContext(
    DbContextOptions
        <OdinDatabaseContext> options) : DbContext(options)
{

    public DbSet<Organisation> Organisations { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<OrganisationLocation> OrganisationLocations { get; set; }
    public DbSet<OrganisationRole> OrganisationRoles { get; set; }
    public DbSet<PeopleContact> PeopleContacts { get; set; }
    public DbSet<PostcodeData> PostcodeData { get; set; }
    public DbSet<ServiceRole> ServiceRoles { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<ServiceLocation> ServiceLocations { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<AccessibilityFeature> AccessibilityFeatures { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        SetupOrganisation(modelBuilder);
        SetupLocation(modelBuilder);
        SetupOrganisationLocation(modelBuilder);
        SetupOrganisationRoles(modelBuilder);
        SetupPeopleContacts(modelBuilder);
        SetupPostcodeData(modelBuilder);
        SetupServiceRoles(modelBuilder);
        SetupRoles(modelBuilder);
        SetupServiceLocations(modelBuilder);
        SetupServices(modelBuilder);
        SetupAccessibilityFeatures(modelBuilder);
        
        base.OnModelCreating(modelBuilder);
    }

    private static void SetupAccessibilityFeatures(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AccessibilityFeature>().Property(af => af.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<AccessibilityFeature>().HasOne<Location>(af => af.Location);
    }

    private static void SetupServices(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Service>().Property(s => s.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<Service>().HasOne<Organisation>(s => s.Organisation);
    }

    private static void SetupServiceLocations(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ServiceLocation>().Property(sl => sl.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<ServiceLocation>().HasOne<Service>(s => s.Service);
        modelBuilder.Entity<ServiceLocation>().HasOne<Location>(s => s.Location);
    }

    private static void SetupRoles(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Role>().Property(r => r.Id).ValueGeneratedOnAdd();
    }

    private static void SetupServiceRoles(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ServiceRole>().Property(sr => sr.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<ServiceRole>().HasOne<Role>(sr => sr.Role);
        modelBuilder.Entity<ServiceRole>().HasOne<PeopleContact>(sr => sr.PeopleContact);
    }

    private static void SetupPostcodeData(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PostcodeData>().Property(pd => pd.Id).ValueGeneratedOnAdd();
    }

    private static void SetupPeopleContacts(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PeopleContact>().Property(pc => pc.Id).ValueGeneratedOnAdd();
    }

    private static void SetupOrganisationRoles(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OrganisationRole>().Property(or => or.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<OrganisationRole>().HasOne<Organisation>(or => or.Organisation);
        modelBuilder.Entity<OrganisationRole>().HasOne<PeopleContact>(or => or.PeopleContact);
        modelBuilder.Entity<OrganisationRole>().HasOne<Role>(or => or.Role);
    }

    private static void SetupOrganisationLocation(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OrganisationLocation>().Property(ol => ol.OrganisationId).ValueGeneratedOnAdd();
        modelBuilder.Entity<OrganisationLocation>().HasOne<Organisation>(ol => ol.Organisation);
        modelBuilder.Entity<OrganisationLocation>().HasOne<Location>(ol => ol.Location);
    }

    private static void SetupLocation(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Location>().Property(l => l.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<Location>().HasMany<AccessibilityFeature>(l => l.AccessibilityFeatures);
        modelBuilder.Entity<Location>().HasOne<PostcodeData>(l => l.PostcodeData);
    }

    private static void SetupOrganisation(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Organisation>().Property(o => o.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<Organisation>()
            .HasMany<Service>(s => s.Services);
        modelBuilder.Entity<Organisation>()
            .HasMany<OrganisationRole>(o => o.OrganisationRoles);
        modelBuilder.Entity<Organisation>()
            .HasOne<Organisation>(p => p.Parent);
    }
}
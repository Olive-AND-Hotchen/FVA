using Bogus;
using FVA.Database;
using FVA.Database.Models;
using Server.Database.Models;

namespace Server.Static;

public static class TestDataSeeding
{
    public static async Task Seed(HttpContext context)
    {
        var db = context.RequestServices.GetService<OdinDatabaseContext>();
        var orgId = 1;
        var serviceId = 1;
        var roleId = 1;


        var productFaker = new Faker<Organisation>()
            .RuleFor(x => x.Id, f => orgId++) // Each item that is generated will get an incremented Id
            .RuleFor(x => x.Name, f => f.Company.CompanyName())
            .RuleFor(x => x.ActiveFrom, f => f.Date.Past().ToUniversalTime())
            .RuleFor(x => x.ActiveTo, f => f.Date.Future().ToUniversalTime())
            .RuleFor(x => x.OutOfArea, f => f.Random.Bool())
            .RuleFor(x => x.Objectives, f => f.Lorem.Sentence())
            .RuleFor(x => x.Parent, _ => null)
            .RuleFor(x => x.Services, f =>
            {
                var serviceFaker = new Faker<Service>();
                serviceFaker
                    .RuleFor(x => x.Id, _ => serviceId++)
                    .RuleFor(x => x.OutOfArea, f => f.Random.Bool())
                    .RuleFor(x => x.AimsObjectives, f => f.Lorem.Sentence())
                    .RuleFor(x => x.OperatingHours, f => f.Lorem.Sentence())
                    .RuleFor(x => x.WorkerGenderChoice, f => f.Lorem.Sentence())
                    .RuleFor(x => x.DemographicRestrictions, f => f.Lorem.Sentence())
                    .RuleFor(x => x.OrganisationId, f => orgId)
                    .RuleFor(x => x.ReferralDetails, f => f.Lorem.Sentence())
                    .RuleFor(x => x.ServiceObjectives, f => f.Lorem.Sentence());
                return serviceFaker.Generate(10);
            });

        var organisations = productFaker.Generate(100);

        var roleFaker = new Faker<Role>()
            .RuleFor(x => x.Id, f => roleId++)
            .RuleFor(x => x.From, f => f.Date.Past().ToUniversalTime())
            .RuleFor(x => x.To, f => f.Date.Future().ToUniversalTime())
            .RuleFor(x => x.Title, f => f.Lorem.Word())
            .RuleFor(x => x.PublicContact, f => f.Lorem.Word());

        var locationFaker = new Faker<Location>()
            .RuleFor(x => x.Id, f => f.UniqueIndex)
            .RuleFor(x => x.Area, f => f.Lorem.Word())
            .RuleFor(x => x.Town, f => f.Lorem.Word())
            .RuleFor(x => x.Street, f => f.Lorem.Word())
            .RuleFor(x => x.Postcode, f => f.Lorem.Word())
            .RuleFor(x => x.Region, f => f.Lorem.Word())
            .RuleFor(x => x.BuildingName, f => f.Lorem.Word())
            .RuleFor(x => x.BuildingNumber, f => f.Lorem.Word())
            .RuleFor(x => x.LocationType, f => f.Lorem.Word())
            .RuleFor(x => x.LongtitudeLattitude, f => f.Lorem.Word())
            .RuleFor(x => x.ParkingDetails, f => f.Lorem.Sentence())
            .RuleFor(x => x.PostcodeData, f => new PostcodeData
            {
                CouncilConstituency = f.Lorem.Word(),
                CouncilWard = f.Lorem.Word(),
                OutwardCode = f.Lorem.Word(),
                Id = f.UniqueIndex
            })
            .RuleFor(x => x.AccessibilityFeatures, f => []);

        var locations = locationFaker.Generate(100);

        var serviceLocationFaker = new Faker<ServiceLocation>()
            .RuleFor(x => x.Service, f => f.PickRandom(organisations.SelectMany(x => x.Services)))
            .RuleFor(x => x.Id, f => f.UniqueIndex)
            .RuleFor(x => x.Location, f => f.PickRandom(locations));

        var roles = roleFaker.Generate(100);
        var serviceLocations = serviceLocationFaker.Generate(100);
        db?.AddRange(organisations);
        db?.AddRange(roles);
        db?.AddRange(locations);
        db?.AddRange(serviceLocations);
        await db?.SaveChangesAsync()!;
    }
}
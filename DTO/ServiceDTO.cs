namespace DTO;

public record ServiceDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public OrganisationDto Organisation { get; set; }
    public int OrganisationId { get; set; }
    public string ReferralDetails { get; set; }
    public string OperatingHours { get; set; }
    public string ServiceObjectives { get; set; }
    public string DemographicRestrictions { get; set; }
    public int ServiceCost { get; set; }
    public string WorkerGenderChoice { get; set; }
    public bool OutOfArea { get; set; }
    public string AimsObjectives { get; set; }
}
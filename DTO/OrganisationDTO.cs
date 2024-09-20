namespace DTO;

public record OrganisationDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime ActiveFrom { get; set; }
    public DateTime ActiveTo { get; set; }
    public bool OutOfArea { get; set; }
    public string Objectives { get; set; }
    public OrganisationDto? Parent { get; set; }
    public int ParentOrganisationId { get; set; }
    public List<ServiceDto> Services { get; set; }
    public List<OrganisationRoleDto> OrganisationRoles { get; set; }
}
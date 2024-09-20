namespace DTO;

public record OrganisationRoleDto
{
    public int Id { get; set; }
    public required OrganisationDto Organisation { get; set; }
    public int OrganisationId { get; set; }
    public required PeopleContactDTO PeopleContact { get; set; }
    public int PeopleContactId { get; set; }
    public required RoleDTO Role { get; set; }
    public int RoleId { get; set; }
}